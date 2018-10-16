using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using System.Windows;

namespace SacredUtils.resources.bin
{
    public static class ApplicationStartSacredGameFile
    {
        static readonly MainWindow MainWindow = (MainWindow)Application.Current.MainWindow;

        public static void StartDialog()
        {
            ApplicationRunSacredDialog applicationRunSacredDialog = new ApplicationRunSacredDialog();

            MainWindow.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.DialogFrame.Content = applicationRunSacredDialog;

            if (AppSettings.ApplicationSettings.ColorTheme == "dark")
            {
                applicationRunSacredDialog.AboutDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationRunSacredDialog.AboutDialog.IsOpen = true;
        }
    }
}
