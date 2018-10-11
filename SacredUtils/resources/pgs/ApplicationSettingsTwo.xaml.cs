using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using SacredUtils.resources.prp;
using System.Diagnostics;
using System.Windows;

namespace SacredUtils.resources.pgs
{
    public partial class ApplicationSettingsTwo
    {
        public ApplicationSettingsTwo()
        {
            InitializeComponent(); EventSubscribe(); DataContext = new ApplicationSettingsTwoProperty();

            AppLogger.Log.Info("Initialization components for application settings two done!");
        }

        private void EventSubscribe()
        {
            GitHubBtn.Click += (s, e) => OpenLink("https://github.com/MairwunNx/SacredUtils");
            DonateBtn.Click += (s, e) => OpenDonateSelectDialog();
            CreatorBtn.Click += (s, e) => OpenPageSelectDialog();
            FeedbackBtn.Click += (s, e) => OpenLink("https://docs.google.com/forms/d/1Hx4EcS7VopBFG4bxq-zdsGUmqqD2nKy2NiwzRTiQMgA/edit?usp=sharing");
            AboutBtn.Click += (s, e) => OpenAboutDialog();

            ToOnePageBtn.Click += (s, e) => OpenOnePage();
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