﻿using System.Windows;
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

            Task.Run(() => Logger.InitLogger());

            var checkAppPdbFile = new CheckAppDebugDbFile();
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