using System.Diagnostics;
using System.IO;
using static SacredUtils.resources.bin.ApplicationInfo;

namespace SacredUtils.resources.bin
{
    public static class GetGlobalizerLib
    {
        public static void Get()
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
        }

        private static void Create()
        {
            GetLoggerConfig.Log.Info("Creating WPFSharp.Globalizer.dll file ...");

            File.WriteAllBytes("WPFSharp.Globalizer.dll", Properties.Resources.WPFSharp_Globalizer);

            GetLoggerConfig.Log.Info("Creating WPFSharp.Globalizer.dll file done!");

            GetLoggerConfig.Log.Info("Reloading SacredUtils configurator ...");

            Process.Start(AppName);

            System.Windows.Application.Current.Shutdown();
        }
    }
}
