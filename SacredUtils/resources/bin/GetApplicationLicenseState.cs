using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using System.IO;
using System.Windows;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationLicenseState
    {
        static readonly MainWindow MainWindow = (MainWindow)Application.Current.MainWindow;

        public static void GetLicenseState()
        {
            if (!AppSettings.ApplicationSettings.AcceptLicense || !File.Exists("License.txt"))
            {
                File.WriteAllBytes("License.txt", Properties.Resources.AppLicense);

                MainWindow.UpdateLbl.IsEnabled = false; MainWindow.MinimizeBtn.IsEnabled = false;

                OpenLicenseDialog();
            }
        }

        private static void OpenLicenseDialog()
        {
            ApplicationLicenseDialog applicationLicenseDialog = new ApplicationLicenseDialog();

            MainWindow.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.DialogFrame.Content = applicationLicenseDialog;

            if (AppSettings.ApplicationSettings.ColorTheme == "dark")
            {
                applicationLicenseDialog.LicenseDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationLicenseDialog.LicenseDialog.IsOpen = true;
        }
    }
}
