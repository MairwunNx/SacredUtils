using System;
using System.IO;
using System.Windows;
using System.Diagnostics;
using System.Net.NetworkInformation;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    public class CheckAppAlphaUpdates
    {
        private readonly bool _connect = NetworkInterface.GetIsNetworkAvailable();

        public async System.Threading.Tasks.Task GetAvailableAppUpdatesAsync()
        {
            var fileText = File.ReadAllText(AppSettings);

            try
            {
                if (fileText.Contains("Automatically get and install alpha updates = true"))
                {
                    try
                    {
                        if (_connect)
                        {
                            const string appLatestVersionWeb = "https://drive.google.com/uc?export=download&id=1Fc0QIxzUn7-ellW5e4_W1Wv05-V1hsJ8";
                            
                            var appLatestVersion = Wc.DownloadString(appLatestVersionWeb);

                            if (!appLatestVersion.Contains(AppAlphaVersion))
                            {
                                foreach (Window window in Application.Current.Windows)
                                {
                                    if (window.GetType() == typeof(MainWindow))
                                    {
                                        ((MainWindow)window).SettingsGrid.Visibility = Visibility.Hidden;

                                        ((MainWindow)window).UpdateGrid.Visibility = Visibility.Visible;

                                        ((MainWindow)window).NewVersionLbl.Content = $"Вы обновитесь до версии {appLatestVersion}.";
                                    }
                                }

                                await GetSacredUtilsUpdateAsync();
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

            const string appLatest = @"https://drive.google.com/uc?export=download&id=1xZzaj0v41S7nkSXkn4GWoDTkBtzeRc2Y";

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