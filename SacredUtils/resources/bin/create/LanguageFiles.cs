using SacredUtils.resources.bin.logger;
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

                Logger.Log.Info("Creating SacredUtils language files successfully done!");
            }
            catch (Exception exception)
            {
                Logger.Log.Fatal("Creating SacredUtils language files done with fatal level error!!!");

                Logger.Log.Fatal(exception.ToString);

                Logger.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
