using System;
using Ionic.Zip;
using System.IO;
using System.Net;
using System.Windows;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using SacredUtils.Resources.Windows;
using System.Net.NetworkInformation;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    public class DownloadComponents
    {
        private readonly bool _connect = NetworkInterface.GetIsNetworkAvailable();

        public async Task DownloadManyFiles(Dictionary<Uri, string> files, string neededDirectory, string file, string extractFolder, string oldFile, string newFile, string component)
        {
            if (_connect)
            {
                try
                {
                    Directory.CreateDirectory(neededDirectory); Directory.CreateDirectory(extractFolder);

                    if (File.Exists(extractFolder + "/" + newFile)) { File.Delete(extractFolder + "/" + newFile); }

                    ComponentsWindow componentsWindow = new ComponentsWindow(); CloseSoundWindow();

                    componentsWindow.DownloadPercent01.Content = "Загрузка архивов " + component + " ...";

                    componentsWindow.ComponentInstallName.Content = "Выполняется установка компонента" + " | " + component + " |";

                    WebClient wc = new WebClient();

                    wc.DownloadProgressChanged += (s, e) =>
                    {
                        componentsWindow.DownloadProgress.Value = Convert.ToDouble(e.ProgressPercentage);
                        componentsWindow.DownloadPercent.Content = e.ProgressPercentage + "%";
                    };

                    foreach (KeyValuePair<Uri, string> pair in files) { await wc.DownloadFileTaskAsync(pair.Key, pair.Value); }

                    wc.Dispose();

                    componentsWindow.DownloadProgress.IsIndeterminate = true;

                    componentsWindow.DownloadPercent01.Content = "Распаковка и установка " + component + " ...";

                    componentsWindow.DownloadPercent.Content = "NaN%";

                    await UnpackDownloadedFile(file, extractFolder, oldFile, newFile);
                }
                catch (Exception exception)
                {
                    Log.Info(exception.ToString()); Environment.Exit(0);
                }
            }
            else
            {
                Log.Info("Соединение с интернетом отсутвует!");
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

                            await Task.Run(() => File.Move(extractFolder + "/" + oldFile, extractFolder + "/" + newFile));
                        }

                        catch (Exception exception)
                        {
                            Log.Info(exception.ToString()); 
                        }
                    }
                }

                CloseSoundWindow();
            }
            catch (Exception exception)
            {
                Log.Fatal("При скачивание произошла ошибка."); Log.Fatal(exception.ToString());

                Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
            }
        }

        public async Task GetSoundComponent(string lang)
        {
            if (lang == "us")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/cZRhldb-3Xg9fw"), "Temp" + "/" + "soundus.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "soundus.zip", "PAK", "soundus.pak", "sound.pak", "Озвучка .US");
            }

            if (lang == "de")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/pneWkQ1b3Xg6mG"), "Temp" + "/" + "soundde.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "soundde.zip", "PAK", "soundde.pak", "sound.pak", "Озвучка .DE");
            }

            if (lang == "sp")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/maW7dmcv3Xg8cY"), "Temp" + "/" + "soundsp.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "soundsp.zip", "PAK", "soundsp.pak", "sound.pak", "Озвучка .SP");
            }

            if (lang == "ru")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/MHPKgQql3Xg8Ek"), "Temp" + "/" + "soundru.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "soundru.zip", "PAK", "soundru.pak", "sound.pak", "Озвучка .RU");
            }

            if (lang == "rugui")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/sKUKqp3W3XgcFP"), "Temp" + "/" + "globalru.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "globalru.zip", "scripts" + "/" + "ru", "globalru.res", "global.res", "Язык GUI .RU");
            }

            if (lang == "usgui")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/1sni8lWA3XgcFo"), "Temp" + "/" + "globalus.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "globalus.zip", "scripts" + "/" + "us", "globalus.res", "global.res", "Язык GUI .US");
            }

            if (lang == "degui")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/ekWsMxz13XgcEr"), "Temp" + "/" + "globalde.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "globalde.zip", "scripts" + "/" + "de", "globalde.res", "global.res", "Язык GUI .DE");
            }

            if (lang == "spgui")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/5n-Vslep3XgcFb"), "Temp" + "/" + "globalsp.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "globalsp.zip", "scripts" + "/" + "sp", "globalsp.res", "global.res", "Язык GUI .SP");
            }

            if (lang == "frgui")
            {
                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/2XGSFLVL3XgcF5"), "Temp" + "/" + "globalfr.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "globalfr.zip", "scripts" + "/" + "fr", "globalfr.res", "global.res", "Язык GUI .FR");
            }

            if (lang == "sacred229")
            {
                String currentDirectory = Environment.CurrentDirectory; 

                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/P-gzohuQ3XgkfQ"), "Temp" + "/" + "SacredPatched22914.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "SacredPatched22914.zip", currentDirectory, "SacredPatched22914.exe", "Sacred.exe", "Sacred 2.29.14");
            }

            if (lang == "sacred228")
            {
                String currentDirectory = Environment.CurrentDirectory;

                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/QRe3uOT73XgkeR"), "Temp" + "/" + "SacredPatched228.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "SacredPatched228.zip", currentDirectory, "SacredPatched228.exe", "Sacred.exe", "Sacred 2.28.01");
            }

            if (lang == "server229")
            {
                String currentDirectory = Environment.CurrentDirectory;

                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/VH3BGz3D3XgkeM"), "Temp" + "/" + "ServerPatched229.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "ServerPatched229.zip", currentDirectory, "ServerPatched229.exe", "Gameserver.exe", "Gamesever MulticoreFix.");
            }

            if (lang == "server228")
            {
                String currentDirectory = Environment.CurrentDirectory;

                Dictionary<Uri, string> dict = new Dictionary<Uri, string>();
                dict.Add(new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/Mkw_Odf63XgkeF"), "Temp" + "/" + "ServerPatched228.zip");

                await DownloadManyFiles(dict, "Temp", "Temp" + "/" + "ServerPatched228.zip", currentDirectory, "ServerPatched228.exe", "Gameserver.exe", "Gamesever Vanilla.");
            }
        }
    }
}