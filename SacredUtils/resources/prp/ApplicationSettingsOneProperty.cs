using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using WPFSharp.Globalizer;

namespace SacredUtils.resources.prp
{
    public class ApplicationSettingsOneProperty
    {
        public int Language
        {
            get
            {
                if (AppSettings.ApplicationSettings.AppUiLanguage == "based on system")
                {
                    return CultureInfo.InstalledUICulture.TwoLetterISOLanguageName == "ru" ? 0 : 1;
                }

                return AppSettings.ApplicationSettings.AppUiLanguage == "ru" ? 0 : 1;
            }

            set
            {
                if (value == 0)
                {
                    AppSettings.ApplicationSettings.AppUiLanguage = "ru";

                    GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage("ru-RU", true);

                    AppLogger.Log.Info("SacredUtils application language changed state to ru by user");
                }

                if (value == 1)
                {
                    AppSettings.ApplicationSettings.AppUiLanguage = "en";

                    GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage("en-US", true);

                    AppLogger.Log.Info("SacredUtils application language changed state to en by user");
                }
            }
        }
        
        public int Theme
        {
            get => AppSettings.ApplicationSettings.ColorTheme == "light" ? 0 : 1;

            set
            {
                if (value == 0)
                {
                    AppSettings.ApplicationSettings.ColorTheme = "light";

                    GlobalizedApplication.Instance.StyleManager.SwitchStyle("Light.xaml");

                    AppLogger.Log.Info("SacredUtils application theme changed state to light by user");
                }

                if (value == 1)
                {
                    AppSettings.ApplicationSettings.ColorTheme = "dark";

                    GlobalizedApplication.Instance.StyleManager.SwitchStyle("Dark.xaml");

                    AppLogger.Log.Info("SacredUtils application theme changed state to dark by user");
                }
            }
        }

        public int StartParams
        {
            get => AppSettings.ApplicationSettings.SacredStartArgs;

            set
            {
                AppSettings.ApplicationSettings.SacredStartArgs = value;

                AppLogger.Log.Info($"Sacred game startup params changed to {value} by user");
            }
        }

        public string UiScale
        {
            get => $"{Convert.ToInt32(AppSettings.ApplicationSettings.SacredUtilsGuiScale * 100)}%";

            set
            {
                if (value == "100%")
                {
                    ChangeScale(1.0); AppLogger.Log.Info("SacredUtils Ui scale changed state to 100% by user");
                }

                if (value == "105%")
                {
                    ChangeScale(1.05); AppLogger.Log.Info("SacredUtils Ui scale changed state to 105% by user");
                }

                if (value == "110%")
                {
                    ChangeScale(1.10); AppLogger.Log.Info("SacredUtils Ui scale changed state to 110% by user");
                }

                if (value == "115%")
                {
                    ChangeScale(1.15); AppLogger.Log.Info("SacredUtils Ui scale changed state to 115% by user");
                }

                if (value == "125%")
                {
                    ChangeScale(1.25); AppLogger.Log.Info("SacredUtils Ui scale changed state to 125% by user");
                }

                if (value == "150%")
                {
                    ChangeScale(1.50); AppLogger.Log.Info("SacredUtils Ui scale changed state to 150% by user");
                }

                if (value == "175%")
                {
                    ChangeScale(1.75); AppLogger.Log.Info("SacredUtils Ui scale changed state to 175% by user");
                }

                if (value == "200%")
                {
                    ChangeScale(2.0); AppLogger.Log.Info("SacredUtils Ui scale changed state to 200% by user");
                }
            }
        }

        private static void ChangeScale(double scale)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).Height = 720 * scale;
                ((MainWindow)window).Width = 1086 * scale;
                ((MainWindow)window).BaseCard.LayoutTransform = new ScaleTransform(scale, scale);
            }

            AppSettings.ApplicationSettings.SacredUtilsGuiScale = scale;
        }
    }
}
