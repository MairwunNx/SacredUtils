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

        private static void OpenLink(string link) => Process.Start(link);

        private static void OpenPageSelectDialog()
        {
            ApplicationPageSelectDialog applicationPageSelectDialog = new ApplicationPageSelectDialog();

            MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.MainWindowInstance.DialogFrame.Content = applicationPageSelectDialog;

            if (AppSettings.ApplicationSettings.ApplicationUiColorTheme == "dark")
            {
                applicationPageSelectDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationPageSelectDialog.BaseDialog.IsOpen = true;
        }

        private static void OpenDonateSelectDialog()
        {
            ApplicationDonateSelectDialog applicationDonateSelectDialog = new ApplicationDonateSelectDialog();

            MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.MainWindowInstance.DialogFrame.Content = applicationDonateSelectDialog;

            if (AppSettings.ApplicationSettings.ApplicationUiColorTheme == "dark")
            {
                applicationDonateSelectDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationDonateSelectDialog.BaseDialog.IsOpen = true;
        }

        private static void OpenAboutDialog()
        {
            ApplicationAboutDialog applicationAboutDialog = new ApplicationAboutDialog();

            MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.MainWindowInstance.DialogFrame.Content = applicationAboutDialog;

            if (AppSettings.ApplicationSettings.ApplicationUiColorTheme == "dark")
            {
                applicationAboutDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationAboutDialog.BaseDialog.IsOpen = true;
        }

        private static void OpenTwoPage() => MainWindow.MainWindowInstance.SettingsFrame.Content = MainWindow.AppStgTwo;
    }
}