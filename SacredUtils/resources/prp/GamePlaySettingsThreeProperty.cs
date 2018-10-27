using SacredUtils.resources.bin;
using System.IO;
using System.Linq;
using System.Text;

namespace SacredUtils.resources.prp
{
    public class GamePlaySettingsThreeProperty
    {
        public bool CombineSlots
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "COMBINE_SLOTS : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("COMBINE_SLOTS", value ? 1 : 0);
        }

        public bool AcceptLicense
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "ACCEPT_LICENSE : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("ACCEPT_LICENSE", value ? 1 : 0);
        }

        public bool FirstEnter
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "FIRST_LOGIN : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("FIRST_LOGIN", value ? 1 : 0);
        }

        public bool Earthquake
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "SCREEN_QUAKE : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SCREEN_QUAKE", value ? 1 : 0);
        }
    }
}
