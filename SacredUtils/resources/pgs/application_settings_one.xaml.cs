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
        // ReSharper disable once InconsistentNaming
        public int _nums = 1;

        public application_settings_one()
        {
            InitializeComponent(); Task.Run(() => GetSettings());

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
            ILanguageSettings languageSettings = new ConfigurationBuilder<ILanguageSettings>()
                .UseJsonFile("$SacredUtils\\conf\\langinfo.json").Build();

            languageSettings.Language = UiLanguageCmbBox.SelectedIndex == 0 ? "ru" : "en";

            AppSummary.Lang = UiLanguageCmbBox.SelectedIndex == 0 ? "ru" : "en";

            GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage
                (UiLanguageCmbBox.SelectedIndex == 0 ? "ru-RU" : "en-US", true);

            AppLogger.Log.Info($"Lanuage changed to {UiLanguageCmbBox.Text}");
        }

        private void ChangeTheme()
        {
            IApplicationSettings applicationSettings = new ConfigurationBuilder<IApplicationSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            applicationSettings.ColorTheme = UiThemeCmbBox.SelectedIndex == 0 ? "light" : "dark";

            AppSummary.Theme = UiThemeCmbBox.SelectedIndex == 0 ? "light" : "dark";

            GlobalizedApplication.Instance.StyleManager.SwitchStyle
                (UiThemeCmbBox.SelectedIndex == 0 ? "Light.xaml" : "Dark.xaml");

            AppLogger.Log.Info($"Theme changed to {UiThemeCmbBox.Text}");
        }

        private void ChangeStart()
        {
            IApplicationSettings applicationSettings = new ConfigurationBuilder<IApplicationSettings>()
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

            AppLogger.Log.Info($"Sacred startup params changed to {StartParamsCmbBox.Text}");
        }

        private void ChangeScale()
        {
            if (UiScaleCmbBox.SelectedIndex == 0)
            {
                AppSummary.Scale = 1.0;
                ApplicationScale.Change();
                AppLogger.Log.Info($"Ui scale changed to {UiScaleCmbBox.Text}");
            }
            else if (UiScaleCmbBox.SelectedIndex == 1)
            {
                AppSummary.Scale = 1.05;
                ApplicationScale.Change();
                AppLogger.Log.Info($"Ui scale changed to {UiScaleCmbBox.Text}");
            }
            else if (UiScaleCmbBox.SelectedIndex == 2)
            {
                AppSummary.Scale = 1.10;
                ApplicationScale.Change();
                AppLogger.Log.Info($"Ui scale changed to {UiScaleCmbBox.Text}");
            }
            else if (UiScaleCmbBox.SelectedIndex == 3)
            {
                AppSummary.Scale = 1.15;
                ApplicationScale.Change();
                AppLogger.Log.Info($"Ui scale changed to {UiScaleCmbBox.Text}");
            }
            else if (UiScaleCmbBox.SelectedIndex == 4)
            {
                AppSummary.Scale = 1.25;
                ApplicationScale.Change();
                AppLogger.Log.Info($"Ui scale changed to {UiScaleCmbBox.Text}");
            }
            else if (UiScaleCmbBox.SelectedIndex == 5)
            {
                AppSummary.Scale = 1.50;
                ApplicationScale.Change();
                AppLogger.Log.Info($"Ui scale changed to {UiScaleCmbBox.Text}");
            }
            else if (UiScaleCmbBox.SelectedIndex == 6)
            {
                AppSummary.Scale = 1.75;
                ApplicationScale.Change();
                AppLogger.Log.Info($"Ui scale changed to {UiScaleCmbBox.Text}");
            }
            else if (UiScaleCmbBox.SelectedIndex == 7)
            {
                AppSummary.Scale = 2.0;
                ApplicationScale.Change();
                AppLogger.Log.Info($"Ui scale changed to {UiScaleCmbBox.Text}");
            }
        }
    }
}
