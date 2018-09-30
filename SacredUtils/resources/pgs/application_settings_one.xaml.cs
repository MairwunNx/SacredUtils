using Config.Net;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using WPFSharp.Globalizer;

namespace SacredUtils.resources.pgs
{
    // ReSharper disable once InconsistentNaming
    public partial class application_settings_one
    {
        public application_settings_one()
        {
            InitializeComponent(); GetSettings();

            AppLogger.Log.Info("Initialization components for application settings one done!");
        }

        public void GetSettings()
        {
            IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            UiLanguageCmbBox.SelectedIndex = applicationSettings.AppUiLanguage == "ru" ? 0 : 1;

            GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage
                (UiLanguageCmbBox.SelectedIndex == 0 ? "ru-RU" : "en-US", true);

            UiThemeCmbBox.SelectedIndex = applicationSettings.ColorTheme == "light" ? 0 : 1;

            GlobalizedApplication.Instance.StyleManager.SwitchStyle
                (UiThemeCmbBox.SelectedIndex == 0 ? "Light.xaml" : "Dark.xaml");

            if (applicationSettings.SacredStartArgs == "close")
            {
                StartParamsCmbBox.SelectedIndex = 0;
            }
            else if (applicationSettings.SacredStartArgs == "minimize")
            {
                StartParamsCmbBox.SelectedIndex = 1;
            }
            else if (applicationSettings.SacredStartArgs == "none")
            {
                StartParamsCmbBox.SelectedIndex = 2;
            }

            UiScaleCmbBox.Text = $"{Convert.ToInt32(applicationSettings.SacredUtilsGuiScale * 100)}%";

            ChangeScale(applicationSettings.SacredUtilsGuiScale);

            EventSubscribe();
        }

        private void EventSubscribe()
        {
            UiLanguageCmbBox.SelectionChanged += (s, e) => ChangeLanguage();
            UiThemeCmbBox.SelectionChanged += (s, e) => ChangeTheme();
            StartParamsCmbBox.SelectionChanged += (s, e) => ChangeStart();
            UiScaleCmbBox.SelectionChanged += (s, e) => ChangeScale();

            GitHubBtn.Click += (s, e) => OpenLink("https://github.com/MairwunNx/SacredUtils");
            DonateBtn.Click += (s, e) => OpenLink("https://money.yandex.ru/to/410015993365458");
            CreatorBtn.Click += (s, e) => OpenLink("https://t-do.ru/mairwunnx");
            FeedbackBtn.Click += (s, e) => OpenLink("https://docs.google.com/forms/d/1Hx4EcS7VopBFG4bxq-zdsGUmqqD2nKy2NiwzRTiQMgA/edit?usp=sharing");
            AboutBtn.Click += (s, e) => OpenAboutDialog();

            ToTwoPageBtn.Click += (s, e) => OpenTwoPage();
        }

        private void ChangeLanguage()
        {
            IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            applicationSettings.AppUiLanguage = UiLanguageCmbBox.SelectedIndex == 0 ? "ru" : "en";

            GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage
                (UiLanguageCmbBox.SelectedIndex == 0 ? "ru-RU" : "en-US", true);

            AppLogger.Log.Info($"Language changed to {UiLanguageCmbBox.Text} by user");
        }

        private void ChangeTheme()
        {
            IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            applicationSettings.ColorTheme = UiThemeCmbBox.SelectedIndex == 0 ? "light" : "dark";

            GlobalizedApplication.Instance.StyleManager.SwitchStyle
                (UiThemeCmbBox.SelectedIndex == 0 ? "Light.xaml" : "Dark.xaml");

            AppLogger.Log.Info($"Theme changed to {UiThemeCmbBox.Text} by user");
        }

        private void ChangeStart()
        {
            IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (StartParamsCmbBox.SelectedIndex == 0)
            {
                applicationSettings.SacredStartArgs = "close";
            }

            if (StartParamsCmbBox.SelectedIndex == 1)
            {
                applicationSettings.SacredStartArgs = "minimize";
            }

            if (StartParamsCmbBox.SelectedIndex == 2)
            {
                applicationSettings.SacredStartArgs = "none";
            }

            AppLogger.Log.Info($"Sacred startup params changed to {StartParamsCmbBox.Text} by user");
        }

        private void ChangeScale()
        {
            if (UiScaleCmbBox.SelectedIndex == 0)
            {
                ChangeScale(1.0);
                AppLogger.Log.Info("Ui scale changed to 100% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 1)
            {
                ChangeScale(1.05);
                AppLogger.Log.Info("Ui scale changed to 105% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 2)
            {
                ChangeScale(1.10);
                AppLogger.Log.Info("Ui scale changed to 110% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 3)
            {
                ChangeScale(1.15);
                AppLogger.Log.Info("Ui scale changed to 115% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 4)
            {
                ChangeScale(1.25);
                AppLogger.Log.Info("Ui scale changed to 125% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 5)
            {
                ChangeScale(1.50);
                AppLogger.Log.Info("Ui scale changed to 150% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 6)
            {
                ChangeScale(1.75);
                AppLogger.Log.Info("Ui scale changed to 175% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 7)
            {
                ChangeScale(2.0);
                AppLogger.Log.Info("Ui scale changed to 200% by user");
            }
        }

        public static void ChangeScale(double scale)
        {
            try
            {
                foreach (Window window in Application.Current.Windows)
                {
                    ((MainWindow)window).Height = 720 * scale;
                    ((MainWindow)window).Width = 1086 * scale;
                    ((MainWindow)window).BaseCard.LayoutTransform = new ScaleTransform(scale, scale);
                }

                IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                    .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                applicationSettings.SacredUtilsGuiScale = scale;
            }
            catch (Exception e)
            {
                AppLogger.Log.Error("An error occurred while user changed app scale");
                AppLogger.Log.Error(e.ToString);
            }
        }

        private static void OpenLink(string link)
        {
            Process.Start(link); AppLogger.Log.Info($"{link} link was opened by user");
        }

        private void OpenAboutDialog()
        {
            try
            {
                about_dialog about = new about_dialog();

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        ((MainWindow)window).DialogFrame.Visibility = Visibility.Visible;
                        ((MainWindow)window).DialogFrame.Content = about;
                    }
                }

                IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                    .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                if (applicationSettings.ColorTheme == "dark")
                {
                    about.AboutDialog.DialogTheme = BaseTheme.Dark;
                }

                about.AboutDialog.IsOpen = true;

                AppLogger.Log.Info("About dialog was opened by user");
            }
            catch (Exception ex)
            {
                AppLogger.Log.Error("Failed to open about dialog!");
                AppLogger.Log.Error(ex.ToString);
            }
        }

        private void OpenTwoPage()
        {
            try
            {
                foreach (Window window in Application.Current.Windows)
                {
                    ((MainWindow)window).SettingsFrame.Content = ((MainWindow)window)._appStgTwo;

                    AppLogger.Log.Info("Application settings two page was opened by user");
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log.Error("An error occurred while user opened ast page");
                AppLogger.Log.Error(ex.ToString);
            }
        }
    }
}
