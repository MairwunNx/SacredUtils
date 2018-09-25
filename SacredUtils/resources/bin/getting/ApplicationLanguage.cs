using Config.Net;
using SacredUtils.resources.bin.etc;
using SacredUtils.resources.bin.logger;
using System.Globalization;
using System.IO;
using System.Threading;

namespace SacredUtils.resources.bin.getting 
{
    public interface ILanguageSettings
    {
        string Language { get; set; }
    }

    public static class ApplicationLanguage
    {
        public static void Get()
        {
            Logger.Log.Info("Checking availability language settings ...");

            if (!File.Exists("$SacredUtils\\conf\\langinfo.json"))
            {
                Logger.Log.Warn("Language settings not found! Settings will be based on system!");

                Logger.Log.Info("Getting default system language settings ...");

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

                    Logger.Log.Info($"Language {ApplicationInfo.Lang} settings were created in conf folder");

                    Logger.Log.Info($"Application starting with {ApplicationInfo.Lang} language ...");
                }
                else
                {
                    File.WriteAllBytes("$SacredUtils\\conf\\langinfo.json", Properties.Resources.language);

                    ILanguageSettings languageSettings = new ConfigurationBuilder<ILanguageSettings>()
                        .UseJsonFile("$SacredUtils\\conf\\langinfo.json").Build();

                    ApplicationInfo.Lang = "en";
                    languageSettings.Language = "en";

                    Logger.Log.Info($"Language {ApplicationInfo.Lang} settings were created in conf folder");

                    Logger.Log.Info($"Application starting with {ApplicationInfo.Lang} language ...");
                }
            }
            else
            {
                Logger.Log.Info("Language settings found! Settings will be based on settings!");

                ILanguageSettings languageSettings = new ConfigurationBuilder<ILanguageSettings>()
                    .UseJsonFile("$SacredUtils\\conf\\langinfo.json").Build();

                ApplicationInfo.Lang = languageSettings.Language == "ru" ? "ru" : "en";

                Logger.Log.Info($"Application starting with {ApplicationInfo.Lang} language ...");
            }
        }
    }
}
