﻿using System.Xml.Serialization;
using Microsoft.Deployment.Compression.Cab;
using DiscUtils;
using Microsoft.Deployment.Compression;
using MobilePackageGen.GZip;

namespace MobilePackageGen
{
    public class SPKGBuilder
    {
        private static string GetSPKGComponentName(XmlDsm.Package dsm)
        {
            return $"{dsm.Identity.Owner}" +
                $"{(string.IsNullOrEmpty(dsm.Identity.Component) ? "": $".{dsm.Identity.Component}")}" +
                $"{(string.IsNullOrEmpty(dsm.Identity.SubComponent) ? "" : $".{dsm.Identity.SubComponent}")}" +
                $"{(string.IsNullOrEmpty(dsm.Culture) == true ? "" : $"_Lang_{dsm.Culture}")}";
        }

        private static List<CabinetFileInfo> GetCabinetFileInfoForDsmPackage(XmlDsm.Package dsm, IPartition partition, List<IDisk> disks)
        {
            List<CabinetFileInfo> fileMappings = [];

            IFileSystem? fileSystem = partition.FileSystem;

            string packageName = GetSPKGComponentName(dsm);

            int i = 0;

            uint oldPercentage = uint.MaxValue;

            foreach (XmlDsm.FileEntry packageFile in dsm.Files.FileEntry)
            {
                uint percentage = (uint)Math.Floor((double)i++ * 50 / dsm.Files.FileEntry.Count);

                if (percentage != oldPercentage)
                {
                    oldPercentage = percentage;
                    string progressBarString = GetDISMLikeProgressBar(percentage);
                    Console.Write($"\r{progressBarString}");
                }

                string fileName = packageFile.DevicePath;

                string normalized = fileName;

                // Prevent getting files from root of this program
                if (normalized.StartsWith("\\"))
                {
                    normalized = normalized[1..];
                }

                CabinetFileInfo? cabinetFileInfo = null;

                // If we end in bin, and the package is marked binary partition, this is a partition on one of the device disks, retrieve it
                if (normalized.EndsWith(".bin") && packageFile.FileType.Contains("BinaryPartition", StringComparison.CurrentCultureIgnoreCase))
                {
                    foreach (IDisk disk in disks)
                    {
                        bool done = false;

                        foreach (IPartition diskPartition in disk.Partitions)
                        {
                            if (diskPartition.Name.Equals(dsm.Partition, StringComparison.InvariantCultureIgnoreCase))
                            {
                                done = true;

                                // Some older SPKGs from 2012 / 2013 may lack the packageFile.FileSize property entirely
                                // in their DSM file. In this case, we will use the size of the partition itself.
                                // It may also be possible to infer the correct size from the catalog
                                // if the size is not meant to be the full size of the partition.

                                Stream partitionStream = packageFile.FileSize != null ? new Substream(diskPartition.Stream, long.Parse(packageFile.FileSize)) : diskPartition.Stream;

                                cabinetFileInfo = new CabinetFileInfo()
                                {
                                    FileName = packageFile.CabPath,
                                    FileStream = partitionStream,
                                    Attributes = FileAttributes.Normal,
                                    DateTime = DateTime.Now
                                };
                                break;
                            }
                        }

                        if (done)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    if (!fileSystem.FileExists(normalized))
                    {
                        string[] partitionNamesWithLinks = ["data", "efiesp", "osdata", "dpp", "mmos"];

                        foreach (string partitionNameWithLink in partitionNamesWithLinks)
                        {
                            if (normalized.StartsWith(partitionNameWithLink + "\\", StringComparison.InvariantCultureIgnoreCase))
                            {
                                foreach (IDisk disk in disks)
                                {
                                    bool done = false;

                                    foreach (IPartition diskPartition in disk.Partitions)
                                    {
                                        if (diskPartition.Name.Equals(partitionNameWithLink, StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            done = true;

                                            IFileSystem? fileSystemData = diskPartition.FileSystem;

                                            if (fileSystemData == null)
                                            {
                                                break;
                                            }

                                            bool needsDecompression = packageFile.FileType.Contains("registry", StringComparison.CurrentCultureIgnoreCase) || packageFile.FileType.Contains("policy", StringComparison.CurrentCultureIgnoreCase) || packageFile.FileType.Contains("manifest", StringComparison.CurrentCultureIgnoreCase);
                                            bool doesNotNeedDecompression = packageFile.FileType.Contains("catalog", StringComparison.CurrentCultureIgnoreCase) || packageFile.FileType.Contains("regular", StringComparison.CurrentCultureIgnoreCase);

                                            if (needsDecompression)
                                            {
                                                Stream cabFileStream = null;

                                                try
                                                {
                                                    cabFileStream = fileSystemData.OpenFileAndDecompressAsGZip(normalized[5..]);
                                                }
                                                catch (InvalidDataException)
                                                {
                                                    cabFileStream = fileSystemData.OpenFile(normalized[5..], FileMode.Open, FileAccess.Read);
                                                }

                                                cabinetFileInfo = new CabinetFileInfo()
                                                {
                                                    FileName = packageFile.CabPath,
                                                    FileStream = cabFileStream,
                                                    Attributes = fileSystemData.GetAttributes(normalized[5..]) & ~FileAttributes.ReparsePoint,
                                                    DateTime = fileSystemData.GetLastWriteTime(normalized[5..])
                                                };
                                            }
                                            else if (doesNotNeedDecompression)
                                            {
                                                cabinetFileInfo = new CabinetFileInfo()
                                                {
                                                    FileName = packageFile.CabPath,
                                                    FileStream = fileSystemData.OpenFile(normalized[5..], FileMode.Open, FileAccess.Read),
                                                    Attributes = fileSystemData.GetAttributes(normalized[5..]) & ~FileAttributes.ReparsePoint,
                                                    DateTime = fileSystemData.GetLastWriteTime(normalized[5..])
                                                };
                                            }
                                            else
                                            {
                                                cabinetFileInfo = new CabinetFileInfo()
                                                {
                                                    FileName = packageFile.CabPath,
                                                    FileStream = fileSystemData.OpenFile(normalized[5..], FileMode.Open, FileAccess.Read),
                                                    Attributes = fileSystemData.GetAttributes(normalized[5..]) & ~FileAttributes.ReparsePoint,
                                                    DateTime = fileSystemData.GetLastWriteTime(normalized[5..])
                                                };
                                            }

                                            break;
                                        }
                                    }

                                    if (done)
                                    {
                                        break;
                                    }
                                }

                                break;
                            }
                        }
                    }
                    else
                    {
                        bool needsDecompression = packageFile.FileType.Contains("registry", StringComparison.CurrentCultureIgnoreCase) || packageFile.FileType.Contains("policy", StringComparison.CurrentCultureIgnoreCase) || packageFile.FileType.Contains("manifest", StringComparison.CurrentCultureIgnoreCase);
                        bool doesNotNeedDecompression = packageFile.FileType.Contains("catalog", StringComparison.CurrentCultureIgnoreCase) || packageFile.FileType.Contains("regular", StringComparison.CurrentCultureIgnoreCase);

                        if (needsDecompression)
                        {
                            Stream? cabFileStream = null;

                            try
                            {
                                cabFileStream = fileSystem.OpenFileAndDecompressAsGZip(normalized);
                            }
                            catch (InvalidDataException)
                            {
                                cabFileStream = fileSystem.OpenFile(normalized, FileMode.Open, FileAccess.Read);
                            }

                            cabinetFileInfo = new CabinetFileInfo()
                            {
                                FileName = packageFile.CabPath,
                                FileStream = cabFileStream,
                                Attributes = fileSystem.GetAttributes(normalized) & ~FileAttributes.ReparsePoint,
                                DateTime = fileSystem.GetLastWriteTime(normalized)
                            };
                        }
                        else if (doesNotNeedDecompression)
                        {
                            cabinetFileInfo = new CabinetFileInfo()
                            {
                                FileName = packageFile.CabPath,
                                FileStream = fileSystem.OpenFile(normalized, FileMode.Open, FileAccess.Read),
                                Attributes = fileSystem.GetAttributes(normalized) & ~FileAttributes.ReparsePoint,
                                DateTime = fileSystem.GetLastWriteTime(normalized)
                            };
                        }
                        else
                        {
                            cabinetFileInfo = new CabinetFileInfo()
                            {
                                FileName = packageFile.CabPath,
                                FileStream = fileSystem.OpenFile(normalized, FileMode.Open, FileAccess.Read),
                                Attributes = fileSystem.GetAttributes(normalized) & ~FileAttributes.ReparsePoint,
                                DateTime = fileSystem.GetLastWriteTime(normalized)
                            };
                        }
                    }
                }

                if (cabinetFileInfo != null)
                {
                    fileMappings.Add(cabinetFileInfo);
                }
                else
                {
                    Console.WriteLine($"\rError: File not found! {normalized}\n");
                    //throw new FileNotFoundException(normalized);
                }
            }

            return fileMappings;
        }

        public static void BuildSPKG(List<IDisk> disks, string destination_path)
        {
            Console.WriteLine();
            Console.WriteLine("Found Disks:");
            Console.WriteLine();

            foreach (IDisk disk in disks)
            {
                foreach (IPartition partition in disk.Partitions)
                {
                    if (partition.FileSystem != null)
                    {
                        Console.WriteLine($"{partition.Name} {partition.ID} {partition.Type} {partition.Size} KnownFS");
                    }
                }
            }

            Console.WriteLine();

            foreach (IDisk disk in disks)
            {
                foreach (IPartition partition in disk.Partitions)
                {
                    if (partition.FileSystem == null)
                    {
                        Console.WriteLine($"{partition.Name} {partition.ID} {partition.Type} {partition.Size} UnknownFS");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Building SPKG Cabinet Files...");
            Console.WriteLine();

            BuildCabinets(disks, destination_path);

            Console.WriteLine();
            Console.WriteLine("Cleaning up...");
            Console.WriteLine();

            TempManager.CleanupTempFiles();

            Console.WriteLine("The operation completed successfully.");
        }

        private static List<IPartition> GetPartitionsWithServicing(List<IDisk> disks)
        {
            List<IPartition> fileSystemsWithServicing = [];

            foreach (IDisk disk in disks)
            {
                foreach (IPartition partition in disk.Partitions)
                {
                    IFileSystem? fileSystem = partition.FileSystem;

                    if (fileSystem != null)
                    {
                        try
                        {
                            if (fileSystem.DirectoryExists(@"Windows\Packages\DsmFiles"))
                            {
                                fileSystemsWithServicing.Add(partition);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }

            return fileSystemsWithServicing;
        }

        private static int GetPackageCount(List<IDisk> disks)
        {
            int count = 0;

            List<IPartition> partitionsWithCbsServicing = GetPartitionsWithServicing(disks);

            foreach (IPartition partition in partitionsWithCbsServicing)
            {
                IFileSystem? fileSystem = partition.FileSystem;

                IEnumerable<string> manifestFiles = fileSystem.GetFiles(@"Windows\Packages\DsmFiles", "*.xml", SearchOption.TopDirectoryOnly);

                count += manifestFiles.Count();
            }

            return count;
        }

        private static void BuildCabinets(List<IDisk> disks, string outputPath)
        {
            int packagesCount = GetPackageCount(disks);

            List<IPartition> partitionsWithCbsServicing = GetPartitionsWithServicing(disks);
            int i = 0;

            foreach (IPartition partition in partitionsWithCbsServicing)
            {
                IFileSystem fileSystem = partition.FileSystem;

                IEnumerable<string> manifestFiles = fileSystem.GetFiles(@"Windows\Packages\DsmFiles", "*.xml", SearchOption.TopDirectoryOnly);

                foreach (string manifestFile in manifestFiles)
                {
                    try
                    {
                        XmlDsm.Package dsm = null;

                        try
                        {
                            using Stream stream = fileSystem.OpenFileAndDecompressAsGZip(manifestFile);
                            XmlSerializer serializer = new(typeof(XmlDsm.Package));
                            dsm = (XmlDsm.Package)serializer.Deserialize(stream);
                        }
                        catch (InvalidDataException)
                        {
                            using Stream stream = fileSystem.OpenFile(manifestFile, FileMode.Open, FileAccess.Read);
                            XmlSerializer serializer = new(typeof(XmlDsm.Package));
                            dsm = (XmlDsm.Package)serializer.Deserialize(stream);
                        }

                        string packageName = GetSPKGComponentName(dsm);

                        string cabFileName = Path.Combine(partition.Name, packageName);

                        string cabFile = Path.Combine(outputPath, $"{cabFileName}.spkg");
                        if (Path.GetDirectoryName(cabFile) is string directory && !Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        string componentStatus = $"Creating package {i + 1} of {packagesCount} - {cabFileName}";
                        if (componentStatus.Length > Console.BufferWidth - 1)
                        {
                            componentStatus = $"{componentStatus[..(Console.BufferWidth - 4)]}...";
                        }

                        Console.WriteLine(componentStatus);

                        string fileStatus = "";

                        if (!File.Exists(cabFile))
                        {
                            List<CabinetFileInfo> fileMappings = GetCabinetFileInfoForDsmPackage(dsm, partition, disks);

                            uint oldPercentage = uint.MaxValue;
                            uint oldFilePercentage = uint.MaxValue;
                            string oldFileName = "";

                            CabInfo cab = new(cabFile);
                            cab.PackFiles(null, fileMappings.Select(x => x.GetFileTuple()).ToArray(), fileMappings.Select(x => x.FileName).ToArray(), CompressionLevel.Min, (object _, ArchiveProgressEventArgs archiveProgressEventArgs) =>
                            {
                                uint percentage = (uint)Math.Floor((double)archiveProgressEventArgs.CurrentFileNumber * 50 / archiveProgressEventArgs.TotalFiles) + 50;

                                if (percentage != oldPercentage)
                                {
                                    oldPercentage = percentage;
                                    string progressBarString = GetDISMLikeProgressBar(percentage);
                                    Console.Write($"\r{progressBarString}");
                                }

                                if (archiveProgressEventArgs.CurrentFileName != oldFileName)
                                {
                                    Console.Write($"\n{new string(' ', fileStatus.Length)}\n{GetDISMLikeProgressBar(0)}");
                                    Console.SetCursorPosition(0, Console.CursorTop - 2);

                                    oldFileName = archiveProgressEventArgs.CurrentFileName;
                                    oldFilePercentage = uint.MaxValue;

                                    fileStatus = $"Adding file {archiveProgressEventArgs.CurrentFileNumber + 1} of {archiveProgressEventArgs.TotalFiles} - {archiveProgressEventArgs.CurrentFileName}";
                                    if (fileStatus.Length > Console.BufferWidth - 1)
                                    {
                                        fileStatus = $"{fileStatus[..(Console.BufferWidth - 4)]}...";
                                    }

                                    Console.Write($"\n{fileStatus}\n{GetDISMLikeProgressBar(0)}");
                                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                                }

                                uint filePercentage = (uint)Math.Floor((double)archiveProgressEventArgs.CurrentFileBytesProcessed * 100 / archiveProgressEventArgs.CurrentFileTotalBytes);

                                if (filePercentage != oldFilePercentage)
                                {
                                    oldFilePercentage = filePercentage;
                                    string progressBarString = GetDISMLikeProgressBar(filePercentage);
                                    Console.Write($"\n\n{progressBarString}");

                                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                                }
                            });

                            foreach (CabinetFileInfo fileMapping in fileMappings)
                            {
                                fileMapping.FileStream.Close();
                            }
                        }

                        if (i != packagesCount - 1)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine($"{new string(' ', componentStatus.Length)}\n{GetDISMLikeProgressBar(100)}");

                            if (string.IsNullOrEmpty(fileStatus))
                            {
                                Console.WriteLine($"{new string(' ', fileStatus.Length)}\n{new string(' ', 60)}");
                            }
                            else
                            {
                                Console.WriteLine($"{new string(' ', fileStatus.Length)}\n{GetDISMLikeProgressBar(100)}");
                            }

                            Console.SetCursorPosition(0, Console.CursorTop - 4);
                        }
                        else
                        {
                            Console.WriteLine($"\r{GetDISMLikeProgressBar(100)}");

                            if (string.IsNullOrEmpty(fileStatus))
                            {
                                Console.WriteLine($"\n{new string(' ', 60)}");
                            }
                            else
                            {
                                Console.WriteLine($"\n{GetDISMLikeProgressBar(100)}");
                            }
                        }

                        i++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: CAB creation failed! {ex.Message}");
                        //throw;
                    }
                }
            }
        }

        private static string GetDISMLikeProgressBar(uint percentage)
        {
            if (percentage > 100)
            {
                percentage = 100;
            }

            int eqsLength = (int)Math.Floor((double)percentage * 55u / 100u);

            string bases = $"{new string('=', eqsLength)}{new string(' ', 55 - eqsLength)}";

            bases = bases.Insert(28, percentage + "%");

            if (percentage == 100)
            {
                bases = bases[1..];
            }
            else if (percentage < 10)
            {
                bases = bases.Insert(28, " ");
            }

            return $"[{bases}]";
        }
    }
}
