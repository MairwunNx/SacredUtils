using System.IO;
using System.Windows;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;
using Theme = SacredUtils.SourceFiles.theme.Theme;

namespace SacredUtils.SourceFiles.bin
{
    public static class GetChangeLogDialogVisibility
    {
        public static void Get()
        {
            if (!File.Exists("$SacredUtils\\temp\\updated.su") ||
                !Settings.EnableShowChangeLogAfterUpdate) return;

            ApplicationChangeLogDialog applicationChangeLogDialog = new ApplicationChangeLogDialog();

            MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.MainWindowInstance.DialogFrame.Content = applicationChangeLogDialog;

            if (Settings.ApplicationUiTheme == Theme.Dark)
            {
                applicationChangeLogDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationChangeLogDialog.BaseDialog.IsOpen = true;

            File.Delete("$SacredUtils\\temp\\updated.su");
        }
    }
}
