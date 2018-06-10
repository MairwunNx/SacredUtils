using System;
using log4net;
using Ionic.Zip;
using System.IO;
using System.Net;
using System.Windows;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using SacredUtils.Resources.Windows;
using System.Net.NetworkInformation;

namespace SacredUtils.Resources.Core
{
    public class DownloadComponents
    {
        private readonly bool _connect = NetworkInterface.GetIsNetworkAvailable();

        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        public async Task DownloadManyFiles(Dictionary<Uri, string> files, string neededDirectory, string file, string extractFolder, string oldFile, string newFile, string component)
        {
            try
            {
                Directory.CreateDirectory(neededDirectory); Directory.CreateDirectory(extractFolder);

                if (File.Exists(extractFolder + "/" + newFile)) { File.Delete(extractFolder + "/" + newFile); }

                SoundWindow soundWindow = new SoundWindow(); CloseSoundWindow();

                soundWindow.DownloadPercent01.Content = "Загрузка архивов " + component + " ...";

                soundWindow.ComponentInstallName.Content = "Выполняется установка компонента" + " | " + component + " |";

                WebClient wc = new WebClient();

                wc.DownloadProgressChanged += (s, e) =>
                {
                    soundWindow.DownloadProgress.Value = Convert.ToDouble(e.ProgressPercentage);
                    soundWindow.DownloadPercent.Content = e.ProgressPercentage + "%";
                };

                foreach (KeyValuePair<Uri, string> pair in files) { await wc.DownloadFileTaskAsync(pair.Key, pair.Value); }

                wc.Dispose();

                soundWindow.DownloadProgress.IsIndeterminate = true;

                soundWindow.DownloadPercent01.Content = "Распаковка и установка " + component + " ...";

                soundWindow.DownloadPercent.Content = "NaN%";

                await UnpackDownloadedFile(file, extractFolder, oldFile, newFile);
            }
            catch (Exception exception)
            {
                Log.Info(exception.ToString()); Environment.Exit(0);
            }
        }

        public void CloseSoundWindow()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            foreach (Window w in Application.Current.Windows)
            {
                if (w.GetType().Assembly == currentAssembly && w is SoundWindow)
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
        }
    }
}