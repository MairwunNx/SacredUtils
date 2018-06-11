using log4net;
using System.Windows;
using System.Threading.Tasks;
using SacredUtils.Resources.Core;
using SacredUtils.Resources.Logger;
using SacredUtils.Resources.Windows;

namespace SacredUtils
{
    public partial class App
    {
        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        protected override void OnStartup(StartupEventArgs e)
        {
            Log.Info("[Startup] *** Начало выполнения кода из App.xaml.cs файла. ***");

            base.OnStartup(e); var loadingWindow = new LoadingWindow();
            loadingWindow.Show();

            Log.Info("[MethodCall] Вызываем метод инициализации логгера.");

            Logger.InitLogger();

            Log.Info("[MethodCall] Вызов метода инициализации логгера завершен.");

            Log.Info("[MethodCall] Вызываем метод проверки файла отладки из другого класса.");

            var checkAppPdbFile = new CheckAppPdbFile();
            Task.Run(() => checkAppPdbFile.GetAvailablePdbFile());

            Log.Info("[MethodCall] Вызов метода проверки файла отладки завершен.");

            Log.Info("[MethodCall] Вызываем метод проверки файла лицензии из другого класса.");

            var checkAppLicenseFile = new CheckAppLicenseFile();
            Task.Run(() => checkAppLicenseFile.GetAvailableLicenseFile());

            Log.Info("[MethodCall] Вызов метода проверки файла лицензии завершен.");

            Log.Info("[MethodCall] Вызываем метод проверки конфигурации лога из другого класса.");

            var checkLogConfiguration = new CheckLogConfiguration();
            checkLogConfiguration.GetAvailableLogConfig();

            Log.Info("[MethodCall] Вызов метода проверки конфигурации лога завершен.");

            Log.Info("[MethodCall] Вызываем метод отправки статистики из другого класса.");

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