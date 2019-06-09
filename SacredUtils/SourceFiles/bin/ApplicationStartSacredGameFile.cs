using System.IO;
using System.Windows;
using MaterialDesignThemes.Wpf;
using SacredUtils.SourceFiles.dlg;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;
using Theme = SacredUtils.SourceFiles.theme.Theme;

namespace SacredUtils.SourceFiles.bin
{
    public static class ApplicationStartSacredGameFile
    {
        public static void StartDialog()
        {
            ApplicationRunSacredDialog applicationRunSacredDialog = new ApplicationRunSacredDialog();

            if (File.Exists(Settings.SacredExecutableFileName))
            {
                if (MainWindow.AppStgOne.StartParamsGameCmbBox.SelectedIndex == 0)
                {
                    applicationRunSacredDialog.RunWithEngLangCmbBox.IsEnabled = false;
                    applicationRunSacredDialog.RunWithScreenCmbBox.IsEnabled = false;
                    applicationRunSacredDialog.RunWithHotkeysCmbBox.IsEnabled = false;
                    applicationRunSacredDialog.RunWithDisabledWinKeyCmbBox.IsEnabled = false;
                }
            }
            else
            {
                applicationRunSacredDialog.RunWithCheatsCmbBox.IsEnabled = false;
                applicationRunSacredDialog.LaunchSacredButton.IsEnabled = false;
                applicationRunSacredDialog.RunWithEngLangCmbBox.IsEnabled = false;
                applicationRunSacredDialog.RunWithScreenCmbBox.IsEnabled = false;
                applicationRunSacredDialog.RunWithHotkeysCmbBox.IsEnabled = false;
                applicationRunSacredDialog.RunWithDisabledWinKeyCmbBox.IsEnabled = false;
            }

            MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.MainWindowInstance.DialogFrame.Content = applicationRunSacredDialog;

            if (Settings.ApplicationUiTheme == Theme.Dark)
            {
                applicationRunSacredDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationRunSacredDialog.BaseDialog.IsOpen = true;
        }
    }
}
