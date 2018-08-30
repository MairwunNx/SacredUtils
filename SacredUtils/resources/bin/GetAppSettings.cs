using Config.Net;
using System.IO;

namespace SacredUtils.resources.bin
{
    public interface IApplicationSettings
    {
        int ConfigVersion { get; set; }
        bool CheckAutoUpdate { get; set; }
        bool CheckAutoAlphaUpdate { get; set; }
        bool MakeAutoBackupConf { get; set; }
        bool ShowChangeLog { get; set; }
        string ColorTheme { get; set; }
        string SacredStartArgs { get; set; }
        double GuiScale { get; set; }
    }

    public class GetAppSettings
    {
        public bool CheckAutoUpdate;
        public bool CheckAutoAlphaUpdate;
        public bool MakeAutoBackupConf;
        public bool ShowChangeLog;
        public string ColorTheme;
        public string SacredStartArgs;
        public double GuiScale;

        public void Get()
        {
            GetLoggerConfig.Log.Info("Checking availability application settings");

            if (!File.Exists("$SacredUtils\\conf\\settings.json"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\settings.json", Properties.Resources.settings);

                GetLoggerConfig.Log.Info("Application settings were created in conf folder");
            }
            else
            {
                IApplicationSettings applicationSettings = new ConfigurationBuilder<IApplicationSettings>()
                    .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                GetLoggerConfig.Log.Info("Checking application settings config version");

                if (applicationSettings.ConfigVersion < 1)
                {
                    GetLoggerConfig.Log.Warn("Application settings configuration is outdated!");

                    CheckAutoUpdate      = applicationSettings.CheckAutoUpdate;
                    CheckAutoAlphaUpdate = applicationSettings.CheckAutoAlphaUpdate;
                    MakeAutoBackupConf   = applicationSettings.MakeAutoBackupConf;
                    ShowChangeLog        = applicationSettings.ShowChangeLog;
                    ColorTheme           = applicationSettings.ColorTheme;
                    SacredStartArgs      = applicationSettings.SacredStartArgs;
                    GuiScale             = applicationSettings.GuiScale;

                    File.WriteAllBytes("$SacredUtils\\conf\\settings.json", Properties.Resources.settings);

                    IApplicationSettings applicationSettingsRepair = new ConfigurationBuilder<IApplicationSettings>()
                        .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                    applicationSettingsRepair.CheckAutoUpdate      = CheckAutoUpdate;
                    applicationSettingsRepair.CheckAutoAlphaUpdate = CheckAutoAlphaUpdate;
                    applicationSettingsRepair.MakeAutoBackupConf   = MakeAutoBackupConf;
                    applicationSettingsRepair.ShowChangeLog        = ShowChangeLog;
                    applicationSettingsRepair.ColorTheme           = ColorTheme;
                    applicationSettingsRepair.SacredStartArgs      = SacredStartArgs;
                    applicationSettingsRepair.GuiScale             = GuiScale;

                    GetLoggerConfig.Log.Info("Application settings configuration has been updated");
                }
                else
                {
                    GetLoggerConfig.Log.Info("Application settings configuration undamaged!");
                }
            }
        }
    }
}
