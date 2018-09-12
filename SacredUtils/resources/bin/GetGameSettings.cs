using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpConfig;

namespace SacredUtils.resources.bin
{
    public class GetGameSettings
    {
        public void GetFile()
        {
            try
            {
                GetLoggerConfig.Log.Info("Checking available temporary folder");

                if (Directory.Exists("$SacredUtils\\temp"))
                {
                    GetLoggerConfig.Log.Info("The temporary folder was detected, we'll delete it");

                    Directory.Delete("$SacredUtils\\temp", true);

                    GetLoggerConfig.Log.Info("Temporary folder has been deleted");
                }

                GetLoggerConfig.Log.Info("Temporary folder has been created");

                Directory.CreateDirectory("$SacredUtils\\temp");

                GetLoggerConfig.Log.Info("Copying settings.cfg in temp//~Settings.cfg");

                File.Copy("Settings.cfg", "$SacredUtils\\temp\\~Settings.cfg");

                GetLoggerConfig.Log.Info("Re-formatting settings.cfg file to true cfg");

                string content = File.ReadAllText("$SacredUtils\\temp\\~Settings.cfg");
                content = "[General]" + "\n" + content;
                File.WriteAllText("$SacredUtils\\temp\\~Settings.cfg", content);

                string str;

                using (StreamReader reader = File.OpenText("$SacredUtils\\temp\\~Settings.cfg"))
                {
                    GetLoggerConfig.Log.Info("Replacing : on =, in ~Settings.cfg");

                    str = reader.ReadToEnd();
                    str = str.Replace(":", "=");
                }

                using (StreamWriter file = new StreamWriter("$SacredUtils\\temp\\~Settings.cfg"))
                {
                    GetLoggerConfig.Log.Info("Preparing to loading settings from ~Settings.cfg");

                    file.Write(str);
                }
            }
            catch (Exception e)
            {
                GetLoggerConfig.Log.Info(e.ToString);
            }
        }

        public void GetSettings()
        {
            Configuration.LoadFromFile("$SacredUtils\\temp\\~Settings.cfg", Encoding.ASCII);
            
            var configload     = Configuration.LoadFromFile("$SacredUtils\\temp\\~Settings.cfg");
            var section        = configload["General"];



            string someSs = section["sss"].GetValueOrDefault("s");

            bool someString1а = section["TEST1"].GetValueOrDefault(false);

            int someString = section["EXPLOREMAP"].IntValue;
            string someString1 = section["GFXSTARTUP"].StringValue;

//            tglbtn.IsChecked = someString == 1;
//            tx.Text = someString1;
        }
    }
}
