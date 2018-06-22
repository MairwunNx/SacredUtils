﻿using SacredUtils.Resources.bin;
using SacredUtils.Resources.wnd;
using System.Threading.Tasks;
using System.Windows;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var getSystemLanguage = new GetSystemLanguage();
            getSystemLanguage.GetCultureInfo();

            var loadStrings = new LoadStrings();
            loadStrings.GetStringsAsync();

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