using SacredUtils.resources.bin.logger;
using System;
using System.IO;

namespace SacredUtils.resources.bin.create
{
    public static class AppFolders
    {
        public static void Create()
        {
            try
            {
                Logger.Log.Info("Creating folders for SacredUtils files ...");

                Directory.CreateDirectory("$SacredUtils");
                Directory.CreateDirectory("$SacredUtils\\conf");
                Directory.CreateDirectory("$SacredUtils\\lang");
                Directory.CreateDirectory("$SacredUtils\\logs");
                Directory.CreateDirectory("$SacredUtils\\temp");
                Directory.CreateDirectory("$SacredUtils\\back");
                Directory.CreateDirectory("$SacredUtils\\themes");
                Directory.CreateDirectory("$SacredUtils\\lang\\ru-RU");
                Directory.CreateDirectory("$SacredUtils\\lang\\en-US");

                Logger.Log.Info("Creating folders for SacredUtils files done!");
            }
            catch (Exception exception)
            {
                Logger.Log.Fatal("There was a critical error of the program, sorry please, if the program could not start. Contact the Creator of the utility");

                Logger.Log.Fatal(exception.ToString);

                Logger.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
