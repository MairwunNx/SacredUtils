using Config.Net;
using System;
using System.IO;

namespace SacredUtils.resources.bin.check
{
    public static class AvailabilityGameSettings
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
            else
            {
                IAppSettings applicationSettings =
                    new ConfigurationBuilder<IAppSettings>()
                        .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                AppLogger.Log.Info("Game settings was found! Settings will be loaded from settins.cfg");

                if (applicationSettings.MakeAutoBackupConfigs)
                {
                    Random rnd = new Random();

                    File.Copy("settings.cfg", $"$SacredUtils\\back\\cfg-game\\config_game_id_{rnd.Next(0, Int32.MaxValue)}.cfg", true);
                }
            }
        }
    }
}
