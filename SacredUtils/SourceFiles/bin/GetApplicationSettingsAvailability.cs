using System.IO;
using Config.Net;
using SacredUtils.resources.bin;

namespace SacredUtils.SourceFiles.bin
{
    public static class GetApplicationSettingsAvailability
    {
        public static void Get()
        {
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
