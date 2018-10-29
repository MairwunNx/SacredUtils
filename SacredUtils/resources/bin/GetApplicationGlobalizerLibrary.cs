using System;
using System.Diagnostics;
using System.IO;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationGlobalizerLibrary
    {
        public static void Get()
        {
            if (!File.Exists("WPFSharp.Globalizer.dll"))
            {
                Log.Warn("WPFSharp.Globalizer.dll library file not found!");

                Create();
            }
            else
            {
                Log.Info("WPFSharp.Globalizer.dll library file was found!");

                // check on md5
            }
        }

        private static void Create()
        {
            try
            {
                Log.Info("Creating WPFSharp.Globalizer.dll lirary file ...");

                File.WriteAllBytes("WPFSharp.Globalizer.dll", Properties.Resources.WPFSharp_Globalizer);

                Log.Info("Creating WPFSharp.Globalizer.dll library file done!");

                Log.Info("Reloading SacredUtils configurator ...");

                Process.Start(AppSummary.AppPatch); Environment.Exit(0);
            }
            catch (Exception exception)
            {
                Log.Fatal("Creating WPFSharp.Globalizer.dll library done with fatal level error!");

                Log.Fatal(exception.ToString);

                Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
