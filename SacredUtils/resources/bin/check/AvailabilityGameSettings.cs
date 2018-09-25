using SacredUtils.resources.bin.logger;
using System;
using System.IO;

namespace SacredUtils.resources.bin.check
{
    public static class AvailabilityGameSettings
    {
        public static void Get()
        {
            Logger.Log.Info("Checking availability game settings file (settings.cfg) ...");

            if (!File.Exists("Settings.cfg"))
            {
                try
                {
                    Logger.Log.Warn("GAME SETTINGS FILE NOT FOUND! SETTINGS WILL BE GENERATED!");

                    File.WriteAllBytes("Settings.cfg", Properties.Resources.gamesettings);

                    Logger.Log.Info("Game settings successfully generated!");
                }
                catch (Exception e)
                {
                    Logger.Log.Fatal("A critical error has occurred while creating game settings!");
                    Logger.Log.Fatal(e.ToString);

                    Logger.Log.Info("Shutting down SacredUtils configurator ...");

                    Environment.Exit(0);
                }
            }
            else
            {
                Logger.Log.Info("Game settings was found! Settings will be loaded from settins.cfg");
            }
        }
    }
}
