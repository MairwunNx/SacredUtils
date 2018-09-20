using SacredUtils.resources.bin.get;
using System;
using System.IO;

namespace SacredUtils.resources.bin.check
{
    public static class AvailabilityGameSettings
    {
        public static void Get()
        {
            GetLoggerConfig.Log.Info("Checking availability game settings file (settings.cfg) ...");

            if (!File.Exists("Settings.cfg"))
            {
                try
                {
                    GetLoggerConfig.Log.Warn("GAME SETTINGS FILE NOT FOUND! SETTINGS WILL BE GENERATED!");

                    File.WriteAllBytes("Settings.cfg", Properties.Resources.gamesettings);

                    GetLoggerConfig.Log.Info("Game settings successfully generated!");
                }
                catch (Exception e)
                {
                    GetLoggerConfig.Log.Fatal("A critical error has occurred while creating game settings!");
                    GetLoggerConfig.Log.Fatal(e.ToString);

                    GetLoggerConfig.Log.Info("Shutting down SacredUtils configurator ...");

                    Environment.Exit(0);
                }
            }
            else
            {
                GetLoggerConfig.Log.Info("Game settings was found! Settings will be loaded from settins.cfg");
            }
        }
    }
}
