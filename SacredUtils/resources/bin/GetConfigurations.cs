using System.IO;

namespace SacredUtils.resources.bin
{
    public class GetConfigurations
    {
        public void Get()
        {
            GetLoggerConfig.Log.Info("Checking availability advanced settings");

            if (!File.Exists("$SacredUtils\\conf\\advanced.json"))
            {
//                File.WriteAllBytes("$SacredUtils\\conf\\advanced.json", Properties.Resources.graphics);

                GetLoggerConfig.Log.Info("Advanced settings were created in conf folder");
            }


            GetLoggerConfig.Log.Info("Checking availability changelog settings");

            if (!File.Exists("$SacredUtils\\conf\\changelog.json"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\changelog.json", Properties.Resources.changelog);

                GetLoggerConfig.Log.Info("Changelog settings were created in conf folder");
            }


            GetLoggerConfig.Log.Info("Checking availability installinfo settings");

            if (!File.Exists("$SacredUtils\\conf\\installinfo.json"))
            {
//                File.WriteAllBytes("$SacredUtils\\conf\\installinfo.json", Properties.Resources.installinfo);

                GetLoggerConfig.Log.Info("Installinfo settings were created in conf folder");
            }


            GetLoggerConfig.Log.Info("Checking availability hotkeys settings");

            if (!File.Exists("$SacredUtils\\conf\\hotkeys.json"))
            {
//                File.WriteAllBytes("$SacredUtils\\conf\\hotkeys.json", Properties.Resources.hotkeys);

                GetLoggerConfig.Log.Info("Hotkeys settings were created in conf folder");
            }


            GetLoggerConfig.Log.Info("Checking availability voiceover settings");

            if (!File.Exists("$SacredUtils\\conf\\voiceover.json"))
            {
//                File.WriteAllBytes("$SacredUtils\\conf\\voiceover.json", Properties.Resources.voiceover);

                GetLoggerConfig.Log.Info("Voiceover settings were created in conf folder");
            }


            GetLoggerConfig.Log.Info("Checking availability game settings");

            if (!File.Exists("settings.cfg"))
            {
                File.WriteAllBytes("settings.cfg", Properties.Resources.gamesettings);

                GetLoggerConfig.Log.Info("Game settings were created in this folder");
            }
        }
    }
}
