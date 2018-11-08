using System.IO;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityUpdateTemp
    {
        public static void Get()
        {
            if (AppSettings.ApplicationSettings.RemoveApplicationTempContent)
            {
                if (File.Exists("mnxupdater.exe")) { File.Delete("mnxupdater.exe"); }

                if (File.Exists("_newVersionSacredUtilsTemp.exe")) { File.Delete("_newVersionSacredUtilsTemp.exe"); }

                if (File.Exists("updater-crash-report.log")) { File.Delete("updater-crash-report.log"); }
            }
        }
    }
}
