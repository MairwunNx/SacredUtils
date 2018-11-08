using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using SacredUtils.resources.prp;
using System.Diagnostics;
using System.Windows;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class ApplicationSettingsOne
    {
        public ApplicationSettingsOne()
        {
            InitializeComponent(); EventSubscribe(); DataContext = new ApplicationSettingsOneProperty(); 

            Log.Info("Initialization components for application settings one done!");
        }

        private void EventSubscribe()
        {
            GitHubBtn.Click += (s, e) => OpenLink("https://github.com/MairwunNx/SacredUtils");
            DonateBtn.Click += (s, e) => OpenDonateSelectDialog();
            CreatorBtn.Click += (s, e) => OpenPageSelectDialog();
            FeedbackBtn.Click += (s, e) => OpenLink("https://docs.google.com/forms/d/1Hx4EcS7VopBFG4bxq-zdsGUmqqD2nKy2NiwzRTiQMgA/edit?usp=sharing");
            AboutBtn.Click += (s, e) => OpenAboutDialog();

            ToTwoPageBtn.Click += (s, e) => OpenTwoPage();
        }

        private static void OpenLink(string link)
        {
            Process.Start(link); Log.Info($"{link} link was opened by user");
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

            if (AppSettings.ApplicationSettings.ApplicationUiColorTheme == "dark")
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

            if (AppSettings.ApplicationSettings.ApplicationUiColorTheme == "dark")
            {
                applicationDonateSelectDialog.DonateSelectDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationDonateSelectDialog.DonateSelectDialog.IsOpen = true;
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

            if (AppSettings.ApplicationSettings.ApplicationUiColorTheme == "dark")
            {
                applicationAboutDialog.AboutDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationAboutDialog.AboutDialog.IsOpen = true;
        }

        private static void OpenTwoPage()
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.AppStgTwo;

                Log.Info("Application settings two page was opened by user");
            }
        }
    }
}