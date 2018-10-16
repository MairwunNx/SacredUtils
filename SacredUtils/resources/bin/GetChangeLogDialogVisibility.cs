using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using System.IO;
using System.Windows;

namespace SacredUtils.resources.bin
{
    public static class GetChangeLogDialogVisibility
    {
        static readonly MainWindow MainWindow = (MainWindow)Application.Current.MainWindow;

        public static void Get()
        {
            if (File.Exists("$SacredUtils\\temp\\updated.su"))
            {
                if (AppSettings.ApplicationSettings.ShowChangeLog)
                {
                    ApplicationChangeLogDialog applicationChangeLogDialog = new ApplicationChangeLogDialog();

                    MainWindow.DialogFrame.Visibility = Visibility.Visible;
                    MainWindow.DialogFrame.Content = applicationChangeLogDialog;

                    if (AppSettings.ApplicationSettings.ColorTheme == "dark")
                    {
                        applicationChangeLogDialog.ChangeLogDialog.DialogTheme = BaseTheme.Dark;
                    }

                    applicationChangeLogDialog.ChangeLogDialog.IsOpen = true;

                    File.Delete("$SacredUtils\\temp\\updated.su");
                }
            }
        }
    }
}
