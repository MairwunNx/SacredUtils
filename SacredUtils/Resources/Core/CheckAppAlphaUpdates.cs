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

            Log.Info("Получаем статус активности функции \"Автообновление до альфа версий\"");

            try
            {
                if (fileText.Contains("Automatically get and install alpha updates = true"))
                {
                    Log.Info("Функция \"Автообновление до альфа версий\" включена, продолжаем работу.");

                    Log.Info("Получаем статус о наличии интернета на устройстве.");

                    try
                    {
                        if (_connect)
                        {
                            Log.Info("Соединение с интернетом на устройстве есть, продолжаем работу.");

                            Log.Info("Получаем номер последней альфа версии SacredUtils.");

                            const string appLatestVersionWeb = "https://drive.google.com/uc?export=download&id=1Fc0QIxzUn7-ellW5e4_W1Wv05-V1hsJ8";

                            Log.Info("Номер последней версии был получен без ошибок.");

                            var appLatestVersion = Wc.DownloadString(appLatestVersionWeb);

                            Log.Info("Проверяем последняя ли альфа версия SacredUtils используется.");

                            if (!appLatestVersion.Contains(AppAlphaVersion))
                            {
                                Log.Info("Ууупсс ... Вы используете старую альфа версию, продолжаем работу.");

                                Log.Info("Вызываем метод запуска-скачивания обновления SacredUtils.");

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
                            else
                            {
                                Log.Info("Прогнозы от MairwunNx показали нам, что вы используете последнюю альфа версию.");
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
                    Log.Info("Функция \"Автообновление до альфа версий\" выключена, пропускаем проверки.");
                }
            }
            catch (Exception exception)
            {
                Log.Error("Получение статуса функции \"Автообновление до альфа версий\" завершилось с ошибкой."); Log.Error(exception.ToString());
            }
        }

        public async System.Threading.Tasks.Task GetSacredUtilsUpdateAsync()
        {
            Log.Info("Создаем временную директорию для помощника обновления.");

            try
            {
                Directory.CreateDirectory(AppTempFolder);

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
                File.WriteAllBytes(AppTempFolder + "/" + AppUpdaterExe, Properties.Resources.SacredUtilsUpdater);

                Log.Info("Помощник обновления был создан из ресурсов программы.");
            }
            catch (Exception exception)
            {
                Log.Fatal("При создании помощника обновления произошла ошибка."); Log.Fatal(exception.ToString());

                Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
            }

            const string appLatest = @"https://drive.google.com/uc?export=download&id=1xZzaj0v41S7nkSXkn4GWoDTkBtzeRc2Y";

            Log.Info("Приступаем к скачиванию новой версии SacredUtils.");

            try
            {
                await Wc.DownloadFileTaskAsync(new Uri(appLatest), "_newVersionSacredUtilsTemp.exe");

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
                Process.Start(AppTempFolder + "\\" + AppUpdaterExe, "_newVersionSacredUtilsTemp.exe " + Appname);

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