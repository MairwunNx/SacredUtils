using Config.Net;
using SacredUtils.resources.bin.open;
using System.IO;
using System.Windows;

namespace SacredUtils.resources.bin.getting
{
    public static class ApplicationLicenseState
    {
        public static void Get()
        {
            IAppSettings licenseSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (!licenseSettings.AcceptLicense || !File.Exists("License.txt"))
            {
                File.WriteAllBytes("License.txt", Properties.Resources.license);

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        ((MainWindow)window).UpdateLbl.IsEnabled = false;
                        ((MainWindow)window).MinimizeBtn.IsEnabled = false;
                    }
                }

                ApplicationDialog.Open("License");
            }
        }
    }
}
