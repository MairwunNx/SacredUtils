using Config.Net;
using System.Diagnostics;
using System.Windows;

namespace SacredUtils.resources.dlg
{
    // ReSharper disable once InconsistentNaming
    public partial class license_dialog
    {
        public interface ILicenseSettings
        {
            bool AcceptLicense { get; set; }
        }

        public license_dialog()
        {
            InitializeComponent();
        }

        private void CloseSacredUtilsBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void AcceptLicenseBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LicenseDialog.IsOpen = false;

            ILicenseSettings licenseSettings = new ConfigurationBuilder<ILicenseSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            licenseSettings.AcceptLicense = true;

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    ((MainWindow)window).UpdateLbl.IsEnabled = true;
                    ((MainWindow)window).MinimizeBtn.IsEnabled = true;
                }
            }
        }

        private void ReadLicenseBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("License.txt");
        }
    }
}
