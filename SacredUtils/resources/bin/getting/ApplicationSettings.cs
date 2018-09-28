using SacredUtils.resources.bin.logger;
using System;
using System.IO;
using Config.Net;

namespace SacredUtils.resources.bin.getting
{
    public static class ApplicationSettings
    {
        public interface IApplicationSettings
        {
            [Option(Alias = "AcceptLicense", DefaultValue = "false")]
            bool AcceptLicense { get; set; }

            [Option(Alias = "AllowExperimentalScale", DefaultValue = "false")]
            bool AllowExperimentalScale { get; set; }

            [Option(Alias = "CheckAutoAlphaUpdate", DefaultValue = "false")]
            bool CheckAutoAlphaUpdate { get; set; }

            [Option(Alias = "CheckAutoUpdate", DefaultValue = "true")]
            bool CheckAutoUpdate { get; set; }

            [Option(Alias = "ColorTheme", DefaultValue = "light")]
            string ColorTheme { get; set; }

            [Option(Alias = "ConfigFileCreate", DefaultValue = "false")]
            bool ConfigFileCreate { get; set; }

            [Option(Alias = "DebugFileCreate", DefaultValue = "false")]
            bool DebugFileCreate { get; set; }

            [Option(Alias = "DisableFootSteps", DefaultValue = "false")]
            bool DisableFootSteps { get; set; }

            [Option(Alias = "DisableLogging", DefaultValue = "false")]
            bool DisableLogging { get; set; }

            [Option(Alias = "DisableTelemetry", DefaultValue = "false")]
            bool DisableTelemetry { get; set; }

            [Option(Alias = "EnableHealthCircles", DefaultValue = "false")]
            bool EnableHealthCircles { get; set; }

            [Option(Alias = "EnableHealthCircles", DefaultValue = "based on language")]
            string GameVoiceover { get; set; }

            [Option(Alias = "LicenseFileCreate", DefaultValue = "true")]
            bool LicenseFileCreate { get; set; }

            [Option(Alias = "MakeAutoBackupConfigs", DefaultValue = "true")]
            bool MakeAutoBackupConfigs { get; set; }

            [Option(Alias = "NLogConfigFileCreate", DefaultValue = "false")]
            bool NLogConfigFileCreate { get; set; }

            [Option(Alias = "RemoveTempContent", DefaultValue = "true")]
            bool RemoveTempContent { get; set; }

            [Option(Alias = "SacredStartArgs", DefaultValue = "minimize")]
            string SacredStartArgs { get; set; }

            [Option(Alias = "SacredUtilsGuiScale", DefaultValue = "1.0")]
            double SacredUtilsGuiScale { get; set; }

            [Option(Alias = "ShowChangeLog", DefaultValue = "true")]
            bool ShowChangeLog { get; set; }

            [Option(Alias = "ShowUsedMemory", DefaultValue = "false")]
            bool ShowUsedMemory { get; set; }

            [Option(Alias = "ShowUsedMemoryUpdateInterval", DefaultValue = "1")]
            int ShowUsedMemoryUpdateInterval { get; set; }

            [Option(Alias = "UseOldButtonTextures", DefaultValue = "false")]
            bool UseOldButtonTextures { get; set; }

            [Option(Alias = "UseOldMenuTextures", DefaultValue = "false")]
            bool UseOldMenuTextures { get; set; }

            [Option(Alias = "UseOldSlotsTextures", DefaultValue = "false")]
            bool UseOldSlotsTextures { get; set; }

            [Option(Alias = "UseStaticBog", DefaultValue = "false")]
            bool UseStaticBog { get; set; }

            [Option(Alias = "UseStaticLava", DefaultValue = "false")]
            bool UseStaticLava { get; set; }

            [Option(Alias = "UseStaticWater", DefaultValue = "false")]
            bool UseStaticWater { get; set; }
        }

        public static void Get()
        {
            Logger.Log.Info("Checking availability application settings ...");

            if (!File.Exists("$SacredUtils\\conf\\settings.json"))
            {
                try
                {
                    File.WriteAllBytes("$SacredUtils\\conf\\settings.json", Properties.Resources.settings);

                    Logger.Log.Info("Creating application settings file in this folder done!");
                }
                catch (Exception exception)
                {
                    Logger.Log.Fatal(exception.ToString);
                    Logger.Log.Fatal("Creating application settings file in this folder done with critical error!");
                    Logger.Log.Fatal("Please contact MairwunNx, MairwunNx@gmail.com. May be it our problem. Sorry.");

                    Logger.Log.Info("Shutting down SacredUtils configurator ...");

                    Environment.Exit(0);
                }

            }
            else
            {
                Logger.Log.Info("Checking availability application settings successfully done!");
            }
        }
    }
}
