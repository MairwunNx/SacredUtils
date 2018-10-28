using System;
using System.IO;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class CreateApplicationLanguageFiles
    {
        public static void Create()
        {
            try
            {
                File.WriteAllBytes("$SacredUtils\\lang\\ru-RU\\ru-RU.xaml", Properties.Resources.ru_RU);
                File.WriteAllBytes("$SacredUtils\\lang\\en-US\\en-US.xaml", Properties.Resources.en_US);

                Log.Info("SacredUtils language files was successfully re-created!");
            }
            catch (Exception exception)
            {
                Log.Fatal("Creating SacredUtils language files done with fatal level error!!!");

                Log.Fatal(exception.ToString);

                Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
