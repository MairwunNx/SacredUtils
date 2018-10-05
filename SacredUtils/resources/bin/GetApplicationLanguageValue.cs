using System.Globalization;
using WPFSharp.Globalizer;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationLanguageValue
    {
        public static void Get() // I love you, Isabella!!!
        {
            if (AppSettings.ApplicationSettings.AppUiLanguage == "based on system")
            {
                AppLogger.Log.Info("Getting default system language settings for SacredUtils ...");

                CultureInfo currentCulture = CultureInfo.InstalledUICulture;

                if (currentCulture.TwoLetterISOLanguageName == "ru" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "ro" ||
                    currentCulture.TwoLetterISOLanguageName == "bg")
                {
                    GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage("ru-RU", true);

                    AppLogger.Log.Info($"SacredUtils application starting with system ({currentCulture.Name}) language!");
                }
                else
                {
                    GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage("en-US", true);

                    AppLogger.Log.Info($"SacredUtils application starting with system ({currentCulture.Name}) language!");
                }
            }
            else
            {
                GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage
                    (AppSettings.ApplicationSettings.AppUiLanguage == "ru" ? "ru-RU" : "en-US", true);

                AppLogger.Log.Info($"SacredUtils application starting with ({AppSettings.ApplicationSettings.AppUiLanguage}) language!");
            }
        }
    }
}
