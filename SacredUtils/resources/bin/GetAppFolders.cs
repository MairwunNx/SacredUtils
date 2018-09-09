using System;
using System.IO;
using System.Windows;

namespace SacredUtils.resources.bin
{
    public static class GetAppFolders
    {
        public static void Get()
        {
            try
            {
                GetLoggerConfig.Log.Info("Creating folders for SacredUtils files ...");

                Directory.CreateDirectory("$SacredUtils");
                Directory.CreateDirectory("$SacredUtils\\conf");
                Directory.CreateDirectory("$SacredUtils\\lang");
                Directory.CreateDirectory("$SacredUtils\\logs");
                Directory.CreateDirectory("$SacredUtils\\temp");
                Directory.CreateDirectory("$SacredUtils\\back");
                Directory.CreateDirectory("$SacredUtils\\themes");
                Directory.CreateDirectory("$SacredUtils\\lang\\ru-RU");
                Directory.CreateDirectory("$SacredUtils\\lang\\en-US");

                GetLoggerConfig.Log.Info("Creating folders for SacredUtils files done!");
            }
            catch (Exception exception)
            {
                GetLoggerConfig.Log.Fatal("There was a critical error of the program, sorry please, if the program could not start. Contact the Creator of the utility");

                GetLoggerConfig.Log.Fatal(exception.ToString);

                GetLoggerConfig.Log.Info("Shutting down SacredUtils configurator ...");

                Application.Current.Shutdown();
            }
        }
    }
}
