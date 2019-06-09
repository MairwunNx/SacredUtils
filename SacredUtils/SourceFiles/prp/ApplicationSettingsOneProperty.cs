using System;
using System.Globalization;
using System.Windows.Media;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;
using static WPFSharp.Globalizer.GlobalizedApplication;

namespace SacredUtils.SourceFiles.prp
{
    public class ApplicationSettingsOneProperty
    {
        public int Language
        {
            get
            {
                if (Settings.ApplicationUiLanguage == language.Language.BasedOnSystem)
                {
                    return CultureInfo.InstalledUICulture.TwoLetterISOLanguageName == "ru" ? 0 : 1;
                }

                return Settings.ApplicationUiLanguage == language.Language.RuRu ? 0 : 1;
            }

            set
            {
                switch (value)
                {
                    case 0:
                        Settings.ApplicationUiLanguage = language.Language.RuRu;

                        Instance.GlobalizationManager.SwitchLanguage(
                            "ru-RU",
                            true
                        );
                        break;
                    case 1:
                        Settings.ApplicationUiLanguage = language.Language.EnUs;

                        Instance.GlobalizationManager.SwitchLanguage(
                            "en-US",
                            true
                        );
                        break;
                }

                Logger.Log.Info(
                    $"SacredUtils application language changed state to {Settings.ApplicationUiLanguage} by user"
                );
            }
        }

        public int Theme
        {
            get => Settings.ApplicationUiTheme == theme.Theme.Light ? 0 : 1;

            set
            {
                switch (value)
                {
                    case 0:
                        Settings.ApplicationUiTheme = theme.Theme.Light;

                        Instance.StyleManager.SwitchStyle("light.xaml");

                        Logger.Log.Info(
                            "SacredUtils application theme changed state to light by user");
                        break;
                    case 1:
                        Settings.ApplicationUiTheme = theme.Theme.Dark;

                        Instance.StyleManager.SwitchStyle("dark.xaml");
                        break;
                }

                Logger.Log.Info(
                    $"SacredUtils application theme changed state to {Settings.ApplicationUiTheme} by user"
                );
            }
        }

        public int StartParams
        {
            get => Settings.SacredStartArgs;

            set
            {
                Settings.SacredStartArgs = value;
                Logger.Log.Info($"Sacred game startup params changed to {value} by user");
            }
        }

        public string UiScale
        {
            get => $"{Convert.ToInt32(Settings.ApplicationGuiScale * 100)}%";

            set
            {
                ChangeScale(Convert.ToDouble(value.Replace("%", "")) / 100D);
                Logger.Log.Info($"SacredUtils Ui scale changed state to {value} by user");
            }
        }

        private static void ChangeScale(double scale)
        {
            MainWindow.MainWindowInstance.Height = 720 * scale;
            MainWindow.MainWindowInstance.Width = 1086 * scale;
            MainWindow.MainWindowInstance.BaseCard.LayoutTransform =
                new ScaleTransform(scale, scale);

            Settings.ApplicationGuiScale = scale;
        }
    }
}
