using System;
using System.Diagnostics;
using System.IO;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class ApplicationStartUtilityUpdate
    {
        public static void Start()
        {
            try
            {
                Directory.CreateDirectory("$SacredUtils\\temp");

                File.Create("$SacredUtils\\temp\\updated.su");

                Process.Start("mnxupdater.exe", AppDomain.CurrentDomain.FriendlyName + " _newVersionSacredUtilsTemp.exe");

                ApplicationBaseWindowShutdown.Shutdown();
            }
            catch (Exception ex)
            {
                Log.Info(ex.ToString);
            }
        }
    }
}
