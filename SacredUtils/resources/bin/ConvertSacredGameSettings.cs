using System;
using System.IO;
using System.Threading.Tasks;

namespace SacredUtils.resources.bin
{
    public static class ConvertSacredGameSettings
    {
        // private static readonly object _love = "Isabella";

        public static void ConvertToIni()
        {
            try
            {
                File.WriteAllText("$SacredUtils\\temp\\~Settings.ini",
                     File.ReadAllText("Settings.cfg").Replace(" : ", "="));

                AppLogger.Log.Info("Re-formatting settings.cfg file to true cfg (ini) done!");
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }
        }

        public static void ConvertToCfg()
        {
            try
            {
                Task.Run(() =>
                {
                    File.WriteAllText("Settings.cfg",
                        File.ReadAllText("$SacredUtils\\temp\\~Settings.ini").Replace("=", " : "));
                });
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }
        }
    }
}
