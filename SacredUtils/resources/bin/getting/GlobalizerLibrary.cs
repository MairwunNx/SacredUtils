using System;
using System.Diagnostics;
using System.IO;

namespace SacredUtils.resources.bin.getting
{
    public static class GlobalizerLibrary
    {
        public static void Get()
        {
            AppLogger.Log.Info("Checking availability WPFSharp.Globalizer.dll file ...");

            if (!File.Exists("WPFSharp.Globalizer.dll"))
            {
                AppLogger.Log.Warn("WPFSharp.Globalizer.dll file not found!"); Create();
            }
            else
            {
                AppLogger.Log.Info("WPFSharp.Globalizer.dll file was found!");
            }
        }

        private static void Create()
        {
            try
            {
                AppLogger.Log.Info("Creating WPFSharp.Globalizer.dll file ...");

                File.WriteAllBytes("WPFSharp.Globalizer.dll", Properties.Resources.WPFSharp_Globalizer);

                AppLogger.Log.Info("Creating WPFSharp.Globalizer.dll file done!");

                AppLogger.Log.Info("Reloading SacredUtils configurator ...");

                Process.Start(AppSummary.AppPatch); Environment.Exit(0);
            }
            catch (Exception exception)
            {
                AppLogger.Log.Fatal("Creating WPFSharp.Globalizer.dll library done with fatal level error!!!");

                AppLogger.Log.Fatal(exception.ToString);

                AppLogger.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
