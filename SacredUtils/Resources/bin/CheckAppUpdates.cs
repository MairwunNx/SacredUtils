using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;
using static SacredUtils.Resources.bin.LanguageConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class CheckAppUpdates
    {
        private readonly bool _connect = NetworkInterface.GetIsNetworkAvailable();

        public async Task GetAvailableAppUpdatesAsync(string type)
        {
            var fileText = File.ReadAllText(AppSettingsFile);

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

                                        ((MainWindow) window).NewVersionLbl.Content = $"{String0001} {appLatestVersion}.";
                                    }
                                }

                                await GetSacredUtilsUpdateAsync(type);
                            }
                            else
                            {
                                CheckAppAlphaUpdates checkAppAlphaUpdates = new CheckAppAlphaUpdates();

                                #pragma warning disable CS4014 
                                checkAppAlphaUpdates.GetAvailableAppUpdatesAsync();
                                #pragma warning restore CS4014
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                         Log.Error(exception.ToString());
                    }
                }
                else
                {
                    UpdateProcess = false;
                }
            }
            catch (Exception exception)
            {
                 Log.Error(exception.ToString());
            }
        }
        
        public async Task GetSacredUtilsUpdateAsync(string type)
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
                await Task.Run(() => File.WriteAllBytes($"{AppTempFolder}\\{AppUpdaterFile}", Properties.Resources.SacredUtilsUpdater));
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
                if (type == "silent")
                {
                    var mainWindow = new MainWindow();
                    mainWindow.ChangeConfiguration(16,
                        "# - Automatically get and install updates = false                  #",
                        "Automatically get and install updates",
                        "false");
                }

                Process.Start($"{AppTempFolder}\\{AppUpdaterFile}", "_newVersionSacredUtilsTemp.exe " + AppnameFile);
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