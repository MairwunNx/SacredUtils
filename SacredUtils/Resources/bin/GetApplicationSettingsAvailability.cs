using Config.Net;
using System.IO;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationSettingsAvailability
    {
        public static void Get()
        {
            CreateApplicationNeededFolders.Create();

            if (File.Exists("$SacredUtils\\conf\\settings.json") &&
                !File.ReadAllText("$SacredUtils\\conf\\settings.json")
                    .Contains("AcceptLicense"))
                return;

            File.WriteAllBytes("$SacredUtils\\conf\\settings.json", Properties.Resources.settings);
            AppSettings.ApplicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();
        }
    }
}
