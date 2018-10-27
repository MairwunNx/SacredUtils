using SacredUtils.resources.bin;
using System.IO;
using System.Linq;
using System.Text;

namespace SacredUtils.resources.prp
{
    public class GameGraphicsSettingsTwoProperty
    {
        public bool RestrictionMemory
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "GFX_LIMIT128 : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("GFX_LIMIT128", value ? 1 : 0);
        }

        public bool ColorDepth
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "GFX32 : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("GFX32", value ? 1 : 0);
        }

        public bool PickupAnim
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "PICKUPANIM : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("PICKUPANIM", value ? 1 : 0);
        }

        public bool Violence
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "VIOLENCE : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("VIOLENCE", value ? 1 : 0);
        }

        public bool FullScreen
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "FULLSCREEN : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("FULLSCREEN", value ? 1 : 0);
        }

        public bool FullScreenAa
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "FSAA_FILTER : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("FSAA_FILTER", value ? 1 : 0);
        }

        public bool ShowMovie
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "SHOWMOVIE : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SHOWMOVIE", value ? 1 : 0);
        }

        public bool ShowFinalMovie
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "SHOWEXTRO : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SHOWEXTRO", value ? 1 : 0);
        }
    }
}
