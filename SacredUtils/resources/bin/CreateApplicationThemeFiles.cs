using System;
using System.IO;

namespace SacredUtils.resources.bin
{
    public static class CreateApplicationThemeFiles
    {
        public static void Create()
        {
            try
            {
                File.WriteAllBytes("$SacredUtils\\themes\\Light.xaml", Properties.Resources.Light);
                File.WriteAllBytes("$SacredUtils\\themes\\Dark.xaml", Properties.Resources.Dark);

                AppLogger.Log.Info("SacredUtils theme files was successfully re-created!");
            }
            catch (Exception exception)
            {
                AppLogger.Log.Fatal("Creating SacredUtils theme files done with fatal level error!!!");
                
                AppLogger.Log.Fatal(exception.ToString);

                AppLogger.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
