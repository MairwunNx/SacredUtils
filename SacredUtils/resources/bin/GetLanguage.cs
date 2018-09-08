using Config.Net;
using System.Globalization;
using System.IO;
using System.Threading;

namespace SacredUtils.resources.bin
{
    public interface ILanguageSettings
    {
        int ConfigVersion { get; set; }
        string Language { get; set; }
    }

    public class GetLanguage
    {
        public void Get()
        {
            string language;
            
            GetLoggerConfig.Log.Info("Checking availability language settings");

            File.WriteAllBytes("$SacredUtils\\lang\\ru-RU\\ru-RU.xaml", Properties.Resources.ru_RU);
            File.WriteAllBytes("$SacredUtils\\lang\\en-US\\en-US.xaml", Properties.Resources.en_US);

            if (!File.Exists("$SacredUtils\\lang\\langinfo.json"))
            {
                GetLoggerConfig.Log.Warn("Language settings not found! Settings will be based on system");

                GetLoggerConfig.Log.Info("Getting default system language settings");

                CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

                if (currentCulture.TwoLetterISOLanguageName == "ru" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "ro" ||
                    currentCulture.TwoLetterISOLanguageName == "bg")
                {
                    ApplicationInfo.Lang = "ru";

//                    File.WriteAllBytes("$SacredUtils\\lang\\langinfo.json", Properties.Resources.langinfo_ru);

                    GetLoggerConfig.Log.Info("Language ru settings were created in conf folder");

                    GetLoggerConfig.Log.Info($"Application starting with {ApplicationInfo.Lang} language");
                }
                else
                {
                    Directory.CreateDirectory("$SacredUtils\\lang\\en-US");

                    ApplicationInfo.Lang = "en";

//                    File.WriteAllBytes("$SacredUtils\\lang\\langinfo.json", Properties.Resources.langinfo_en);

                    GetLoggerConfig.Log.Info("Language en settings were created in conf folder");

                    GetLoggerConfig.Log.Info($"Application starting with {ApplicationInfo.Lang} language");
                }
            }
            else
            {
                ILanguageSettings languageSettings = new ConfigurationBuilder<ILanguageSettings>()
                    .UseJsonFile("$SacredUtils\\lang\\langinfo.json").Build();

                GetLoggerConfig.Log.Info("Checking language config version");

                if (languageSettings.ConfigVersion < 1)
                {
                    GetLoggerConfig.Log.Warn("Language configuration is outdated!");

                    language = languageSettings.Language;

//                    File.WriteAllBytes("$SacredUtils\\lang\\langinfo.json", Properties.Resources.langinfo_en);

                    ILanguageSettings languageSettingsRepair = new ConfigurationBuilder<ILanguageSettings>()
                        .UseJsonFile("$SacredUtils\\lang\\langinfo.json").Build();

                    languageSettingsRepair.Language = language;

                    ApplicationInfo.Lang = languageSettingsRepair.Language == "ru" ? "ru" : "en";

                    GetLoggerConfig.Log.Info("Language information configuration has been updated");

                    GetLoggerConfig.Log.Info($"Application starting with {ApplicationInfo.Lang} language");
                }
                else
                {
                    GetLoggerConfig.Log.Info("Language configuration undamaged!");

                    ILanguageSettings languageSettingsUpdated = new ConfigurationBuilder<ILanguageSettings>()
                        .UseJsonFile("$SacredUtils\\lang\\langinfo.json").Build();

                    ApplicationInfo.Lang = languageSettingsUpdated.Language == "ru" ? "ru" : "en";

                    GetLoggerConfig.Log.Info($"Application starting with {ApplicationInfo.Lang} language");
                }
            }
        }
    }
}
