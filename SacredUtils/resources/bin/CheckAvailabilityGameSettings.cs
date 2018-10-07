﻿using System;
using System.IO;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityGameSettings
    {
        public static void Get()
        {
            if (!File.Exists("Settings.cfg"))
            {
                try
                {
                    AppLogger.Log.Warn("Sacred game configuration file (settings.cfg) not found!");

                    File.WriteAllBytes("Settings.cfg", Properties.Resources.gamesettings);

                    AppLogger.Log.Info("Creating sacred game configuration file (settings.cfg) done!");
                }
                catch (Exception e)
                {
                    AppLogger.Log.Fatal("A critical error has occurred while creating game configuration file!");
                    AppLogger.Log.Fatal(e.ToString);

                    AppLogger.Log.Info("Shutting down SacredUtils configurator ...");

                    Environment.Exit(0); // Please, return to me, Isabella, please ...
                }
            }
            else
            {
                AppLogger.Log.Info("Sacred game configuration file (settings.cfg) was found!");
            }
        }
    }
}