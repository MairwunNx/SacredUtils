using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using System.Diagnostics;
using System.Windows;

namespace SacredUtils.resources.pgs
{
    // ReSharper disable once InconsistentNaming
    public partial class application_settings_two
    {
        public application_settings_two()
        {
            InitializeComponent(); EventSubscribe();

            AppLogger.Log.Info("Initialization components for application settings two done!");
        }

        private void EventSubscribe()
        {
            UpdateCheckTglBtn.Click += (s, e) => ChangeUpdateCheck(false);
            UpdateAlphaCheckTglBtn.Click += (s, e) => ChangeUpdateCheck(true);
            MakeBackupTglBtn.Click += (s, e) => ChangeBackupMake();
            LicenseTglBtn.Click += (s, e) => ChangeLicenseAgreement();

            GitHubBtn.Click += (s, e) => OpenLink("https://github.com/MairwunNx/SacredUtils");
            DonateBtn.Click += (s, e) => OpenLink("https://money.yandex.ru/to/410015993365458");
            CreatorBtn.Click += (s, e) => OpenLink("tg://resolve?domain=MairwunNx");
            CreatorBtn.Click += (s, e) => OpenLink("mailto://MairwunNx@gmail.com");
            FeedbackBtn.Click += (s, e) => OpenLink("https://docs.google.com/forms/d/1Hx4EcS7VopBFG4bxq-zdsGUmqqD2nKy2NiwzRTiQMgA/edit?usp=sharing");
            AboutBtn.Click += (s, e) => OpenAboutDialog();

            ToOnePageBtn.Click += (s, e) => OpenOnePage();
        }

        private void ChangeUpdateCheck(bool alphaUpdate)
        {
            if (!alphaUpdate)
            {
                AppSettings.ApplicationSettings.CheckAutoUpdate = UpdateCheckTglBtn.IsChecked == true;

                AppLogger.Log.Info($"Checking for updates changed state to {AppSettings.ApplicationSettings.CheckAutoUpdate} by user");
            }
            else
            {
                AppSettings.ApplicationSettings.CheckAutoAlphaUpdate = UpdateAlphaCheckTglBtn.IsChecked == true;

                AppLogger.Log.Info($"Checking for alpha updates changed state to {AppSettings.ApplicationSettings.CheckAutoAlphaUpdate} by user");
            }
        }

        private void ChangeBackupMake()
        {
            AppSettings.ApplicationSettings.MakeAutoBackupConfigs = MakeBackupTglBtn.IsChecked == true;

            AppLogger.Log.Info($"Backup making settings changed state to {AppSettings.ApplicationSettings.MakeAutoBackupConfigs} by user");
        }

        private void ChangeLicenseAgreement()
        {
            AppSettings.ApplicationSettings.AcceptLicense = LicenseTglBtn.IsChecked == true;

            AppLogger.Log.Info($"Accept license changed state to {AppSettings.ApplicationSettings.AcceptLicense} by user");
        }

        private static void OpenLink(string link)
        {
            Process.Start(link); AppLogger.Log.Info($"{link} link was opened by user");
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

        private static void OpenOnePage()
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.AppStgOne;

                AppLogger.Log.Info("Application settings one page was opened by user");
            }
        }
    }
}