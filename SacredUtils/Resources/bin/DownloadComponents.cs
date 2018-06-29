using Ionic.Zip;
using SacredUtils.Resources.wnd;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;
using static SacredUtils.Resources.bin.LanguageConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class DownloadComponents
    {
        private readonly bool _connect = NetworkInterface.GetIsNetworkAvailable();

        private int _attemps;

        public async Task DownloadManyFiles(Dictionary<Uri, string> files, string neededDirectory, string file, string extractFolder, string oldFile, string newFile, string component)
        {
            retry:

            if (_connect)
            {
                try
                {
                    Directory.CreateDirectory(neededDirectory); Directory.CreateDirectory(extractFolder);

                    if (File.Exists($"{extractFolder}\\{newFile}")) { File.Delete($"{extractFolder}\\{newFile}"); }

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(ComponentsWindow))
                        {
                            ((ComponentsWindow)window).DownloadPercent01.Content = $"{String0004} " + component + " ...";
                            ((ComponentsWindow)window).ComponentInstallName.Content = $"{String0005}" + " | " + component + " |";
                        }
                    }
//                    componentsWindow.DownloadPercent01.Content = $"{String0004} " + component + " ...";
//
//                    componentsWindow.ComponentInstallName.Content = $"{String0005}" + " | " + component + " |";

                    WebClient wc = new WebClient();

                    wc.DownloadProgressChanged += (s, e) =>
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(ComponentsWindow))
                            {
                                ((ComponentsWindow)window).DownloadProgress.Value = Convert.ToDouble(e.ProgressPercentage);
                                ((ComponentsWindow)window).DownloadPercent.Content = e.ProgressPercentage + "%";
                            }
                        }
//                        componentsWindow.DownloadProgress.Value = Convert.ToDouble(e.ProgressPercentage);
//                        componentsWindow.DownloadPercent.Content = e.ProgressPercentage + "%";
                    };

                    foreach (KeyValuePair<Uri, string> pair in files) { await wc.DownloadFileTaskAsync(pair.Key, pair.Value); }

                    wc.Dispose();

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(ComponentsWindow))
                        {
                            ((ComponentsWindow)window).DownloadProgress.IsIndeterminate = true;
                            ((ComponentsWindow)window).DownloadPercent01.Content = $"{String0006} " + component + " ...";
                            ((ComponentsWindow)window).DownloadPercent.Content = "NaN%";
                        }
                    }
//                    componentsWindow.DownloadProgress.IsIndeterminate = true;
//
//                    componentsWindow.DownloadPercent01.Content = $"{String0006} " + component + " ...";
//
//                    componentsWindow.DownloadPercent.Content = "NaN%";

                    await UnpackDownloadedFile(file, extractFolder, oldFile, newFile);
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                    
                    _attemps++;

                    if (_attemps == 4)
                    {
                        Log.Fatal(exception.ToString());

                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(ComponentsWindow))
                            {
                                ((ComponentsWindow)window).Label001.Visibility = Visibility.Visible;
                                ((ComponentsWindow)window).Label002.Visibility = Visibility.Hidden;
                                ((ComponentsWindow)window).Label000.Visibility = Visibility.Hidden;
                                ((ComponentsWindow)window).DownloadProgress.Visibility = Visibility.Hidden;
                                ((ComponentsWindow)window).ComponentInstallName.Visibility = Visibility.Hidden;
                                ((ComponentsWindow)window).DownloadPercent01.Visibility = Visibility.Hidden;
                                ((ComponentsWindow)window).DownloadPercent.Visibility = Visibility.Hidden;
                                ((ComponentsWindow)window).SpeedDownloadingLbl.Visibility = Visibility.Hidden;
                                ((ComponentsWindow)window).WarningLbl.Visibility = Visibility.Hidden;
                            }
                        }
