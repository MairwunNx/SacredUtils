using System;
using System.IO;
using System.Windows;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;
using static SacredUtils.Resources.bin.LanguageConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class CheckAppAlphaUpdates
    {
        private readonly bool _connect = NetworkInterface.GetIsNetworkAvailable();

        public async Task GetAvailableAppUpdatesAsync()
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
                            const string appLatestVersionWeb = "https://drive.google.com/uc?export=download&id=169RliOwuqtveHtq2AX9pKBHGTZw421Pu";
                            
                            var appLatestVersion = Wc.DownloadString(appLatestVersionWeb);

                            if (!appLatestVersion.Contains(AppAlphaVersion))
                            {
                                foreach (Window window in Application.Current.Windows)
                                {
                                    if (window.GetType() == typeof(MainWindow))
                                    {
                                        ((MainWindow)window).SettingsGrid.Visibility = Visibility.Hidden;

                                        ((MainWindow)window).UpdateGrid.Visibility = Visibility.Visible;

                                        ((MainWindow)window).NewVersionLbl.Content = $"{String0001} {appLatestVersion}.";
                                    }
                                }

                                await GetSacredUtilsUpdateAsync();
                            }
                            else
                            {
                                UpdateProcess = false;
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

        public async Task GetSacredUtilsUpdateAsync()
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
                await Task.Run(() => File.WriteAllBytes(AppTempFolder + "\\" + AppUpdaterExe, Properties.Resources.SacredUtilsUpdater));
            }
            catch (Exception exception)
            {
                Log.Fatal(exception.ToString()); Environment.Exit(0);
            }

            const string appLatest = @"https://drive.google.com/uc?export=download&id=1GHODz9i5dsTDzE1NX36UsMXsMMhiBiI2";

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