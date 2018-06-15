﻿using System;
using System.IO;
using System.Diagnostics;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.bin
{
    internal class CheckLogConfiguration
    {
        public void GetAvailableLogConfig()
        {
            if (!File.Exists(Appname + ".config"))
            {
                try
                {
                    File.WriteAllBytes(Appname + ".config", Properties.Resources.SacredUtils_exe);

                    Process.Start(Appname); Environment.Exit(0);
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }
    }
}