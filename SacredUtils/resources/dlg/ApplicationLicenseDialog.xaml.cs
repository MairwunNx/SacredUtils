using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace SacredUtils.resources.dlg
{
    public partial class ApplicationLicenseDialog
    {
        public ApplicationLicenseDialog() => InitializeComponent();

        private void CloseSacredUtilsBtn_Click(object sender, RoutedEventArgs e) => Process.GetCurrentProcess().Kill();
        
        private void ReadLicenseBtn_Click(object sender, RoutedEventArgs e) => Process.Start("License.txt");

        private void AcceptLicenseBtn_Click(object sender, RoutedEventArgs e)
        {
            LicenseDialog.IsOpen = false;

            File.WriteAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\LicenseAgreement.su", "true");

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    ((MainWindow)window).UpdateLbl.IsEnabled = true;
                    ((MainWindow)window).MinimizeBtn.IsEnabled = true;
                }
            }
        }
    }
}
