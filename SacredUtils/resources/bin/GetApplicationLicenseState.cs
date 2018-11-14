using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using System;
using System.IO;
using System.Windows;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationLicenseState
    {
        static readonly MainWindow MainWindow = (MainWindow)Application.Current.MainWindow;

        public static void GetLicenseState()
        {
            Directory.CreateDirectory($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils");

            if (!File.Exists($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\LicenseAgreement.su") || !File.Exists("License.txt"))
            {
                File.WriteAllBytes("License.txt", Properties.Resources.AppLicense);

                File.WriteAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\LicenseAgreement.su", "false");

                MainWindow.UpdateLbl.IsEnabled = false; MainWindow.MinimizeBtn.IsEnabled = false;

                OpenLicenseDialog();
            }
            else if (File.ReadAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\LicenseAgreement.su").Contains("false"))
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

            if (AppSettings.ApplicationSettings.ApplicationUiColorTheme == "dark")
            {
                applicationLicenseDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationLicenseDialog.BaseDialog.IsOpen = true;
        }
    }
}
