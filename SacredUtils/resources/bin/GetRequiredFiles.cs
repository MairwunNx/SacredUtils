using System.IO;
using Config.Net;

namespace SacredUtils.resources.bin
{
    public interface IReqiredFilesSettings
    {
        int ConfigVersion { get; set; }
        bool DebugFileCreate { get; set; }
        bool LicenseFileCreate { get; set; }
    }

    public class GetRequiredFiles
    {
        private bool _debugFileCreate;
        private bool _licenseFileCreate;
        
        public void Get()
        {
            GetLoggerConfig.Log.Info("Checking availability reqiredfiles settings");

            if (!File.Exists("$SacredUtils\\conf\\reqiredfiles.json"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\reqiredfiles.json", Properties.Resources.reqiredfiles);

                GetLoggerConfig.Log.Info("Reqiredfiles settings were created in conf folder");

                File.WriteAllBytes("License.txt", Properties.Resources.license);

                GetLoggerConfig.Log.Info("License file were created in this folder");
            }
            else
            {
                IReqiredFilesSettings reqiredFilesSettings = new ConfigurationBuilder<IReqiredFilesSettings>()
                    .UseJsonFile("$SacredUtils\\conf\\reqiredfiles.json").Build();

                GetLoggerConfig.Log.Info("Checking Reqiredfiles config version");

                if (reqiredFilesSettings.ConfigVersion < 1)
                {
                    GetLoggerConfig.Log.Warn("Reqiredfiles configuration is outdated!");

                    _debugFileCreate = reqiredFilesSettings.DebugFileCreate;

                    _licenseFileCreate = reqiredFilesSettings.LicenseFileCreate;

                    File.WriteAllBytes("$SacredUtils\\conf\\reqiredfiles.json", Properties.Resources.reqiredfiles);

                    IReqiredFilesSettings reqiredFilesSettingsRepair = new ConfigurationBuilder<IReqiredFilesSettings>()
                        .UseJsonFile("$SacredUtils\\conf\\reqiredfiles.json").Build();

                    reqiredFilesSettingsRepair.DebugFileCreate = _debugFileCreate;

                    reqiredFilesSettingsRepair.LicenseFileCreate = _licenseFileCreate;

                    GetLoggerConfig.Log.Info("Reqiredfiles configuration has been updated");

                    GetLoggerConfig.Log.Info("Check permission to create debug file");

                    if (reqiredFilesSettingsRepair.DebugFileCreate)
                    {
                        File.WriteAllBytes("SacredUtils.pdb", Properties.Resources.SacredUtils);

                        GetLoggerConfig.Log.Info("Debug file were created in this folder");
                    }
                    else
                    {
                        GetLoggerConfig.Log.Info("No permission to create debug file");
                    }

                    GetLoggerConfig.Log.Info("Check permission to create license file");

                    if (reqiredFilesSettingsRepair.LicenseFileCreate)
                    {
                        File.WriteAllBytes("License.txt", Properties.Resources.license);

                        GetLoggerConfig.Log.Info("License file were created in this folder");
                    }
                    else
                    {
                        GetLoggerConfig.Log.Info("No permission to create license file");
                    }
                }
                else
                {
                    GetLoggerConfig.Log.Info("Reqiredfiles configuration undamaged!");

                    IReqiredFilesSettings reqiredFilesSettingsUpdated = new ConfigurationBuilder<IReqiredFilesSettings>()
                        .UseJsonFile("$SacredUtils\\conf\\reqiredfiles.json").Build();

                    GetLoggerConfig.Log.Info("Check permission to create debug file");

                    if (reqiredFilesSettingsUpdated.DebugFileCreate)
                    {
                        File.WriteAllBytes("SacredUtils.pdb", Properties.Resources.SacredUtils);

                        GetLoggerConfig.Log.Info("Debug file were created in this folder");
                    }
                    else
                    {
                        GetLoggerConfig.Log.Info("No permission to create debug file");
                    }

                    GetLoggerConfig.Log.Info("Check permission to create license file");

                    if (reqiredFilesSettingsUpdated.LicenseFileCreate)
                    {
                        File.WriteAllBytes("License.txt", Properties.Resources.license);

                        GetLoggerConfig.Log.Info("License file were created in this folder");
                    }
                    else
                    {
                        GetLoggerConfig.Log.Info("No permission to create license file");
                    }
                }
            }
        }
    }
}
