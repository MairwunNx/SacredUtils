using System.Diagnostics;
using System.IO;
using SacredUtils.SourceFiles;

namespace SacredUtils.resources.bin
{
    public static class ApplicationStartUtilityUpdate
    {
        public static void Start()
        {
            Directory.CreateDirectory("$SacredUtils\\temp");
            File.Create("$SacredUtils\\temp\\updated.su");
            Process.Start("mnxupdater.exe", ApplicationInfo.CurrentExe + " _newVersionSacredUtilsTemp.exe");
            ApplicationUtils.Shutdown();
        }
    }
}
