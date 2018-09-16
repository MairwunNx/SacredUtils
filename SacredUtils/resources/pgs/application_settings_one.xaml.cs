using Config.Net;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.bin;
using SacredUtils.resources.dlg;
using System;
using System.Diagnostics;
using System.Windows;
using WPFSharp.Globalizer;

namespace SacredUtils.resources.pgs
{
    public interface ILanguageSettings
    {
        string Language { get; set; }
    }

    public interface IApplicationSettings
    {
        string SacredStartArgs { get; set; }
        string ColorTheme { get; set; } 
        string SacredUtilsGuiScale { get; set; }
    }
    
    // ReSharper disable once InconsistentNaming
    public partial class application_settings_one
    {
        application_settings_two _appStgTwo = new application_settings_two();

        int _nums = 1;

        public application_settings_one()
        {
            GetLoggerConfig.Log.Info("Gettings settings for application settings one ...");

            InitializeComponent(); GetSettings(); EventSubscribe();

            GetLoggerConfig.Log.Info("Gettings settings for application settings one done!");
        }

        public void GetSettings()
        {
            IApplicationSettings applicationSettings = new ConfigurationBuilder<IApplicationSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            ILanguageSettings languageSettings = new ConfigurationBuilder<ILanguageSettings>()
                .UseJsonFile("$SacredUtils\\conf\\langinfo.json").Build();

            UiLanguageCmbBox.SelectedIndex = languageSettings.Language == "ru" ? 0 : 1;

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

            try
            {
                int scale = Convert.ToInt32(ApplicationInfo.Scale * 100);
                UiScaleCmbBox.Text = $"{scale}%";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            EventSubscribe();
        }

        private void EventSubscribe()
        {
            if (_nums == 1)
            {
                UiLanguageCmbBox.SelectionChanged += (s, e) => ChangeLanguage();
                UiThemeCmbBox.SelectionChanged += (s, e) => ChangeTheme();
                StartParamsCmbBox.SelectionChanged += (s, e) => ChangeStart();
                UiScaleCmbBox.SelectionChanged += (s, e) => ChangeScale();


                GitHubBtn.Click += (s, e) => GoLink("https://github.com/MairwunNx/SacredUtils");
                DonateBtn.Click += (s, e) => GoLink("https://money.yandex.ru/to/410015993365458");
                CreatorBtn.Click += (s, e) => GoLink("https://t-do.ru/mairwunnx");
                FeedbackBtn.Click += (s, e) => GoLink("https://docs.google.com/forms/d/1Hx4EcS7VopBFG4bxq-zdsGUmqqD2nKy2NiwzRTiQMgA/edit?usp=sharing");
                AboutBtn.Click += (s, e) => GoAboutDialog();

                ToTwoPageBtn.Click += (s, e) => ToTwoPage();

                _nums = 2;
            }
        }

        public void GoLink(string link)
        {
            GetLoggerConfig.Log.Info($"Opening link {link}");

            Process.Start(link);
        }

        public void ToTwoPage()
        {
            foreach (Window window in Application.Current.Windows)
            {
                GetLoggerConfig.Log.Info("Teleporting to Application settings two :D ...");

                ((MainWindow) window).SettingsFrame.Content = _appStgTwo;
                ((MainWindow) window)._appStgTwo.GetSettings();

                GetLoggerConfig.Log.Info("Teleporting to Application settings two :D done!");
            }
        }

        public void GoAboutDialog()
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

            if (ApplicationInfo.Theme == "dark")
            {
                about.AboutDialog.DialogTheme = BaseTheme.Dark;
            }

            GetLoggerConfig.Log.Info("Opening application about dialog ...");

            about.AboutDialog.IsOpen = true;
        }

        private void ChangeLanguage()
        {
            GetLoggerConfig.Log.Info($"Changing lanuage to {UiLanguageCmbBox.Text} ...");

            ILanguageSettings languageSettings = new ConfigurationBuilder<ILanguageSettings>()
                .UseJsonFile("$SacredUtils\\conf\\langinfo.json").Build();

            languageSettings.Language = UiLanguageCmbBox.SelectedIndex == 0 ? "ru" : "en";

            ApplicationInfo.Lang = UiLanguageCmbBox.SelectedIndex == 0 ? "ru" : "en";

            GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage
                (UiLanguageCmbBox.SelectedIndex == 0 ? "ru-RU" : "en-US", true);

            GetLoggerConfig.Log.Info($"Changing lanuage to {UiLanguageCmbBox.Text} done!");
        }

        private void ChangeTheme()
        {
            GetLoggerConfig.Log.Info($"Changing theme to {UiThemeCmbBox.Text} ...");

            IApplicationSettings applicationSettings = new ConfigurationBuilder<IApplicationSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            applicationSettings.ColorTheme = UiThemeCmbBox.SelectedIndex == 0 ? "light" : "dark";

            ApplicationInfo.Theme = UiThemeCmbBox.SelectedIndex == 0 ? "light" : "dark";

            GlobalizedApplication.Instance.StyleManager.SwitchStyle
                (UiThemeCmbBox.SelectedIndex == 0 ? "Light.xaml" : "Dark.xaml");

            GetLoggerConfig.Log.Info($"Changing theme to {UiThemeCmbBox.Text} done!");
        }

        private void ChangeStart()
        {
            GetLoggerConfig.Log.Info($"Changing sacred startup params to {StartParamsCmbBox.Text} ...");

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

            GetLoggerConfig.Log.Info($"Changing sacred startup params to {StartParamsCmbBox.Text} done!");
        }

        private void ChangeScale()
        {
            switch (UiScaleCmbBox.SelectedIndex)
            {
                case 0:
                    ApplicationInfo.Scale = 1.0;
                    GetLoggerConfig.Log.Info($"Changed Ui scale to {UiScaleCmbBox.Text}");
                    break;
                case 1:
                    ApplicationInfo.Scale = 1.05;
                    GetLoggerConfig.Log.Info($"Changed Ui scale to {UiScaleCmbBox.Text}");
                    break;
                case 2:
                    ApplicationInfo.Scale = 1.10;
                    GetLoggerConfig.Log.Info($"Changed Ui scale to {UiScaleCmbBox.Text}");
                    break;
                case 3:
                    ApplicationInfo.Scale = 1.15;
                    GetLoggerConfig.Log.Info($"Changed Ui scale to {UiScaleCmbBox.Text}");
                    break;
                case 4:
                    ApplicationInfo.Scale = 1.25;
                    GetLoggerConfig.Log.Info($"Changed Ui scale to {UiScaleCmbBox.Text}");
                    break;
                case 5:
                    ApplicationInfo.Scale = 1.50;
                    GetLoggerConfig.Log.Info($"Changed Ui scale to {UiScaleCmbBox.Text}");
                    break;
                case 6:
                    ApplicationInfo.Scale = 1.75;
                    GetLoggerConfig.Log.Info($"Changed Ui scale to {UiScaleCmbBox.Text}");
                    break;
                case 7:
                    ApplicationInfo.Scale = 2.0;
                    GetLoggerConfig.Log.Info($"Changed Ui scale to {UiScaleCmbBox.Text}");
                    break;
            }
        }
    }
}
