using Config.Net;
using SacredUtils.resources.bin.change;
using SacredUtils.resources.bin.open;
using System;
using System.Threading.Tasks;
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
            EventUnsubscribe();

            IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            UiLanguageCmbBox.SelectedIndex = applicationSettings.AppUiLanguage == "ru" ? 0 : 1;

            UiThemeCmbBox.SelectedIndex = applicationSettings.ColorTheme == "light" ? 0 : 1;

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

            EventSubscribe();
        }

        private void EventUnsubscribe()
        {
            UiLanguageCmbBox.SelectionChanged -= (s, e) => ChangeLanguage();
            UiThemeCmbBox.SelectionChanged -= (s, e) => ChangeTheme();
            StartParamsCmbBox.SelectionChanged -= (s, e) => ChangeStart();
            UiScaleCmbBox.SelectionChanged -= (s, e) => ChangeScale();

            GitHubBtn.Click -= (s, e) => BrowserLink.Open("https://github.com/MairwunNx/SacredUtils");
            DonateBtn.Click -= (s, e) => BrowserLink.Open("https://money.yandex.ru/to/410015993365458");
            CreatorBtn.Click -= (s, e) => BrowserLink.Open("https://t-do.ru/mairwunnx");
            FeedbackBtn.Click -= (s, e) => BrowserLink.Open("https://docs.google.com/forms/d/1Hx4EcS7VopBFG4bxq-zdsGUmqqD2nKy2NiwzRTiQMgA/edit?usp=sharing");
            AboutBtn.Click -= (s, e) => ApplicationDialog.Open("About");

            ToTwoPageBtn.Click -= (s, e) => SettingsPage.Open("AppSettingsTwo");
        }

        private void EventSubscribe()
        {
            UiLanguageCmbBox.SelectionChanged += (s, e) => ChangeLanguage();
            UiThemeCmbBox.SelectionChanged += (s, e) => ChangeTheme();
            StartParamsCmbBox.SelectionChanged += (s, e) => ChangeStart();
            UiScaleCmbBox.SelectionChanged += (s, e) => ChangeScale();

            GitHubBtn.Click += (s, e) => BrowserLink.Open("https://github.com/MairwunNx/SacredUtils");
            DonateBtn.Click += (s, e) => BrowserLink.Open("https://money.yandex.ru/to/410015993365458");
            CreatorBtn.Click += (s, e) => BrowserLink.Open("https://t-do.ru/mairwunnx");
            FeedbackBtn.Click += (s, e) => BrowserLink.Open("https://docs.google.com/forms/d/1Hx4EcS7VopBFG4bxq-zdsGUmqqD2nKy2NiwzRTiQMgA/edit?usp=sharing");
            AboutBtn.Click += (s, e) => ApplicationDialog.Open("About");

            ToTwoPageBtn.Click += (s, e) => SettingsPage.Open("AppSettingsTwo");
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
                ApplicationScale.Change("1.0");
                AppLogger.Log.Info($"Ui scale changed to 100% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 1)
            {
                ApplicationScale.Change("1.05");
                AppLogger.Log.Info("Ui scale changed to 105% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 2)
            {
                ApplicationScale.Change("1.10");
                AppLogger.Log.Info("Ui scale changed to 110% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 3)
            {
                ApplicationScale.Change("1.15");
                AppLogger.Log.Info("Ui scale changed to 115% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 4)
            {
                ApplicationScale.Change("1.25");
                AppLogger.Log.Info("Ui scale changed to 125% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 5)
            {
                ApplicationScale.Change("1.50");
                AppLogger.Log.Info("Ui scale changed to 150% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 6)
            {
                ApplicationScale.Change("1.75");
                AppLogger.Log.Info("Ui scale changed to 175% by user");
            }
            else if (UiScaleCmbBox.SelectedIndex == 7)
            {
                ApplicationScale.Change("2.0");
                AppLogger.Log.Info("Ui scale changed to 200% by user");
            }
        }
    }
}
