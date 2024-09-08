﻿using RawDiskLib;
using System.Text;

namespace ToCBS
{
    internal class DiskPartitionUtils
    {
        public static void ExtractFromDiskAndCopy(List<PartitionInfo> pTable, string partitionName, string destinationFile)
        {
            try
            {
                List<PartitionInfo> s = pTable.Where(p => p.PartitionName.ToUpper() == partitionName.ToUpper()).ToList();

                if (s.Count > 0)
                {
                    using RawDisk disk = new(DiskNumberType.PhysicalDisk, s[0].PhysicalNumber, FileAccess.Read);
                    byte[] partitionRaw = disk.ReadSectors(s[0].FirstLBA, s[0].LastLBA - s[0].FirstLBA);
                    string dirFromDest = Path.GetDirectoryName(destinationFile);
                    if (!Directory.Exists(dirFromDest))
                    {
                        _ = Directory.CreateDirectory(dirFromDest);
                    }
                    File.WriteAllBytes(destinationFile, partitionRaw);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Partition not found! " + partitionName);
                    Console.ResetColor();
                    throw new DriveNotFoundException();
                }
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + exception.Message);
                Console.ResetColor();
                throw;
            }
        }

        public static List<PartitionInfo> GetDiskDetail() //TODO: USE LETTER INSTEAD....
        {
            List<int> physicalDisks = Utils.GetAllAvailableDrives(DiskNumberType.PhysicalDisk).ToList();

            List<PartitionInfo> partition_tables = new();

            try
            {
                physicalDisks.ForEach(phy =>
                {
                    using RawDisk disk = new(DiskNumberType.PhysicalDisk, phy, FileAccess.Read);
                    if (disk.SectorCount < 34 * 2)
                    {
                        Console.WriteLine("Too low sector count: " + disk.SectorCount);
                        return;
                    }

                    byte[] GPT_header = disk.ReadSectors(0, 34 * 2);

                    //Remember all partitions.
                    partition_tables.AddRange(GetPartitionTables(GPT_header, disk.SectorSize, phy));
                });
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + exception.Message);
                Console.ResetColor();
                throw;
            }

            return partition_tables;
        }

        private static PartitionInfo[] GetPartitionTables(byte[] header, int sectorSize, int physicalNumber)
        {
            int offset = sectorSize * 2;
            bool finished = false;

            List<PartitionInfo> partitions = new();

            while (!finished && offset < (header.Length - (2 * sectorSize)))
            {
                byte[] sliced = SliceByteArray(header, 128, offset);
                offset += 128;

                PartitionInfo partition = new()
                {
                    PartitionType = new Guid(SliceByteArray(sliced, 16, 0)),
                    PartitionGuid = new Guid(SliceByteArray(sliced, 16, 16)),
                    FirstLBA = BitConverter.ToInt32(SliceByteArray(sliced, 8, 32).ToArray(), 0),
                    LastLBA = BitConverter.ToInt32(SliceByteArray(sliced, 8, 40).ToArray(), 0),
                    AttributeFlags = SliceByteArray(sliced, 8, 48),
                    PartitionName = Encoding.Unicode.GetString(SliceByteArray(sliced, 72, 56)).Replace("\0", ""),
                    PhysicalNumber = physicalNumber
                };

                if (partition.FirstLBA == 0 &&
                    partition.LastLBA == 0 &&
                    partition.PartitionGuid == Guid.Empty &&
                    partition.PartitionType == Guid.Empty)
                {
                    finished = true;
                }
                else
                {
                    partitions.Add(partition);
                }
            }

            return partitions.ToArray();
        }

        private static byte[] SliceByteArray(byte[] source, int length, int offset)
        {
            byte[] destinationFoo = new byte[length];
            Array.Copy(source, offset, destinationFoo, 0, length);
            return destinationFoo;
        }
    }
}