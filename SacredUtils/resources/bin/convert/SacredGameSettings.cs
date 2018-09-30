using System;
using System.IO;
using System.Threading.Tasks;

namespace SacredUtils.resources.bin.convert
{
    public static class SacredGameSettings
    {
        // private static readonly object _love = "Isabella";

        public static void ConvertToIni(string type)
        {
            if (type == "by program")
            {
                try
                {
                    AppLogger.Log.Info("Preparing start settings for converting to ini");

                    AppLogger.Log.Info("Re-formatting settings.cfg file to true cfg ...");

                    string content = File.ReadAllText("Settings.cfg");
                    content = "[BaseSettings]" + "\n" + content.Replace(" : ", "=");
                    File.WriteAllText("$SacredUtils\\temp\\~Settings.ini", content);

                    AppLogger.Log.Info("Re-formatting settings.cfg file to true cfg done!");
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
                        string content = File.ReadAllText("Settings.cfg");
                        content = "[BaseSettings]" + "\n" + content.Replace(" : ", "=");
                        File.WriteAllText("$SacredUtils\\temp\\~Settings.ini", content);
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
                    AppLogger.Log.Info("Preparing start settings for converting to cfg");

                    AppLogger.Log.Info("Re-formatting settings.ini file to old cfg ...");

                    string content = File.ReadAllText("$SacredUtils\\temp\\~Settings.ini");
                    content = content.Replace("=", " : ").Remove(0, 15);
                    File.WriteAllText("Settings.cfg", content);

                    AppLogger.Log.Info("Re-formatting settings.ini file to old cfg done!");
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
                        string content = File.ReadAllText("$SacredUtils\\temp\\~Settings.ini");
                        content = content.Replace("=", " : ").Remove(0, 15);
                        Task.Run(() => File.WriteAllText("Settings.cfg", content));
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
