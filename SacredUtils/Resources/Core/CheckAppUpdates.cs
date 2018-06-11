using System;
using System.IO;
using System.Windows;
using System.Diagnostics;
using System.Net.NetworkInformation;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    public class CheckAppUpdates
    {
        private readonly bool _connect = NetworkInterface.GetIsNetworkAvailable();
        
        public async System.Threading.Tasks.Task GetAvailableAppUpdatesAsync()
        {
            var fileText = File.ReadAllText(AppSettings);

            try
            {
                if (fileText.Contains("Automatically get and install updates = true"))
                {
                    try
                    {
                        if (_connect)
                        {
                            const string appLatestVersionWeb = "https://drive.google.com/uc?export=download&id=13N9ZfalxDfTAIdYxFuGBr8QPMW9OODc_";
                            
                            var appLatestVersion = Wc.DownloadString(appLatestVersionWeb);
                            
                            if (!appLatestVersion.Contains(AppReleaseVersion))
                            {
                                foreach (Window window in Application.Current.Windows)
                                {
                                    if (window.GetType() == typeof(MainWindow))
                                    {
                                        ((MainWindow) window).SettingsGrid.Visibility = Visibility.Hidden;

                                        ((MainWindow) window).UpdateGrid.Visibility = Visibility.Visible;

                                        ((MainWindow) window).NewVersionLbl.Content = $"Вы обновитесь до версии {appLatestVersion}.";
                                    }
                                }

                                await GetSacredUtilsUpdateAsync();
                            }
                            else
                            {
                                CheckAppAlphaUpdates checkAppAlphaUpdates = new CheckAppAlphaUpdates();

                                #pragma warning disable CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до завершения вызова.
                                checkAppAlphaUpdates.GetAvailableAppUpdatesAsync();
                                #pragma warning restore CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до завершения вызова.
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                         Log.Error(exception.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                 Log.Error(exception.ToString());
            }
        }

        public async System.Threading.Tasks.Task GetSacredUtilsUpdateAsync()
        {
            try
            {
                Directory.CreateDirectory(AppTempFolder);
            }
            catch (Exception exception)
            {
                 Log.Fatal(exception.ToString()); Environment.Exit(0);
            }

            try
            {
                File.WriteAllBytes(AppTempFolder + "/" + AppUpdaterExe, Properties.Resources.SacredUtilsUpdater);
            }
            catch (Exception exception)
            {
                 Log.Fatal(exception.ToString()); Environment.Exit(0);
            }
            
            const string appLatest = @"https://drive.google.com/uc?export=download&id=1sDiiIYW0_JXMqh6IAHMOyf3IKPySCr4Q";

            try
            {
                await Wc.DownloadFileTaskAsync(new Uri(appLatest), "_newVersionSacredUtilsTemp.exe");
            }
            catch (Exception exception)
            {
                 Log.Fatal(exception.ToString()); Environment.Exit(0);
            }

            try
            {
                Process.Start(AppTempFolder + "\\" + AppUpdaterExe, "_newVersionSacredUtilsTemp.exe " + Appname);
            }
            catch (Exception exception)
            {
                 Log.Fatal(exception.ToString()); Environment.Exit(0);
            }

            try
            {
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception exception)
            {
                 Log.Fatal(exception.ToString()); Environment.Exit(0);
            }
        }
    }
}