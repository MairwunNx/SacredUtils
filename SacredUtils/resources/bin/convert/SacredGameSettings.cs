using SacredUtils.resources.bin.logger;
using System;
using System.IO;

namespace SacredUtils.resources.bin.convert
{
    public static class SacredGameSettings
    {
        public static void ConvertToIni()
        {
            try
            {
                Logger.Log.Info("Preparing start settings for converting to ini");

                Logger.Log.Info("Re-formatting settings.cfg file to true cfg ...");

                string content = File.ReadAllText("Settings.cfg");
                content = "[BaseSettings]" + "\n" + content.Replace(" : ", "=");
                File.WriteAllText("$SacredUtils\\temp\\~Settings.ini", content);

                Logger.Log.Info("Re-formatting settings.cfg file to true cfg done!");
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString);
            }
        }

        public static void ConvertToCfg()
        {
            try
            {
                Logger.Log.Info("Preparing start settings for converting to cfg");

                Logger.Log.Info("Re-formatting settings.ini file to old cfg ...");

                string content = File.ReadAllText("$SacredUtils\\temp\\~Settings.ini");
                content = content.Replace("=", " : ").Remove(0, 15);
                File.WriteAllText("Settings.cfg", content);

                Logger.Log.Info("Re-formatting settings.ini file to old cfg done!");
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString);
            }
        }
    }
}
