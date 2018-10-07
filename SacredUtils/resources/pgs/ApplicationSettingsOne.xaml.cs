using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using WPFSharp.Globalizer;

namespace SacredUtils.resources.pgs
{
    public partial class ApplicationSettingsOne
    {
        public ApplicationSettingsOne()
        {
            InitializeComponent(); GetSettings();

            AppLogger.Log.Info("Initialization components for application settings one done!");
        }

        private void GetSettings()
        {
            if (AppSettings.ApplicationSettings.AppUiLanguage == "based on system")
            {
                UiLanguageCmbBox.SelectedIndex = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName == "ru" ? 0 : 1;
            }
            else
            {
                UiLanguageCmbBox.SelectedIndex = AppSettings.ApplicationSettings.AppUiLanguage == "ru" ? 0 : 1;
            }

            UiThemeCmbBox.SelectedIndex = AppSettings.ApplicationSettings.ColorTheme == "light" ? 0 : 1;

            StartParamsCmbBox.SelectedIndex = AppSettings.ApplicationSettings.SacredStartArgs;

            UiScaleCmbBox.Text = $"{Convert.ToInt32(AppSettings.ApplicationSettings.SacredUtilsGuiScale * 100)}%";

            EventSubscribe();
        }

        private void EventSubscribe()
        {
            UiLanguageCmbBox.SelectionChanged += (s, e) => ChangeLanguage();
            UiThemeCmbBox.SelectionChanged += (s, e) => ChangeTheme();
            StartParamsCmbBox.SelectionChanged += (s, e) => ChangeStart();
            UiScaleCmbBox.SelectionChanged += (s, e) => ChangeScale();

            GitHubBtn.Click += (s, e) => OpenLink("https://github.com/MairwunNx/SacredUtils");
            DonateBtn.Click += (s, e) => OpenDonateSelectDialog();
            CreatorBtn.Click += (s, e) => OpenPageSelectDialog();
            FeedbackBtn.Click += (s, e) => OpenLink("https://docs.google.com/forms/d/1Hx4EcS7VopBFG4bxq-zdsGUmqqD2nKy2NiwzRTiQMgA/edit?usp=sharing");
            AboutBtn.Click += (s, e) => OpenAboutDialog();

            ToTwoPageBtn.Click += (s, e) => OpenTwoPage();
        }

        private void ChangeLanguage()
        {
            if (UiLanguageCmbBox.SelectedIndex == 0)
            {
                AppSettings.ApplicationSettings.AppUiLanguage = "ru";

                AppLogger.Log.Info("SacredUtils application language changed state to ru by user");
            }

            if (UiLanguageCmbBox.SelectedIndex == 1)
            {
                AppSettings.ApplicationSettings.AppUiLanguage = "en";

                AppLogger.Log.Info("SacredUtils application language changed state to en by user");
            }

            GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage
                (UiLanguageCmbBox.SelectedIndex == 0 ? "ru-RU" : "en-US", true);
        }

        private void ChangeTheme()
        {
            AppSettings.ApplicationSettings.ColorTheme = UiThemeCmbBox.SelectedIndex == 0 ? "light" : "dark";

            GlobalizedApplication.Instance.StyleManager.SwitchStyle
                (UiThemeCmbBox.SelectedIndex == 0 ? "Light.xaml" : "Dark.xaml");

            AppLogger.Log.Info(UiThemeCmbBox.SelectedIndex == 0
                ? "SacredUtils application theme changed state to light by user"
                : "SacredUtils application theme changed state to dark by user");
        }

        private void ChangeStart()
        {
            AppSettings.ApplicationSettings.SacredStartArgs = StartParamsCmbBox.SelectedIndex;

            AppLogger.Log.Info($"Sacred game startup params changed to {StartParamsCmbBox.SelectedIndex} by user");
        }

        private void ChangeScale()
        {
            if (UiScaleCmbBox.SelectedIndex == 0)
            {
                ChangeScale(1.0);
                AppLogger.Log.Info("SacredUtils Ui scale changed state to 100% by user");
            }

            if (UiScaleCmbBox.SelectedIndex == 1)
            {
                ChangeScale(1.05);
                AppLogger.Log.Info("SacredUtils Ui scale changed state to 105% by user");
            }

            if (UiScaleCmbBox.SelectedIndex == 2)
            {
                ChangeScale(1.10);
                AppLogger.Log.Info("SacredUtils Ui scale changed state to 110% by user");
            }

            if (UiScaleCmbBox.SelectedIndex == 3)
            {
                ChangeScale(1.15);
                AppLogger.Log.Info("SacredUtils Ui scale changed state to 115% by user");
            }

            if (UiScaleCmbBox.SelectedIndex == 4)
            {
                ChangeScale(1.25);
                AppLogger.Log.Info("SacredUtils Ui scale changed state to 125% by user");
            }

            if (UiScaleCmbBox.SelectedIndex == 5)
            {
                ChangeScale(1.50);
                AppLogger.Log.Info("SacredUtils Ui scale changed state to 150% by user");
            }

            if (UiScaleCmbBox.SelectedIndex == 6)
            {
                ChangeScale(1.75);
                AppLogger.Log.Info("SacredUtils Ui scale changed state to 175% by user");
            }

            if (UiScaleCmbBox.SelectedIndex == 7)
            {
                ChangeScale(2.0);
                AppLogger.Log.Info("SacredUtils Ui scale changed state to 200% by user");
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

        private static void OpenLink(string link)
        {
            Process.Start(link); AppLogger.Log.Info($"{link} link was opened by user");
        }

        private static void OpenPageSelectDialog()
        {
            ApplicationPageSelectDialog applicationPageSelectDialog = new ApplicationPageSelectDialog();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    ((MainWindow)window).DialogFrame.Visibility = Visibility.Visible;
                    ((MainWindow)window).DialogFrame.Content = applicationPageSelectDialog;
                }
            }

            if (AppSettings.ApplicationSettings.ColorTheme == "dark")
            {
                applicationPageSelectDialog.PageSelectDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationPageSelectDialog.PageSelectDialog.IsOpen = true;
        }

        private static void OpenDonateSelectDialog()
        {
            ApplicationDonateSelectDialog applicationDonateSelectDialog = new ApplicationDonateSelectDialog();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    ((MainWindow)window).DialogFrame.Visibility = Visibility.Visible;
                    ((MainWindow)window).DialogFrame.Content = applicationDonateSelectDialog;
                }
            }

            if (AppSettings.ApplicationSettings.ColorTheme == "dark")
            {
                applicationDonateSelectDialog.DonateSelectDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationDonateSelectDialog.DonateSelectDialog.IsOpen = true;
        }

        private static void OpenAboutDialog()
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

            if (AppSettings.ApplicationSettings.ColorTheme == "dark")
            {
                about.AboutDialog.DialogTheme = BaseTheme.Dark;
            }

            about.AboutDialog.IsOpen = true;
        }

        private static void OpenTwoPage()
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.AppStgTwo;

                AppLogger.Log.Info("Application settings two page was opened by user");
            }
        }
    }
}