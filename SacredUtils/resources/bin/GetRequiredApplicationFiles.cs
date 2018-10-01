using Config.Net;
using System.IO;

namespace SacredUtils.resources.bin
{
    public static class GetRequiredApplicationFiles
    {
        public static void Get()
        {
            IAppSettings applicationSettings =
                new ConfigurationBuilder<IAppSettings>()
                    .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (applicationSettings.DebugFileCreate)
            {
                File.WriteAllBytes("SacredUtils.pdb", Properties.Resources.SacredUtils);

                AppLogger.Log.Info("Debug file were created in this folder");
            }
            else
            {
                AppLogger.Log.Info("No permission to create debug file!");
            }

            if (applicationSettings.LicenseFileCreate)
            {
                File.WriteAllBytes("License.txt", Properties.Resources.AppLicense);

                AppLogger.Log.Info("License file were created in this folder");
            }
            else
            {
                AppLogger.Log.Info("No permission to create license file!");
            }
        }
    }
}
