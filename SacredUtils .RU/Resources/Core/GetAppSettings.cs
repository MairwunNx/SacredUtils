using System;
using log4net;
using System.IO;
using System.Text;
using System.Windows;

namespace SacredUtils.Resources.Core
{
    public class GetAppSettings
    {
        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        public void LoadAppSettings() // Загружаем настройки программы и игры.
        {
            Logger.Logger.InitLogger();

            Log.Info("Загрузка всех активных настроек SacredUtils.");

            var text = File.ReadAllLines("Settings.su", Encoding.ASCII);
            
            bool a = false; bool b = false; bool c = false; bool d = false; bool e = false; bool f = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("Automatically get and install updates = true"))
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            ((MainWindow)window).AutomaticalyInstallUpdates.IsChecked = true; a = true;
                        }
                    }

                    Log.Info("Настройка \"Automatically get and install update\" загружена.");
                }

                if (text[i].Contains("Show advanced errors-exceptions in log = true"))
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            ((MainWindow)window).AdvancedErrorLogToggleBtn.IsChecked = true; b = true;
                        }
                    }

                    Log.Info("Настройка \"Show advanced errors-exceptions in log\" загружена.");
                }

                if (text[i].Contains("Minimize the program before launching Sacred = true"))
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            ((MainWindow)window).MinimizeProgramToggleBtn.IsChecked = true; c = true;
                        }
                    }

                    Log.Info("Настройка \"Minimize the program before launching Sacred\" загружена.");
                }

                if (text[i].Contains("Change the input language before running Sacred = true"))
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            ((MainWindow)window).ChangeImputLangToggleBtn.IsChecked = true; d = true;
                        }
                    }

                    Log.Info("Настройка \"Change the input language before running Sacred\" загружена.");
                }

                if (text[i].Contains("Close the program after launching Sacred = true"))
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            ((MainWindow)window).CloseProgramToggleBtn.IsChecked = true; e = true;
                        }
                    }

                    Log.Info("Настройка \"Close the program after launching Sacred\" загружена.");
                }

                if (text[i].Contains("Restore Settings.cfg if it is corrupted = true"))
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            ((MainWindow)window).RestoreSettingsToggleBtn.IsChecked = true; f = true;
                        }
                    }

                    Log.Info("Настройка \"Restore Settings.cfg if it is corrupted\" загружена.");
                }
            }

            Log.Info("Все активные настройки SacredUtils были загружены без ошибок.");

            Log.Info("Проверка версии конфигурационного файла SacredUtils.");

            var text1 = File.ReadAllLines("Settings.su", Encoding.ASCII);

            try
            {
                if (text1[14].Contains("Configuration file version = 1.0.0.3"))
                {
                    Log.Info("Версия конфигурационного файла совместима с SacredUtils.");
                }
                else
                {
                    Log.Warn("Версия конфигурационного файла не совместима с SacredUtils.");

                    Log.Info("Создаем конфигурационный файл совместимый с SacredUtils.");

                    try
                    {
                        File.WriteAllBytes("Settings.su", Properties.Resources.AppSettings);

                        Log.Info("Файл конфигурации SacredUtils был создан без ошибок.");
                    }
                    catch (Exception exception)
                    {
                        Log.Error("При создании файла конфигурации SacredUtils произошла ошибка."); Log.Error(exception.ToString());
                    }

                    Log.Info("Восстанавливаем настройки с несовместимого конфигурационного файла.");

                    try
                    {
                        if (a)
                        {
                            var fileAllText = File.ReadAllLines("Settings.su");
                            fileAllText[16] = "# - Automatically get and install updates = true                   #";
                            File.WriteAllLines("Settings.su", fileAllText);

                            Log.Info("Настройка \"Automatically get and install update\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines("Settings.su");
                            fileAllText[16] = "# - Automatically get and install updates = false                  #";
                            File.WriteAllLines("Settings.su", fileAllText);

                            Log.Info("Настройка \"Automatically get and install update\" восстановлена.");
                        }

                        if (b)
                        {
                            var fileAllText = File.ReadAllLines("Settings.su");
                            fileAllText[18] = "# - Show advanced errors-exceptions in log = true                  #";
                            File.WriteAllLines("Settings.su", fileAllText);

                            Log.Info("Настройка \"Show advanced errors-exceptions in log\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines("Settings.su");
                            fileAllText[18] = "# - Show advanced errors-exceptions in log = false                 #";
                            File.WriteAllLines("Settings.su", fileAllText);

                            Log.Info("Настройка \"Show advanced errors-exceptions in log\" восстановлена.");
                        }

                        if (c)
                        {
                            var fileAllText = File.ReadAllLines("Settings.su");
                            fileAllText[20] = "# - Minimize the program before launching Sacred = true            #";
                            File.WriteAllLines("Settings.su", fileAllText);

                            Log.Info("Настройка \"Minimize the program before launching Sacred\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines("Settings.su");
                            fileAllText[20] = "# - Minimize the program before launching Sacred = false           #";
                            File.WriteAllLines("Settings.su", fileAllText);

                            Log.Info("Настройка \"Minimize the program before launching Sacred\" восстановлена.");
                        }

                        if (d)
                        {
                            var fileAllText = File.ReadAllLines("Settings.su");
                            fileAllText[22] = "# - Change the input language before running Sacred = true         #";
                            File.WriteAllLines("Settings.su", fileAllText);

                            Log.Info("Настройка \"Change the input language before running Sacred\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines("Settings.su");
                            fileAllText[22] = "# - Change the input language before running Sacred = false        #";
                            File.WriteAllLines("Settings.su", fileAllText);

                            Log.Info("Настройка \"Change the input language before running Sacred\" восстановлена.");
                        }

                        if (e)
                        {
                            var fileAllText = File.ReadAllLines("Settings.su");
                            fileAllText[24] = "# - Close the program after launching Sacred = true                #";
                            File.WriteAllLines("Settings.su", fileAllText);

                            Log.Info("Настройка \"Close the program after launching Sacred\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines("Settings.su");
                            fileAllText[24] = "# - Close the program after launching Sacred = false               #";
                            File.WriteAllLines("Settings.su", fileAllText);

                            Log.Info("Настройка \"Close the program after launching Sacred\" восстановлена.");
                        }

                        if (f)
                        {
                            var fileAllText = File.ReadAllLines("Settings.su");
                            fileAllText[26] = "# - Restore Settings.cfg if it is corrupted = true                 #";
                            File.WriteAllLines("Settings.su", fileAllText);

                            Log.Info("Настройка \"Restore Settings.cfg if it is corrupted\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines("Settings.su");
                            fileAllText[26] = "# - Restore Settings.cfg if it is corrupted = false                #";
                            File.WriteAllLines("Settings.su", fileAllText);

                            Log.Info("Настройка \"Restore Settings.cfg if it is corrupted\" восстановлена.");
                        }

                        Log.Info("Восстановление настроек с несовместимого файла завершилось без ошибок.");
                    }
                    catch (Exception exception)
                    {
                        Log.Fatal("Восстановление настроек с несовместимого файла завершилось с ошибкой."); Log.Error(exception.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Info("Проверка версии конфигурационного файла SacredUtils завершилось с ошибкой."); Log.Fatal(exception.ToString());
            }

        }
    }
}
