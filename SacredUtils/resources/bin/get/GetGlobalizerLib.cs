using SacredUtils.resources.bin.logger;
using System;
using System.Diagnostics;
using System.IO;
using static SacredUtils.resources.bin.etc.ApplicationInfo;

namespace SacredUtils.resources.bin.get
{
    public static class GetGlobalizerLib
    {
        public static void Get(int ver)
        {
            Logger.Log.Info("Checking availability WPFSharp.Globalizer.dll file");

            if (!File.Exists("WPFSharp.Globalizer.dll"))
            {
                Logger.Log.Warn("WPFSharp.Globalizer.dll file not found!");

                Create();
            }
            else
            {
                Logger.Log.Info("WPFSharp.Globalizer.dll file was found");
            }

            if (ver > 1)
            {
                try
                {
                    Logger.Log.Warn("WPFSharp.Globalizer.dll file is out of date!");

                    Logger.Log.Info("Updating WPFSharp.Globalizer.dll file ...");

                    File.WriteAllBytes("WPFSharp.Globalizer.dll", Properties.Resources.WPFSharp_Globalizer);

                    Logger.Log.Info("Updating WPFSharp.Globalizer.dll file done!");

                    Logger.Log.Info("Reloading SacredUtils configurator ...");

                    Process.Start(AppName);

                    Environment.Exit(0);
                }
                catch (Exception exception)
                {
                    Logger.Log.Fatal("Updating WPFSharp.Globalizer.dll library done with fatal level error!!!");

                    Logger.Log.Fatal(exception.ToString);

                    Logger.Log.Info("Shutting down SacredUtils configurator ...");

                    Environment.Exit(0);
                }
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

                Process.Start(AppName);

                Environment.Exit(0);
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