//                        componentsWindow.Label001.Visibility = Visibility.Visible;
//                        componentsWindow.Label002.Visibility = Visibility.Hidden;
//                        componentsWindow.Label000.Visibility = Visibility.Hidden;
//                        componentsWindow.DownloadProgress.Visibility = Visibility.Hidden;
//                        componentsWindow.ComponentInstallName.Visibility = Visibility.Hidden;
//                        componentsWindow.DownloadPercent01.Visibility = Visibility.Hidden;
//                        componentsWindow.DownloadPercent.Visibility = Visibility.Hidden;
//                        componentsWindow.SpeedDownloadingLbl.Visibility = Visibility.Hidden;
//                        componentsWindow.WarningLbl.Visibility = Visibility.Hidden;

                        Thread.Sleep(10000);

                        CloseSoundWindow();
                    }

                    goto retry;
                }
            }
        }

        public void CloseSoundWindow()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            foreach (Window w in Application.Current.Windows)
            {
                if (w.GetType().Assembly == currentAssembly && w is ComponentsWindow)
                {
                    w.Close(); break;
                }
            }
        }

        public async Task UnpackDownloadedFile(string file, string extractFolder, string oldFile, string newFile) 
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(file))
                {
                    foreach (ZipEntry e in zip)
                    {
                        try
                        {
                            await Task.Run(() => e.Extract(extractFolder));

                            await Task.Run(() => File.Move($"{extractFolder}\\{oldFile}", $"{extractFolder}\\{newFile}"));
                        }

                        catch (Exception exception)
                        {
                            Log.Fatal(exception.ToString()); 
                        }
                    }
                }

                CloseSoundWindow();
            }
            catch (Exception exception)
            {
                 Log.Fatal(exception.ToString()); Environment.Exit(0);
            }
        }

        public async Task GetSoundComponent(string lang)
        {
            if (lang == "us")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/cZRhldb-3Xg9fw"), "Temp\\soundus.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\soundus.zip", "PAK", "soundus.pak", "sound.pak", $"{String0002} .US");
            }

            if (lang == "de")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/pneWkQ1b3Xg6mG"), "Temp\\soundde.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\soundde.zip", "PAK", "soundde.pak", "sound.pak", $"{String0002} .DE");
            }

            if (lang == "sp")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/maW7dmcv3Xg8cY"), "Temp\\soundsp.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\soundsp.zip", "PAK", "soundsp.pak", "sound.pak", $"{String0002} .SP");
            }

            if (lang == "ru")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/MHPKgQql3Xg8Ek"), "Temp\\soundru.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\soundru.zip", "PAK", "soundru.pak", "sound.pak", $"{String0002} .RU");
            }

            if (lang == "rugui")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/sKUKqp3W3XgcFP"), "Temp\\globalru.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\globalru.zip", "scripts\\ru", "globalru.res", "global.res", $"{String0003} .RU");
            }

            if (lang == "usgui")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/1sni8lWA3XgcFo"), "Temp\\globalus.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\globalus.zip", "scripts\\us", "globalus.res", "global.res", $"{String0003} .US");
            }

            if (lang == "degui")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/ekWsMxz13XgcEr"), "Temp\\globalde.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\globalde.zip", "scripts\\de", "globalde.res", "global.res", $"{String0003} .DE");
            }

            if (lang == "spgui")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/5n-Vslep3XgcFb"), "Temp\\globalsp.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\globalsp.zip", "scripts\\sp", "globalsp.res", "global.res", $"{String0003} .SP");
            }

            if (lang == "frgui")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/2XGSFLVL3XgcF5"), "Temp\\globalfr.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\globalfr.zip", "scripts\\fr", "globalfr.res", "global.res", $"{String0003} .FR");
            }

            if (lang == "sacred229")
            {
                String currentDirectory = Environment.CurrentDirectory; 

                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/P-gzohuQ3XgkfQ"), "Temp\\SacredPatched22914.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\SacredPatched22914.zip", currentDirectory, "SacredPatched22914.exe", "Sacred.exe", "Sacred 2.29.14");
            }

            if (lang == "sacred228")
            {
                String currentDirectory = Environment.CurrentDirectory;

                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/QRe3uOT73XgkeR"), "Temp\\SacredPatched228.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\SacredPatched228.zip", currentDirectory, "SacredPatched228.exe", "Sacred.exe", "Sacred 2.28.01");
            }

            if (lang == "server229")
            {
                String currentDirectory = Environment.CurrentDirectory;

                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/VH3BGz3D3XgkeM"), "Temp\\ServerPatched229.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\ServerPatched229.zip", currentDirectory, "ServerPatched229.exe", "Gameserver.exe", "Gamesever MulticoreFix.");
            }

            if (lang == "server228")
            {
                String currentDirectory = Environment.CurrentDirectory;

                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/Mkw_Odf63XgkeF"), "Temp\\ServerPatched228.zip");

                await DownloadManyFiles(dict, "Temp", "Temp\\ServerPatched228.zip", currentDirectory, "ServerPatched228.exe", "Gameserver.exe", "Gamesever Vanilla.");
            }
        }
    }
}