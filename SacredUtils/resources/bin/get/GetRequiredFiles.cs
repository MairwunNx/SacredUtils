using Config.Net;
using System.IO;

namespace SacredUtils.resources.bin.get
{
    public interface IReqiredFilesSettings
    {
        bool DebugFileCreate { get; }
        bool LicenseFileCreate { get; }
        bool ConfigFileCreate { get; }
    }

    public static class GetRequiredFiles
    {
        public static void Get()
        {
            IReqiredFilesSettings reqiredFilesSettings = new ConfigurationBuilder<IReqiredFilesSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            GetLoggerConfig.Log.Info("Checking permission to create debug file ...");

            if (reqiredFilesSettings.DebugFileCreate)
            {
                File.WriteAllBytes("SacredUtils.pdb", Properties.Resources.SacredUtils);

                GetLoggerConfig.Log.Info("Debug file were created in this folder");
            }
            else
            {
                GetLoggerConfig.Log.Info("No permission to create debug file!");
            }

            GetLoggerConfig.Log.Info("Checking permission to create license file");

            if (reqiredFilesSettings.LicenseFileCreate)
            {
                File.WriteAllBytes("License.txt", Properties.Resources.license);

                GetLoggerConfig.Log.Info("License file were created in this folder");
            }
            else
            {
                GetLoggerConfig.Log.Info("No permission to create license file!");
            }

            GetLoggerConfig.Log.Info("Checking permission to create AppConfig file");

            if (reqiredFilesSettings.ConfigFileCreate)
            {
                File.WriteAllBytes("SacredUtils.exe.config", Properties.Resources.application);

                GetLoggerConfig.Log.Info("AppConfig file were created in this folder");
            }
            else
            {
                GetLoggerConfig.Log.Info("No permission to create AppConfig file!");
            }
        }
    }
}
