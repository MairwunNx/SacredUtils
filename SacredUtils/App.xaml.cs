using System.Windows;
using System.Threading.Tasks;
using SacredUtils.Resources.Core;
using SacredUtils.Resources.Logger;
using SacredUtils.Resources.Windows;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e); 

            var loadingWindow = new LoadingWindow(); loadingWindow.Show();

            Task.Run(() => Logger.InitLogger());

            var checkAppPdbFile = new CheckAppPdbFile();
            Task.Run(() => checkAppPdbFile.GetAvailablePdbFile());

            var checkAppLicenseFile = new CheckAppLicenseFile();
            Task.Run(() => checkAppLicenseFile.GetAvailableLicenseFile());

            var checkLogConfiguration = new CheckLogConfiguration();
            Task.Run(() => checkLogConfiguration.GetAvailableLogConfig());

            var sendDownloadStatistic = new SendDownloadStatistic();
            Task.Run(() => sendDownloadStatistic.CheckFirstInstallAsync());

            var checkAppConfiguration = new CheckAppConfiguration();
            checkAppConfiguration.GetAvailableAppConfig();

            var checkAppTempFiles = new CheckAppTempFiles();
            checkAppTempFiles.CheckAvailableTempFiles();
        }
    }
}