using Config.Net;
using System.Globalization;
using System.IO;
using System.Threading;
using SacredUtils.resources.bin.etc;

namespace SacredUtils.resources.bin.get
{
    public interface ILanguageSettings
    {
        string Language { get; set; }
    }

    public static class GetLanguage
    {
        public static void Get()
        {
            GetLoggerConfig.Log.Info("Checking availability language settings ...");

            if (!File.Exists("$SacredUtils\\conf\\langinfo.json"))
            {
                GetLoggerConfig.Log.Warn("Language settings not found! Settings will be based on system!");

                GetLoggerConfig.Log.Info("Getting default system language settings ...");

                CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

                if (currentCulture.TwoLetterISOLanguageName == "ru" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "ro" ||
                    currentCulture.TwoLetterISOLanguageName == "bg")
                {
                    File.WriteAllBytes("$SacredUtils\\conf\\langinfo.json", Properties.Resources.language);

                    ILanguageSettings languageSettings = new ConfigurationBuilder<ILanguageSettings>()
                        .UseJsonFile("$SacredUtils\\conf\\langinfo.json").Build();

                    ApplicationInfo.Lang = "ru";
                    languageSettings.Language = "ru";

                    GetLoggerConfig.Log.Info($"Language {ApplicationInfo.Lang} settings were created in conf folder");

                    GetLoggerConfig.Log.Info($"Application starting with {ApplicationInfo.Lang} language ...");
                }
                else
                {
                    File.WriteAllBytes("$SacredUtils\\conf\\langinfo.json", Properties.Resources.language);

                    ILanguageSettings languageSettings = new ConfigurationBuilder<ILanguageSettings>()
                        .UseJsonFile("$SacredUtils\\conf\\langinfo.json").Build();

                    ApplicationInfo.Lang = "en";
                    languageSettings.Language = "en";

                    GetLoggerConfig.Log.Info($"Language {ApplicationInfo.Lang} settings were created in conf folder");

                    GetLoggerConfig.Log.Info($"Application starting with {ApplicationInfo.Lang} language ...");
                }
            }
            else
            {
                GetLoggerConfig.Log.Info("Language settings found! Settings will be based on settings!");

                ILanguageSettings languageSettings = new ConfigurationBuilder<ILanguageSettings>()
                    .UseJsonFile("$SacredUtils\\conf\\langinfo.json").Build();

                ApplicationInfo.Lang = languageSettings.Language == "ru" ? "ru" : "en";

                GetLoggerConfig.Log.Info($"Application starting with {ApplicationInfo.Lang} language ...");
            }
        }
    }
}
