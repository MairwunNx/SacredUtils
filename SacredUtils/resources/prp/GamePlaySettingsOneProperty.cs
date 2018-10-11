using SacredUtils.resources.bin;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SacredUtils.resources.prp
{
    public class GamePlaySettingsOneProperty
    {
        public int PickupMode
        {
            get
            {
                int index = 0;

                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                string prefix = "PICKUPAUTO : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null)
                {
                    index = Convert.ToInt32(line.Substring(prefix.Length));
                }

                return index;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("PICKUPAUTO", value);
        }

        public int ConnectionType
        {
            get
            {
                int index = 0;

                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                string prefix = "NETWORK_SPEEDSETTINGS : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null)
                {
                    index = Convert.ToInt32(line.Substring(prefix.Length));
                }

                return index;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("NETWORK_SPEEDSETTINGS", value);
        }

        public string PictureOnStartup
        {
            get
            {
                string content = "";

                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                string prefix = "GFXSTARTUP : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { content = line.Substring(prefix.Length); }

                return content;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("GFXSTARTUP", value);
        }

        public string PictureOnLoad
        {
            get
            {
                string content = "";

                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                string prefix = "GFXLOADING : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { content = line.Substring(prefix.Length); }

                return content;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("GFXLOADING", value);
        }

        public int WarningLevel
        {
            get
            {
                int value = 0;

                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                string prefix = "WARNING_LEVEL : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { value = Convert.ToInt32(line.Substring(prefix.Length)); }

                return value;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("WARNING_LEVEL", value);
        }
    }
}
