﻿using MobilePackageGen;
using MobilePackageGen.Adapters;
using MobilePackageGen.Adapters.Wim;

namespace ToCBS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(@"
Image To Component Based Servicing Cabinets tool
Version: 1.0.2.0
");

            if (args.Length < 2)
            {
                Console.WriteLine("Remember to run the tool as Trusted Installer (TI).");
                Console.WriteLine("You need to pass 2 parameters:");
                Console.WriteLine(@"	<Path to WIM File> <Output folder CBSs>");
                Console.WriteLine("Example:");
                Console.WriteLine(@"	 ""D:\Flash.wim"" ""C:\OutputCabs\""");
                return;
            }

            Console.WriteLine("Getting Disks...");

            List<IDisk> disks = GetDisks(args[0]);

            Console.WriteLine("Getting Update OS Disks...");

            disks.AddRange(DiskCommon.GetUpdateOSDisks(disks));

            CBSBuilder.BuildCBS(disks, args[1]);
        }

        private static List<IDisk> GetDisks(string wimPath)
        {
            List<IDisk> disks =
            [
                new Disk(wimPath)
            ];

            return disks;
        }
    }
}
