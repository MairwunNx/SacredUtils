using System;
using System.IO;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class CreateApplicationThemeFiles
    {
        public static void Create()
        {
            try
            {
                File.WriteAllBytes("$SacredUtils\\thms\\light.xaml", Properties.Resources.Light);
                File.WriteAllBytes("$SacredUtils\\thms\\dark.xaml", Properties.Resources.Dark);

                Log.Info("SacredUtils theme files was successfully re-created!");
            }
            catch (Exception exception)
            {
                Log.Fatal("Creating SacredUtils theme files done with fatal level error!!!");
                
                Log.Fatal(exception.ToString);

                Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
