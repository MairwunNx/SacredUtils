using SacredUtils.resources.bin.logger;
using System;
using System.IO;

namespace SacredUtils.resources.bin.getting
{
    public static class ApplicationSettings
    {
        public interface IApplicationSettings
        {
            int ConfigVersion { get; }
            bool AcceptLicense { get; set; }
            bool AllowExperimentalScale { get; set; }
            bool CheckAutoAlphaUpdate { get; set; }
            bool CheckAutoUpdate { get; set; }
            string ColorTheme { get; set; }
            bool ConfigFileCreate { get; set; }
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
            bool ShowUsedMemory { get; set; }
            bool UseOldButtonTextures { get; set; }
            bool UseOldMenuTextures { get; set; }
            bool UseOldSlotsTextures { get; set; }
            bool UseStaticBog { get; set; }
            bool UseStaticLava { get; set; }
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
