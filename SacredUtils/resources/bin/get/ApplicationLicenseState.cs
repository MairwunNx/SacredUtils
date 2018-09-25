using Config.Net;
using SacredUtils.resources.bin.open;
using System.Windows;

namespace SacredUtils.resources.bin.get
{
    public static class ApplicationLicenseState
    {
        public interface ILicenseSettings
        {
            bool AcceptLicense { get; }
        }

        public static void Get()
        {
            ILicenseSettings licenseSettings = new ConfigurationBuilder<ILicenseSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (!licenseSettings.AcceptLicense)
            {
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
