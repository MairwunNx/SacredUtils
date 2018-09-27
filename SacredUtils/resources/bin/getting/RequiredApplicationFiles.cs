using Config.Net;
using SacredUtils.resources.bin.logger;
using System.IO;

namespace SacredUtils.resources.bin.getting
{
    public static class RequiredApplicationFiles
    {
        public static void Get()
        {
            ApplicationSettings.IApplicationSettings applicationSettings = new ConfigurationBuilder<ApplicationSettings.IApplicationSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (applicationSettings.DebugFileCreate)
            {
                File.WriteAllBytes("SacredUtils.pdb", Properties.Resources.SacredUtils);

                Logger.Log.Info("Debug file were created in this folder");
            }
            else
            {
                Logger.Log.Info("No permission to create debug file!");
            }

            if (applicationSettings.LicenseFileCreate)
            {
                File.WriteAllBytes("License.txt", Properties.Resources.license);

                Logger.Log.Info("License file were created in this folder");
            }
            else
            {
                Logger.Log.Info("No permission to create license file!");
            }

            if (applicationSettings.ConfigFileCreate)
            {
                File.WriteAllBytes("SacredUtils.exe.config", Properties.Resources.application);

                Logger.Log.Info("AppConfig file were created in this folder");
            }
            else
            {
                Logger.Log.Info("No permission to create AppConfig file!");
            }
        }
    }
}
