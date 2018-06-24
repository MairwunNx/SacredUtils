using SacredUtils.Resources.bin;
using SacredUtils.Resources.wnd;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Directory.CreateDirectory(".SacredUtilsData");
                
            var getSystemLanguage = new GetSystemLanguage();
            getSystemLanguage.GetCultureInfo();

            var loadStrings = new LoadStrings();
            loadStrings.GetStringsAsync();

            var checkLangVersion = new CheckLangVersion();
            checkLangVersion.GetLanguageVersionAsync();

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