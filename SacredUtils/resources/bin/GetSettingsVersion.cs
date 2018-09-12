using Config.Net;
using System;
using System.IO;

namespace SacredUtils.resources.bin
{
    public class GetSettingsVersion
    {
        private int _trynum;
        private bool _acceptLicense;
        private bool _allowExperimentalScale;
        private bool _checkAutoAlphaUpdate;
        private bool _checkAutoUpdate;
        private string _colorTheme;
        private bool _debugFileCreate;
        private bool _disableFootSteps;
        private bool _disableLogging;
        private bool _disableTelemetry;
        private bool _enableHealthCircles;
        private bool _gameVoiceover;
        private bool _licenseFileCreate;
        private bool _makeAutoBackupConfigs;
        private bool _nLogConfigFileCreate;
        private bool _removeTempContent;
        private string _sacredStartArgs;
        private double _sacredUtilsGuiScale;
        private bool _showChangeLog;
        private bool _useOldButtonTextures;
        private bool _useOldMenuTextures;
        private bool _useOldSlotsTextures;
        private bool _useStaticBog;
        private bool _useStaticLava;
        private bool _useStaticWater;
        
        public interface IApplicationSettings
        {
            int ConfigVersion { get; }
            bool AcceptLicense { get; set; }
            bool AllowExperimentalScale { get; set; }
            bool CheckAutoAlphaUpdate { get; set; }
            bool CheckAutoUpdate { get; set; }
            string ColorTheme { get; set; }
            bool DebugFileCreate { get; set; }
            bool DisableFootSteps { get; set; }
            bool DisableLogging { get; set; }
            bool DisableTelemetry { get; set; }
            bool EnableHealthCircles { get; set; }
            bool GameVoiceover { get; set; }
            bool LicenseFileCreate { get; set; }
            bool MakeAutoBackupConfigs { get; set; }
            bool NLogConfigFileCreate { get; set; }
            bool RemoveTempContent { get; set; }
            string SacredStartArgs { get; set; }
            double SacredUtilsGuiScale { get; set; }
            bool ShowChangeLog { get; set; }
            bool UseOldButtonTextures { get; set; }
            bool UseOldMenuTextures { get; set; }
            bool UseOldSlotsTextures { get; set; }
            bool UseStaticBog { get; set; }
            bool UseStaticLava { get; set; }
            bool UseStaticWater { get; set; }
        }

