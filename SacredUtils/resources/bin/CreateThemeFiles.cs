using System;
using System.IO;

namespace SacredUtils.resources.bin
{
    public static class CreateThemeFiles
    {
        public static void Create()
        {
            try
            {
                GetLoggerConfig.Log.Info("Creating SacredUtils theme files ...");

                File.WriteAllBytes("$SacredUtils\\themes\\Light.xaml", Properties.Resources.Light);
                File.WriteAllBytes("$SacredUtils\\themes\\Dark.xaml", Properties.Resources.Dark);

                GetLoggerConfig.Log.Info("Creating SacredUtils theme files done!");
            }
            catch (Exception exception)
            {
                GetLoggerConfig.Log.Fatal("Creating SacredUtils theme files done with fatal level error!!!");
                
                GetLoggerConfig.Log.Fatal(exception.ToString);

                GetLoggerConfig.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
