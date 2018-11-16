using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using System.IO;
using System.Windows;

namespace SacredUtils.resources.bin
{
    public static class GetChangeLogDialogVisibility
    {
        public static void Get()
        {
            if (File.Exists("$SacredUtils\\temp\\updated.su"))
            {
                if (AppSettings.ApplicationSettings.ApplicationShowChangeLog)
                {
                    ApplicationChangeLogDialog applicationChangeLogDialog = new ApplicationChangeLogDialog();

                    MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
                    MainWindow.MainWindowInstance.DialogFrame.Content = applicationChangeLogDialog;

                    if (AppSettings.ApplicationSettings.ApplicationUiColorTheme == "dark")
                    {
                        applicationChangeLogDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
                    }

                    applicationChangeLogDialog.BaseDialog.IsOpen = true;

                    File.Delete("$SacredUtils\\temp\\updated.su");
                }
            }
        }
    }
}
