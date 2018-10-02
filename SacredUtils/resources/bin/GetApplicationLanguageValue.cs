using System.Globalization;
using System.Threading;
using WPFSharp.Globalizer;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationLanguageValue
    {
        public static void Get()
        {
            if (AppSettings.ApplicationSettings.AppUiLanguage == "based on system")
            {
                AppLogger.Log.Info("Getting default system language settings ...");

                CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

                if (currentCulture.TwoLetterISOLanguageName == "ru" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "ro" ||
                    currentCulture.TwoLetterISOLanguageName == "bg")
                {
                    AppSettings.ApplicationSettings.AppUiLanguage = "ru";

                    GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage("ru-RU", true);

                    AppLogger.Log.Info("Application starting with ru language ...");
                }
                else
                {
                    AppSettings.ApplicationSettings.AppUiLanguage = "en";

                    GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage("en-US", true);

                    AppLogger.Log.Info("Application starting with en language ...");
                }
            }
            else
            {
                GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage
                    (AppSettings.ApplicationSettings.AppUiLanguage == "ru" ? "ru-RU" : "en-US", true);

                // I love you, Isabella!!!

                AppLogger.Log.Info($"Application starting with {AppSettings.ApplicationSettings.AppUiLanguage} language ...");
            }
        }
    }
}
