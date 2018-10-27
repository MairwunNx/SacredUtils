using SacredUtils.resources.bin;
using System.IO;
using System.Linq;
using System.Text;

namespace SacredUtils.resources.prp
{
    public class GamePlaySettingsTwoProperty
    {
        public bool TrackEnemy
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "AUTOTRACKENEMY : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("AUTOTRACKENEMY", value ? 1 : 0);
        }

        public bool AutoSave
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "AUTOSAVE : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("AUTOSAVE", value ? 1 : 0);
        }

        public bool DefaultSkills
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "DEFAULT_SKILLS : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("DEFAULT_SKILLS", value ? 1 : 0);
        }

        public bool DebugLog
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "LOGGING : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("LOGGING", value ? 1 : 0);
        }

        public bool DamageIcons
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "TASKBAR_ICONS : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("TASKBAR_ICONS", value ? 1 : 0);
        }

        public bool PotionBar
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "SHOWPOTIONS : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SHOWPOTIONS", value ? 1 : 0);
        }

        public bool PlayerInfo
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "SHOW_HEROINFO : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SHOW_HEROINFO", value ? 1 : 0);
        }

        public bool EnemyInfo
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "SHOW_ENEMYINFO : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SHOW_ENEMYINFO", value ? 1 : 0);
        }
    }
}
