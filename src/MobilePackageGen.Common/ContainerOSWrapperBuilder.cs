namespace MobilePackageGen
{
    public class ContainerOSWrapperBuilder
    {
        public static bool IsWrapperPackage(XmlMum.Assembly cbs)
        {
            return cbs.AssemblyIdentity.Name.EndsWith("-Wrapper-Package") &&
                                        cbs.Package.Identifier.EndsWith("-Wrapper-Package") &&
                                        cbs.Package.PreProcessed?.Equals("True") == true &&
                                        cbs.Package.ApplyTo != null;
        }

        public static void BuildWrapper(string cabFile, IEnumerable<CabinetFileInfo> fileMappings, ref string fileStatus, IPartition partition, string applyTo)
        {
            uint oldPercentage = uint.MaxValue;
            uint oldFilePercentage = uint.MaxValue;
            string oldFileName = "";

            string lambdaFileStatus = fileStatus;

            IEnumerable<string> fsDirectories = partition.FileSystem!.GetDirectories($"Windows{applyTo}", "*", SearchOption.AllDirectories);
            IEnumerable<string> fsFiles = partition.FileSystem!.GetFiles($"Windows{applyTo}", "*", SearchOption.AllDirectories);

            //Console.WriteLine("Build Wrapper called!");

            fileStatus = lambdaFileStatus;
        }
    }
}
