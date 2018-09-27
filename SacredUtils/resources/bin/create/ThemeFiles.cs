using SacredUtils.resources.bin.logger;
using System;
using System.IO;

namespace SacredUtils.resources.bin.create
{
    public static class ThemeFiles
    {
        public static void Create()
        {
            try
            {
                File.WriteAllBytes("$SacredUtils\\themes\\Light.xaml", Properties.Resources.Light);
                File.WriteAllBytes("$SacredUtils\\themes\\Dark.xaml", Properties.Resources.Dark);

                Logger.Log.Info("Creating SacredUtils theme files successfully done!");
            }
            catch (Exception exception)
            {
                Logger.Log.Fatal("Creating SacredUtils theme files done with fatal level error!!!");
                
                Logger.Log.Fatal(exception.ToString);

                Logger.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
