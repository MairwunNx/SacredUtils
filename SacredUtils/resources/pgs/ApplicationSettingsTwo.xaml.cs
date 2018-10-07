using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using System.Diagnostics;
using System.Windows;

namespace SacredUtils.resources.pgs
{
    public partial class ApplicationSettingsTwo
    {
        public ApplicationSettingsTwo()
        {
            InitializeComponent(); GetSettings();

            AppLogger.Log.Info("Initialization components for application settings two done!");
        }

        private void GetSettings()
        {
            UpdateCheckTglBtn.IsChecked = AppSettings.ApplicationSettings.CheckAutoUpdate;
            UpdateAlphaCheckTglBtn.IsChecked = AppSettings.ApplicationSettings.CheckAutoAlphaUpdate;
            MakeBackupTglBtn.IsChecked = AppSettings.ApplicationSettings.MakeAutoBackupConfigs;
            LicenseTglBtn.IsChecked = AppSettings.ApplicationSettings.AcceptLicense;

            EventSubscribe();
        }

        private void EventSubscribe()
        {
            UpdateCheckTglBtn.Click += (s, e) => ChangeUpdateCheck(false);
            UpdateAlphaCheckTglBtn.Click += (s, e) => ChangeUpdateCheck(true);
            MakeBackupTglBtn.Click += (s, e) => ChangeBackupMake();
            LicenseTglBtn.Click += (s, e) => ChangeLicenseAgreement();

            GitHubBtn.Click += (s, e) => OpenLink("https://github.com/MairwunNx/SacredUtils");
            DonateBtn.Click += (s, e) => OpenDonateSelectDialog();
            CreatorBtn.Click += (s, e) => OpenPageSelectDialog();
            FeedbackBtn.Click += (s, e) => OpenLink("https://docs.google.com/forms/d/1Hx4EcS7VopBFG4bxq-zdsGUmqqD2nKy2NiwzRTiQMgA/edit?usp=sharing");
            AboutBtn.Click += (s, e) => OpenAboutDialog();

            ToOnePageBtn.Click += (s, e) => OpenOnePage();
        }

        private void ChangeUpdateCheck(bool alphaUpdate)
        {
            if (!alphaUpdate)
            {
                AppSettings.ApplicationSettings.CheckAutoUpdate = UpdateCheckTglBtn.IsChecked == true;

                AppLogger.Log.Info($"Checking for updates changed state to {UpdateCheckTglBtn.IsChecked} by user");
            }
            else
            {
                AppSettings.ApplicationSettings.CheckAutoAlphaUpdate = UpdateAlphaCheckTglBtn.IsChecked == true;

                AppLogger.Log.Info($"Checking for alpha updates changed state to {UpdateAlphaCheckTglBtn.IsChecked} by user");
            }
        }

        private void ChangeBackupMake()
        {
            AppSettings.ApplicationSettings.MakeAutoBackupConfigs = MakeBackupTglBtn.IsChecked == true;

            AppLogger.Log.Info($"Backup making settings changed state to {MakeBackupTglBtn.IsChecked} by user");
        }

        private void ChangeLicenseAgreement()
        {
            AppSettings.ApplicationSettings.AcceptLicense = LicenseTglBtn.IsChecked == true;

            AppLogger.Log.Info($"Accept license changed state to {LicenseTglBtn.IsChecked} by user");
        }

        private static void OpenLink(string link)
        {
            Process.Start(link); AppLogger.Log.Info($"{link} link was opened by user");
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

        private static void OpenAboutDialog()
        {
            ApplicationAboutDialog applicationAboutDialog = new ApplicationAboutDialog();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    ((MainWindow)window).DialogFrame.Visibility = Visibility.Visible;
                    ((MainWindow)window).DialogFrame.Content = applicationAboutDialog;
                }
            }

            if (AppSettings.ApplicationSettings.ColorTheme == "dark")
            {
                applicationAboutDialog.AboutDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationAboutDialog.AboutDialog.IsOpen = true;
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