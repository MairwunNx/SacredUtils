using System.Diagnostics;
using System.Windows;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using SacredUtils.SourceFiles.dlg;
using SacredUtils.SourceFiles.prp;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;
using Theme = SacredUtils.SourceFiles.theme.Theme;

namespace SacredUtils.SourceFiles.pgs
{
    public partial class ApplicationSettingsTwo
    {
        public ApplicationSettingsTwo()
        {
            InitializeComponent(); EventSubscribe(); DataContext = new ApplicationSettingsTwoProperty();

            Logger.Log.Info("Initialization components for application settings two done!");
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

        private static void OpenLink(string link) => Process.Start(link);

        private static void OpenDonateSelectDialog()
        {
            ApplicationDonateSelectDialog applicationDonateSelectDialog = new ApplicationDonateSelectDialog();

            MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.MainWindowInstance.DialogFrame.Content = applicationDonateSelectDialog;

            if (Settings.ApplicationUiTheme == Theme.Dark)
            {
                applicationDonateSelectDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationDonateSelectDialog.BaseDialog.IsOpen = true;
        }

        private static void OpenPageSelectDialog()
        {
            ApplicationPageSelectDialog applicationPageSelectDialog = new ApplicationPageSelectDialog();

            MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.MainWindowInstance.DialogFrame.Content = applicationPageSelectDialog;

            if (Settings.ApplicationUiTheme == Theme.Dark)
            {
                applicationPageSelectDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationPageSelectDialog.BaseDialog.IsOpen = true;
        }

        private static void OpenAboutDialog()
        {
            ApplicationAboutDialog applicationAboutDialog = new ApplicationAboutDialog();

            MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.MainWindowInstance.DialogFrame.Content = applicationAboutDialog;

            if (Settings.ApplicationUiTheme == Theme.Dark)
            {
                applicationAboutDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationAboutDialog.BaseDialog.IsOpen = true;
        }

        private static void OpenOnePage() => MainWindow.MainWindowInstance.SettingsFrame.Content = MainWindow.AppStgOne;
    }
}
