using System.Globalization;
using static SacredUtils.AppSettings;
using static SacredUtils.SourceFiles.Logger;
using static WPFSharp.Globalizer.GlobalizedApplication;

namespace SacredUtils.SourceFiles.language
{
    public static class LanguageValueProvider
    {
        private const string BaseLogMessage = "SacredUtils application starting with";

        public static void AssignLanguageValue()
        {
            if (ApplicationSettings.ApplicationUiLanguage == "based on system")
            {
                Log.Info("Getting default system language settings for SacredUtils ...");

                CultureInfo currentCulture = CultureInfo.InstalledUICulture;

                if (currentCulture.TwoLetterISOLanguageName == "ru" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "ro" ||
                    currentCulture.TwoLetterISOLanguageName == "bg")
                {
                    Instance.GlobalizationManager.SwitchLanguage("ru-RU", true);
                    Log.Info($"{BaseLogMessage} system ({currentCulture.Name}) language!");
                }
                else
                {
                    Instance.GlobalizationManager.SwitchLanguage("en-US", true);
                    Log.Info($"{BaseLogMessage} system ({currentCulture.Name}) language!");
                }
            }
            else
            {
                Instance.GlobalizationManager.SwitchLanguage(
                    ApplicationSettings.ApplicationUiLanguage == "ru"
                        ? "ru-RU"
                        : "en-US",
                    true
                );
                Log.Info(
                    $"{BaseLogMessage} ({ApplicationSettings.ApplicationUiLanguage}) language!");
            }
        }
    }
}
