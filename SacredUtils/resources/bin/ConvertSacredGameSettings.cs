using System;
using System.IO;
using System.Threading.Tasks;

namespace SacredUtils.resources.bin
{
    public static class ConvertSacredGameSettings
    {
        // private static readonly object _love = "Isabella";

        public static void ConvertToIni(string type)
        {
            if (type == "by program")
            {
                try
                {
                    File.WriteAllText("$SacredUtils\\temp\\~Settings.ini",
                        "[BaseSettings]" + "\n" + File.ReadAllText("Settings.cfg").Replace(" : ", "="));

                    AppLogger.Log.Info("Re-formatting settings.cfg file to true cfg (ini) done!");
                }
                catch (Exception e)
                {
                    AppLogger.Log.Error(e.ToString);
                }
            }

            if (type == "by user")
            {
                try
                {
                    Task.Run(() =>
                    {
                        File.WriteAllText("$SacredUtils\\temp\\~Settings.ini",
                            "[BaseSettings]" + "\n" + File.ReadAllText("Settings.cfg").Replace(" : ", "="));
                    });
                }
                catch (Exception e)
                {
                    AppLogger.Log.Error(e.ToString);
                }
            }
        }

        public static void ConvertToCfg(string type)
        {
            if (type == "by program")
            {
                try
                {
                    File.WriteAllText("Settings.cfg",
                        File.ReadAllText("$SacredUtils\\temp\\~Settings.ini").Replace("=", " : ").Remove(0, 15));

                    AppLogger.Log.Info("Re-formatting settings.ini file to old (sacred) cfg done!");
                }
                catch (Exception e)
                {
                    AppLogger.Log.Error(e.ToString);
                }
            }

            if (type == "by user")
            {
                try
                {
                    Task.Run(() =>
                    {
                        File.WriteAllText("Settings.cfg",
                            File.ReadAllText("$SacredUtils\\temp\\~Settings.ini").Replace("=", " : ").Remove(0, 15));
                    });
                }
                catch (Exception e)
                {
                    AppLogger.Log.Error(e.ToString);
                }
            }
        }
    }
}
