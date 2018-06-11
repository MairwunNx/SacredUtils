using System;
using System.IO;
using System.Diagnostics;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    internal class CheckLogConfiguration
    {
        public void GetAvailableLogConfig()
        {
            Log.Info("Checking availability " + Appname + ".config file.");

            if (!File.Exists(Appname + ".config"))
            {
                try
                {
                    Log.Warn("Config file " + Appname + ".config " + "was not found.");

                    Log.Info("Starting creating config file " + Appname + ".config.");

                    File.WriteAllBytes(Appname + ".config", Properties.Resources.SacredUtils_exe);

                    Log.Info("Config file " + Appname + ".config " + "was created by program.");

                    Log.Info("A reboot is required for correct operation. We will do it.");

                    Log.Info("Completion of all processes and tasks of SacredUtils.");

                    Process.Start(Appname); Environment.Exit(0);
                }
                catch (Exception exception)
                {
                    Log.Error("An error occurred while creating the config file " + Appname + ".config.");

                    Log.Error(exception.ToString());
                }
            }
            else
            {
                Log.Info("Config file " + Appname + ".config " + "was found.");
            }
        }
    }
}
