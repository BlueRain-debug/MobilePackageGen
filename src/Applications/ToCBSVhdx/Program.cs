﻿namespace ToCBS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(@"
Image To Component Based Servicing Cabinets tool
Version: 1.0.0.0
");

            if (args.Length < 2)
            {
                Console.WriteLine("Remember to run the tool as Trusted Installer (TI).");
                Console.WriteLine("You need to pass at least 2 parameters:");
                Console.WriteLine(@"	<Path to MainOS/Data/EFIESP> <Output folder CBSs>");
                Console.WriteLine("Examples:");
                Console.WriteLine(@"	 ""D:\LUN0.vhdx"" ""C:\OutputCabs\""");
                Console.WriteLine(@"	 ""D:\LUN0.vhdx"" ""D:\LUN1.vhdx"" ""D:\LUN2.vhdx"" ""C:\OutputCabs\""");
                return;
            }

            string[] vhds = args[..^1];
            if (vhds.Length == 1 && Directory.Exists(vhds[0]))
            {
                vhds = Directory.EnumerateFiles(vhds[0], "*.vhdx", SearchOption.TopDirectoryOnly).ToArray();
            }

            Console.WriteLine("Getting Disks...");

            List<Disk> disks = GetDisks(vhds);

            CBSBuilder.BuildCBS(disks, args[^1]);
        }

        private static List<Disk> GetDisks(string[] vhdxs)
        {
            List<Disk> disks = new();

            foreach (string vhdx in vhdxs)
            {
                disks.Add(new Disk(vhdx, 512)); // Hardcoded, todo
            }

            return disks;
        }
    }
}
