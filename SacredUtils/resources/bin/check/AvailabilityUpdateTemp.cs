using Config.Net;
using SacredUtils.resources.bin.getting;
using System.IO;

namespace SacredUtils.resources.bin.check
{
    public static class AvailabilityUpdateTemp
    {
        public static void Get()
        {
            ApplicationSettings.IApplicationSettings applicationSettings = new ConfigurationBuilder<ApplicationSettings.IApplicationSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (applicationSettings.RemoveTempContent)
            {
                if (File.Exists("mnxupdater.exe"))
                {
                    File.Delete("mnxupdater.exe");
                }

                if (File.Exists("_newVersionSacredUtilsTemp.exe"))
                {
                    File.Delete("_newVersionSacredUtilsTemp.exe");
                }

                if (File.Exists("updater-crash-report.log"))
                {
                    File.Delete("updater-crash-report.log");
                }
            }
        }
    }
}
