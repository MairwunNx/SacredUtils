using System;
using System.IO;
using System.Windows;

namespace SacredUtils.resources.bin
{
    public static class CreateLanguageFiles
    {
        public static void Create()
        {
            try
            {
                GetLoggerConfig.Log.Info("Creating SacredUtils language files ...");

                File.WriteAllBytes("$SacredUtils\\lang\\ru-RU\\ru-RU.xaml", Properties.Resources.ru_RU);
                File.WriteAllBytes("$SacredUtils\\lang\\en-US\\en-US.xaml", Properties.Resources.en_US);

                GetLoggerConfig.Log.Info("Creating SacredUtils language files done!");
            }
            catch (Exception exception)
            {
                GetLoggerConfig.Log.Fatal("Creating SacredUtils language files done with fatal level error!!!");

                GetLoggerConfig.Log.Fatal(exception.ToString);

                GetLoggerConfig.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
