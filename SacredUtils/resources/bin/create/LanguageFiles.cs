using System;
using System.IO;

namespace SacredUtils.resources.bin.create
{
    public static class LanguageFiles
    {
        public static void Create()
        {
            try
            {
                File.WriteAllBytes("$SacredUtils\\lang\\ru-RU\\ru-RU.xaml", Properties.Resources.ru_RU);
                File.WriteAllBytes("$SacredUtils\\lang\\en-US\\en-US.xaml", Properties.Resources.en_US);

                AppLogger.Log.Info("Creating SacredUtils language files successfully done!");
            }
            catch (Exception exception)
            {
                AppLogger.Log.Fatal("Creating SacredUtils language files done with fatal level error!!!");

                AppLogger.Log.Fatal(exception.ToString);

                AppLogger.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
