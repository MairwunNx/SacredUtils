using System.Windows;
using System.Threading.Tasks;
using SacredUtils.Resources.bin;
using SacredUtils.Resources.wnd;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loadingWindow = new LoadingWindow(); loadingWindow.Show();
            loadingWindow.InitializeComponent();

            var checkAppTempFiles = new CheckAppTempFiles();
            checkAppTempFiles.CheckAvailableTempFiles();

            Task.Run(() => Logger.InitLogger());
            
            var createImportantFiles = new CreateImportantFiles();
            Task.Run(() => createImportantFiles.CreateFiles());

            var sendDownloadStatistic = new SendDownloadStatistic();
            Task.Run(() => sendDownloadStatistic.CheckFirstInstallAsync());

            var checkAppConfiguration = new CheckAvailableConfigs();
            checkAppConfiguration.GetAvailableAppConfig();
        }
    }
}