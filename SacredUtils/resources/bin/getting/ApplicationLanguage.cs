using Config.Net;
using System.Globalization;
using System.Threading;
using WPFSharp.Globalizer;

namespace SacredUtils.resources.bin.getting
{
    public static class ApplicationLanguage
    {
        public static void Get()
        {
            IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (applicationSettings.AppUiLanguage == "based on system")
            {
                AppLogger.Log.Info("Getting default system language settings ...");

                CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

                if (currentCulture.TwoLetterISOLanguageName == "ru" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "ro" ||
                    currentCulture.TwoLetterISOLanguageName == "bg")
                {
                    applicationSettings.AppUiLanguage = "ru";

                    GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage("ru-RU", true);

                    AppLogger.Log.Info("Application starting with ru language ...");
                }
                else
                {
                    applicationSettings.AppUiLanguage = "en";

                    GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage("en-US", true);

                    AppLogger.Log.Info("Application starting with en language ...");
                }
            }
            else
            {
                GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage
                    (applicationSettings.AppUiLanguage == "ru" ? "ru-RU" : "en-US", true);

                // I love you, Isabella!!!

                AppLogger.Log.Info($"Application starting with {applicationSettings.AppUiLanguage} language ...");
            }
        }
    }
}
