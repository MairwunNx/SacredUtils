using SacredUtils.resources.bin;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SacredUtils.resources.prp
{
    public class GameGraphicsSettingsOneProperty
    {
        public int GraphicsQuality
        {
            get
            {
                int value = 0;

                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "DETAILLEVEL : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { value = Convert.ToInt32(line.Substring(prefix.Length)); }

                return value;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("DETAILLEVEL", value);
        }

        public int WaitRetrace
        {
            get
            {
                int value = 0;

                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "WAITRETRACE : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { value = Convert.ToInt32(line.Substring(prefix.Length)); }

                return value;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("WAITRETRACE", value);
        }

        public int MapTransparent
        {
            get
            {
                int value = 0;

                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "MINIMAP_ALPHA : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { value = Convert.ToInt32(line.Substring(prefix.Length)); }

                return value;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("MINIMAP_ALPHA", value);
        }

        public int NightDarkness
        {
            get
            {
                int value = 0;

                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "NIGHT_DARKNESS : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { value = Convert.ToInt32(line.Substring(prefix.Length)); }

                return value;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("NIGHT_DARKNESS", value);
        }
    }
}
