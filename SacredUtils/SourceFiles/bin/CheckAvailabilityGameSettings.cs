using System;
using System.IO;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityGameSettings
    {
        public static void Get()
        {
            if (!File.Exists(AppSettings.ApplicationSettings.SacredConfigurationFile))
            {
                try
                {
                    Log.Warn($"Sacred game configuration file ({AppSettings.ApplicationSettings.SacredConfigurationFile}) not found!");
                    File.WriteAllBytes(AppSettings.ApplicationSettings.SacredConfigurationFile, Properties.Resources.gamesettings);
                    Log.Info($"Creating sacred game configuration file ({AppSettings.ApplicationSettings.SacredConfigurationFile}) done!");
                }
                catch (Exception e)
                {
                    Log.Fatal("A critical error has occurred while creating game configuration file!");
                    Log.Fatal(e.ToString);
                    Log.Info("Shutting down SacredUtils configurator ...");
                    Environment.Exit(0);
                }
            }
            else
            {
                Log.Info($"Sacred game configuration file ({AppSettings.ApplicationSettings.SacredConfigurationFile}) was found!");
            }
        }
    }
}
