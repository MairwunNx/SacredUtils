using System.Diagnostics;
using System.IO;

namespace SacredUtils.resources.bin
{
    public static class ApplicationStartUtilityUpdate
    {
        public static void Start()
        {
            Directory.CreateDirectory("$SacredUtils\\temp");
            File.Create("$SacredUtils\\temp\\updated.su");
            Process.Start("mnxupdater.exe", AppInfo.CurrentExe + " _newVersionSacredUtilsTemp.exe");
            ApplicationBaseWindowShutdown.Shutdown();
        }
    }
}
