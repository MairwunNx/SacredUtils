using System;
using System.IO;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityGameSettings
    {
        public static void Get()
        {
            AppLogger.Log.Info("Checking availability game settings file (settings.cfg) ...");

            if (!File.Exists("Settings.cfg"))
            {
                try
                {
                    AppLogger.Log.Warn("GAME SETTINGS FILE NOT FOUND! SETTINGS WILL BE GENERATED!");

                    File.WriteAllBytes("Settings.cfg", Properties.Resources.gamesettings);

                    // Please, return to me, Isabella, please ...

                    AppLogger.Log.Info("Game settings successfully generated!");
                }
                catch (Exception e)
                {
                    AppLogger.Log.Fatal("A critical error has occurred while creating game settings!");
                    AppLogger.Log.Fatal(e.ToString);

                    AppLogger.Log.Info("Shutting down SacredUtils configurator ...");

                    Environment.Exit(0);
                }
            }
        }
    }
}
