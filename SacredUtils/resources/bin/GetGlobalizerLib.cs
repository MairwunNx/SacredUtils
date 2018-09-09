using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using static SacredUtils.resources.bin.ApplicationInfo;

namespace SacredUtils.resources.bin
{
    public static class GetGlobalizerLib
    {
        public static void Get(int ver)
        {
            GetLoggerConfig.Log.Info("Checking availability WPFSharp.Globalizer.dll file");

            if (!File.Exists("WPFSharp.Globalizer.dll"))
            {
                GetLoggerConfig.Log.Warn("WPFSharp.Globalizer.dll file not found!");

                Create();
            }
            else
            {
                GetLoggerConfig.Log.Info("WPFSharp.Globalizer.dll file was found");
            }

            if (ver > 1)
            {
                try
                {
                    GetLoggerConfig.Log.Warn("WPFSharp.Globalizer.dll file is out of date!");

                    GetLoggerConfig.Log.Info("Updating WPFSharp.Globalizer.dll file ...");

                    File.WriteAllBytes("WPFSharp.Globalizer.dll", Properties.Resources.WPFSharp_Globalizer);

                    GetLoggerConfig.Log.Info("Updating WPFSharp.Globalizer.dll file done!");

                    GetLoggerConfig.Log.Info("Reloading SacredUtils configurator ...");

                    Process.Start(AppName);

                    Application.Current.Shutdown();
                }
                catch (Exception exception)
                {
                    GetLoggerConfig.Log.Fatal("Updating WPFSharp.Globalizer.dll library done with fatal level error!!!");

                    GetLoggerConfig.Log.Fatal(exception.ToString);

                    GetLoggerConfig.Log.Info("Shutting down SacredUtils configurator ...");

                    Application.Current.Shutdown();
                }
            }
        }

        private static void Create()
        {
            try
            {
                GetLoggerConfig.Log.Info("Creating WPFSharp.Globalizer.dll file ...");

                File.WriteAllBytes("WPFSharp.Globalizer.dll", Properties.Resources.WPFSharp_Globalizer);

                GetLoggerConfig.Log.Info("Creating WPFSharp.Globalizer.dll file done!");

                GetLoggerConfig.Log.Info("Reloading SacredUtils configurator ...");

                Process.Start(AppName);

                Application.Current.Shutdown();
            }
            catch (Exception exception)
            {
                GetLoggerConfig.Log.Fatal("Creating WPFSharp.Globalizer.dll library done with fatal level error!!!");

                GetLoggerConfig.Log.Fatal(exception.ToString);

                GetLoggerConfig.Log.Info("Shutting down SacredUtils configurator ...");

                Application.Current.Shutdown();
            }
        }
    }
}
