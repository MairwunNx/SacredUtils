using System;
using log4net;
using System.IO;
using System.Net;
using System.Windows;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Application = System.Windows.Forms.Application;

namespace SacredUtils.Resources.Core
{
    public class CheckAppUpdates
    {
        private const string AppSettings = "Settings.su";
        private const string AppVersion = "1.2R Rv4 B4 (290518)";

        private readonly WebClient _wc = new WebClient();

        private readonly bool _connect = NetworkInterface.GetIsNetworkAvailable();
        private readonly string _appname = Path.GetFileName(Application.ExecutablePath);

        private static readonly ILog Log = LogManager.GetLogger("LOGGER");
        
        public async System.Threading.Tasks.Task GetAvailableAppUpdatesAsync()
        {
            Logger.Logger.InitLogger();

            var fileText = File.ReadAllText(AppSettings);

            Log.Info("Получаем статус активности функции \"Автообновление\"");

            try
            {
                if (fileText.Contains("Automatically get and install updates = true"))
                {
                    Log.Info("Функция \"Автообновление\" включена, продолжаем работу.");

                    Log.Info("Получаем статус о наличии интернета на устройстве.");

                    try
                    {
                        if (_connect)
                        {
                            Log.Info("Соединение с интернетом на устройстве есть, продолжаем работу.");

                            Log.Info("Получаем номер последней релизной версии SacredUtils.");

                            const string appLatestVersionWeb =
                                "https://drive.google.com/uc?export=download&id=13N9ZfalxDfTAIdYxFuGBr8QPMW9OODc_";

                            Log.Info("Номер последней версии был получен без ошибок.");

                            var appLatestVersion = _wc.DownloadString(appLatestVersionWeb);

                            Log.Info("Проверяем последняя ли версия SacredUtils используется.");

                            if (!appLatestVersion.Contains(AppVersion))
                            {
                                Log.Info("Ууупсс ... Вы используете старую версию, продолжаем работу.");

                                Log.Info("Вызываем метод запуска-скачивания обновления SacredUtils.");

                                foreach (Window window in System.Windows.Application.Current.Windows)
                                {
                                    if (window.GetType() == typeof(MainWindow))
                                    {
                                        ((MainWindow) window).SettingsGrid.Visibility = Visibility.Hidden;

                                        ((MainWindow) window).UpdateGrid.Visibility = Visibility.Visible;

                                        ((MainWindow) window).NewVersionLbl.Content =
                                            $"Вы обновитесь до версии {appLatestVersion}.";
                                    }
                                }

                                await GetSacredUtilsUpdateAsync();
                            }
                            else
                            {
                                Log.Info("Прогнозы от MairwunNx показали нам, что вы используете последнюю версию.");
                            }
                        }
                        else
                        {
                            Log.Warn("Соединение с интернетом на устройстве нет, пропускаем обновление.");
                        }
                    }
                    catch (Exception exception)
                    {
                        Log.Error("Получение последней версии завершилось с ошибкой."); Log.Error(exception.ToString());
                    }
                    
                }
                else
                {
                    Log.Info("Функция \"Автообновление\" выключена, пропускаем проверки.");
                }
            }
            catch (Exception exception)
            {
                Log.Error("Получение статуса функции \"Автообновление\" завершилось с ошибкой."); Log.Error(exception.ToString());
            }
        }

        public async System.Threading.Tasks.Task GetSacredUtilsUpdateAsync()
        {
            Log.Info("Создаем временную директорию для помощника обновления.");

            try
            {
                Directory.CreateDirectory("Temp");

                Log.Info("Создание временной директории для помощника завершено без ошибок.");
            }
            catch (Exception exception)
            {
                Log.Fatal("При создании временной директории для помощника произошла ошибка."); Log.Fatal(exception.ToString());

                Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
            }

            Log.Info("Создаем помощник обновления из ресурсов SacredUtils.");

            try
            {
                File.WriteAllBytes(@"Temp" + "/" + "SacredUtilsUpdater.exe", Properties.Resources.SacredUtilsUpdater);

                Log.Info("Помощник обновления был создан из ресурсов программы.");
            }
            catch (Exception exception)
            {
                Log.Fatal("При создании помощника обновления произошла ошибка."); Log.Fatal(exception.ToString());

                Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
            }
            

            const string appLatest = @"https://drive.google.com/uc?export=download&id=1sDiiIYW0_JXMqh6IAHMOyf3IKPySCr4Q";

            Log.Info("Приступаем к скачиванию новой версии SacredUtils.");

            try
            {
                await _wc.DownloadFileTaskAsync(new Uri(appLatest), "_newVersionSacredUtilsTemp.exe");
                Log.Info("Скачивание новой версии SacredUtils завершено без ошибок.");
            }
            catch (Exception exception)
            {
                Log.Fatal("При скачивание новой версии SacredUtils произошла ошибка."); Log.Fatal(exception.ToString());

                Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
            }

            Log.Info("Запускаем помощник обновления для текущего файла.");

            try
            {
                Process.Start(@"Temp\SacredUtilsUpdater.exe", "_newVersionSacredUtilsTemp.exe " + _appname);
                Log.Info("Запуск помощника обновления завершился без ошибок.");
            }
            catch (Exception exception)
            {
                Log.Fatal("При запуске помощника обновления произошла ошибка."); Log.Fatal(exception.ToString());

                Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
            }

            Log.Info("Обновление почти завершено, перезапускаем SacredUtils.");

            try
            {
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception exception)
            {
                Log.Fatal("Я даже умереть не могу. :( Перезапуск программы завершился с ошибкой."); Log.Fatal(exception.ToString());

                Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
            }
        }
    }
}
