using System.Windows;
using System.Threading.Tasks;
using SacredUtils.Resources.Core;
using SacredUtils.Resources.Logger;
using SacredUtils.Resources.Windows;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e); Log.Info("Starting SacredUtils version 1.2.3.7.");

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

            Log.Info("[MethodCall] Вызов метода отправки статистики завершен.");

            Log.Info("[MethodCall] Вызываем метод проверки конфигурации SacredUtils из другого класса.");

            var checkAppConfiguration = new CheckAppConfiguration();
            checkAppConfiguration.GetAvailableAppConfig();

            Log.Info("[MethodCall] Вызов метода проверки конфигурации SacredUtils завершен.");

            Log.Info("[MethodCall] Вызываем метод удаления временных файлов из другого класса.");

            var checkAppTempFiles = new CheckAppTempFiles();
            checkAppTempFiles.CheckAvailableTempFiles();

            Log.Info("[MethodCall] Вызов метода удаления временных файлов завершен.");

            Log.Info("[Startup] *** Конец выполнения кода из App.xaml.cs файла. ***");
        }
    }
}