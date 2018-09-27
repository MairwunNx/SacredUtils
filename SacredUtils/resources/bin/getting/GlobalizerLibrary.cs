using SacredUtils.resources.bin.logger;
using System;
using System.Diagnostics;
using System.IO;
using static SacredUtils.resources.bin.application.ApplicationInfo;

namespace SacredUtils.resources.bin.getting
{
    public static class GlobalizerLibrary
    {
        public static void Get()
        {
            Logger.Log.Info("Checking availability WPFSharp.Globalizer.dll file ...");

            if (!File.Exists("WPFSharp.Globalizer.dll"))
            {
                Logger.Log.Warn("WPFSharp.Globalizer.dll file not found!"); Create();
            }
            else
            {
                Logger.Log.Info("WPFSharp.Globalizer.dll file was found!");
            }
        }

        private static void Create()
        {
            try
            {
                Logger.Log.Info("Creating WPFSharp.Globalizer.dll file ...");

                File.WriteAllBytes("WPFSharp.Globalizer.dll", Properties.Resources.WPFSharp_Globalizer);

                Logger.Log.Info("Creating WPFSharp.Globalizer.dll file done!");

                Logger.Log.Info("Reloading SacredUtils configurator ...");

                Process.Start(AppPatch); Environment.Exit(0);
            }
            catch (Exception exception)
            {
                Logger.Log.Fatal("Creating WPFSharp.Globalizer.dll library done with fatal level error!!!");

                Logger.Log.Fatal(exception.ToString);

                Logger.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
