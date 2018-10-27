using SacredUtils.resources.bin;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace SacredUtils.resources.prp
{
    public class GameChatSettingsOneProperty
    {
        public bool UniqueColor 
        {
            get
            {
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "UNIQUE_COLOR : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("UNIQUE_COLOR", value ? 1 : 0);
        }

        public int Language
        {
            get
            {
                int index = 5;

                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "LANGUAGE : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null && line.Substring(prefix.Length) == "RU") { index = 0; }

                if (line != null && line.Substring(prefix.Length) == "US") { index = 1; }

                if (line != null && line.Substring(prefix.Length) == "DE") { index = 2; }

                if (line != null && line.Substring(prefix.Length) == "SP") { index = 3; }

                if (line != null && line.Substring(prefix.Length) == "FR") { index = 4; }

                if (index == 5)
                {
                    if (Directory.Exists("scripts"))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo("scripts");
                        DirectoryInfo[] dirs = directoryInfo.GetDirectories();

                        if (dirs.Length > 1)
                        {
                            switch (CultureInfo.InstalledUICulture.TwoLetterISOLanguageName)
                            {
                                case "ru" when Directory.Exists("scripts\\ru"): index = 0; break;
                                case "en" when Directory.Exists("scripts\\us"): index = 1; break;
                                case "us" when Directory.Exists("scripts\\us"): index = 1; break;
                                case "de" when Directory.Exists("scripts\\de"): index = 2; break;
                                case "sp" when Directory.Exists("scripts\\sp"): index = 3; break;
                                case "fr" when Directory.Exists("scripts\\fr"): index = 4; break;
                                default: index = 1; break;
                            }
                        }
                        else if (dirs.Length == 1)
                        {
                            if (Directory.Exists("scripts\\ru")) { index = 0; }
                            if (Directory.Exists("scripts\\us")) { index = 1; }
                            if (Directory.Exists("scripts\\de")) { index = 2; }
                            if (Directory.Exists("scripts\\sp")) { index = 3; }
                            if (Directory.Exists("scripts\\fr")) { index = 4; }
                        }
                    }
                }

                return index;
            }

            set
            {
                if (value == 0)
                {
                    ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "RU");

                    GetSacredGameComponentFiles.GetComponent(
                        new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/sKUKqp3W3XgcFP"),
                        Environment.ExpandEnvironmentVariables("%tmp%"),
                        "GameLangRu.zip", "scripts\\ru", "LangRu",
                        "scripts\\ru\\globalru.res", "scripts\\ru\\global.res");
                }
                else if (value == 1)
                {
                    ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "US");

                    GetSacredGameComponentFiles.GetComponent(
                        new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/1sni8lWA3XgcFo"),
                        Environment.ExpandEnvironmentVariables("%tmp%"),
                        "GameLangUs.zip", "scripts\\us", "LangUs",
                        "scripts\\us\\globalus.res", "scripts\\us\\global.res");
                }
                else if (value == 2)
                {
                    ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "DE");

                    GetSacredGameComponentFiles.GetComponent(
                        new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/ekWsMxz13XgcEr"),
                        Environment.ExpandEnvironmentVariables("%tmp%"),
                        "GameLangDe.zip", "scripts\\de", "LangDe",
                        "scripts\\de\\globalde.res", "scripts\\de\\global.res");
                }
                else if (value == 3)
                {
                    ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "SP");

                    GetSacredGameComponentFiles.GetComponent(
                        new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/5n-Vslep3XgcFb"),
                        Environment.ExpandEnvironmentVariables("%tmp%"),
                        "GameLangSp.zip", "scripts\\sp", "LangSp",
                        "scripts\\sp\\globalsp.res", "scripts\\sp\\global.res");
                }
                else if (value == 4)
                {
                    ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "FR");

                    GetSacredGameComponentFiles.GetComponent(
                        new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/2XGSFLVL3XgcF5"),
                        Environment.ExpandEnvironmentVariables("%tmp%"),
                        "GameLangFr.zip", "scripts\\fr", "LangFr",
                        "scripts\\fr\\globalfr.res", "scripts\\fr\\global.res");
                }
            }
        }

        public int ChatLines
        {
            get
            {
                int value = 0;

                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "CHAT_LINES : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { value = Convert.ToInt32(line.Substring(prefix.Length)); }

                return value;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("CHAT_LINES", value);
        }

        public int ChatDelay
        {
            get
            {
                int value = 0;

                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "CHAT_DELAY : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { value = Convert.ToInt32(line.Substring(prefix.Length)); }

                return value;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("CHAT_DELAY", value);
        }

        public int ChatAlpha
        {
            get
            {
                int value = 0;

                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "CHAT_ALPHA : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { value = Convert.ToInt32(line.Substring(prefix.Length)); }

                return value;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("CHAT_ALPHA", value);
        }
    }
}