        public void Get()
        {
            GetLoggerConfig.Log.Info("Checking availability application settings ...");

            if (!File.Exists("$SacredUtils\\conf\\settings.json"))
            {
                while (_trynum < 10)
                {
                    try
                    {
                        GetLoggerConfig.Log.Info("Creating application settings file in this folder ...");

                        File.WriteAllBytes("$SacredUtils\\conf\\settings.json", Properties.Resources.settings);

                        GetLoggerConfig.Log.Info("Creating application settings file in this folder done!");

                        _trynum = 10;
                    }
                    catch (Exception exception)
                    {
                        if (_trynum == 10)
                        {
                            GetLoggerConfig.Log.Fatal(exception.ToString);
                            GetLoggerConfig.Log.Fatal("Creating application settings file in this folder done with critical error!");
                            GetLoggerConfig.Log.Fatal("Please contact MairwunNx, MairwunNx@gmail.com. May be it our problem. Sorry.");

                            GetLoggerConfig.Log.Info("Shutting down SacredUtils configurator ...");

                            Environment.Exit(0);
                        }

                        _trynum = + 1;

                        GetLoggerConfig.Log.Fatal(exception.ToString);
                        GetLoggerConfig.Log.Fatal("Creating application settings file in this folder done with critical error!");
                        GetLoggerConfig.Log.Warn($"We try fix it problem or try again, attemp {_trynum} ...");
                    }
                }
            }
            else
            {
                GetLoggerConfig.Log.Info("Checking availability application settings done!");
            }

            GetLoggerConfig.Log.Info("Checking application settings config version ...");

            IApplicationSettings applicationSettings = new ConfigurationBuilder<IApplicationSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (applicationSettings.ConfigVersion < 1)
            {
                GetLoggerConfig.Log.Warn("Application settings configuration is out of date!");

                _acceptLicense = applicationSettings.AcceptLicense;

                _allowExperimentalScale = applicationSettings.AllowExperimentalScale;

                _checkAutoAlphaUpdate = applicationSettings.CheckAutoAlphaUpdate;

                _checkAutoUpdate = applicationSettings.CheckAutoUpdate;

                _colorTheme = applicationSettings.ColorTheme;

                _debugFileCreate = applicationSettings.DebugFileCreate;

                _disableFootSteps = applicationSettings.DisableFootSteps;

                _disableLogging = applicationSettings.DisableLogging;

                _disableTelemetry = applicationSettings.DisableTelemetry;

                _acceptLicense = applicationSettings.AcceptLicense;

                _enableHealthCircles = applicationSettings.EnableHealthCircles;

                _gameVoiceover = applicationSettings.GameVoiceover;

                _licenseFileCreate = applicationSettings.LicenseFileCreate;

                _makeAutoBackupConfigs = applicationSettings.MakeAutoBackupConfigs;

                _nLogConfigFileCreate = applicationSettings.NLogConfigFileCreate;

                _removeTempContent = applicationSettings.RemoveTempContent;

                _sacredStartArgs = applicationSettings.SacredStartArgs;

                _sacredUtilsGuiScale = applicationSettings.SacredUtilsGuiScale;

                _showChangeLog = applicationSettings.ShowChangeLog;

                _useOldButtonTextures = applicationSettings.UseOldButtonTextures;

                _useOldMenuTextures = applicationSettings.UseOldMenuTextures;

                _useOldSlotsTextures = applicationSettings.UseOldSlotsTextures;

                _useStaticBog = applicationSettings.UseStaticBog;

                _useStaticLava = applicationSettings.UseStaticLava;

                _useStaticWater = applicationSettings.UseStaticWater;

                File.WriteAllBytes("$SacredUtils\\conf\\settings.json", Properties.Resources.settings);

                IApplicationSettings reqiredFilesSettingsRepair = new ConfigurationBuilder<IApplicationSettings>()
                    .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                reqiredFilesSettingsRepair.AcceptLicense = _acceptLicense;

                reqiredFilesSettingsRepair.AllowExperimentalScale = _allowExperimentalScale;

                reqiredFilesSettingsRepair.CheckAutoAlphaUpdate = _checkAutoAlphaUpdate;

                reqiredFilesSettingsRepair.CheckAutoUpdate = _checkAutoUpdate;

                reqiredFilesSettingsRepair.ColorTheme = _colorTheme;

                reqiredFilesSettingsRepair.DebugFileCreate = _debugFileCreate;

                reqiredFilesSettingsRepair.DisableFootSteps = _disableFootSteps;

                reqiredFilesSettingsRepair.DisableLogging = _disableLogging;

                reqiredFilesSettingsRepair.DisableTelemetry = _disableTelemetry;

                reqiredFilesSettingsRepair.AcceptLicense = _acceptLicense;

                reqiredFilesSettingsRepair.EnableHealthCircles = _enableHealthCircles;

                reqiredFilesSettingsRepair.GameVoiceover = _gameVoiceover;

                reqiredFilesSettingsRepair.LicenseFileCreate = _licenseFileCreate;

                reqiredFilesSettingsRepair.MakeAutoBackupConfigs = _makeAutoBackupConfigs;

                reqiredFilesSettingsRepair.NLogConfigFileCreate = _nLogConfigFileCreate;

                reqiredFilesSettingsRepair.RemoveTempContent = _removeTempContent;

                reqiredFilesSettingsRepair.SacredStartArgs = _sacredStartArgs;

                reqiredFilesSettingsRepair.SacredUtilsGuiScale = _sacredUtilsGuiScale;

                reqiredFilesSettingsRepair.ShowChangeLog = _showChangeLog;

                reqiredFilesSettingsRepair.UseOldButtonTextures = _useOldButtonTextures;

                reqiredFilesSettingsRepair.UseOldMenuTextures = _useOldMenuTextures;

                reqiredFilesSettingsRepair.UseOldSlotsTextures = _useOldSlotsTextures;

                reqiredFilesSettingsRepair.UseStaticBog = _useStaticBog;

                reqiredFilesSettingsRepair.UseStaticLava = _useStaticLava;

                reqiredFilesSettingsRepair.UseStaticWater = _useStaticWater;

                GetLoggerConfig.Log.Info("Application settings configuration has been updated!");
            }
            else
            {
                GetLoggerConfig.Log.Info("Application settings configuration undamaged!");
            }
        }
    }
}
