using System;
using System.IO;
using System.Text;
using System.Windows;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    public class GetAppSettings
    {
        public void LoadAppSettings() // Загружаем настройки программы и игры.
        {
            Log.Info("Загрузка всех активных настроек SacredUtils.");

            var text = File.ReadAllLines(AppSettings, Encoding.ASCII);
            
            bool a = false; bool b = false; bool c = false;
            bool d = false; bool e = false; bool f = false; bool g = false;

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

                if (text[i].Contains("Automatically get and install alpha updates = true"))
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            ((MainWindow)window).AdvancedErrorLogToggleBtn.IsChecked = true; b = true;
                        }
                    }

                    Log.Info("Настройка \"Automatically get and install alpha updates\" загружена.");
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

                if (text[i].Contains("Enable logging of all actions of the program = true"))
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            ((MainWindow)window).LogSacredUtilsToggleBtn.IsChecked = true; g = true;
                        }
                    }

                    Log.Info("Настройка \"Enable logging of all actions of the program\" загружена.");
                }
            }

            Log.Info("Все активные настройки SacredUtils были загружены без ошибок.");

            Log.Info("Проверка версии конфигурационного файла SacredUtils.");

            var text1 = File.ReadAllLines(AppSettings, Encoding.ASCII);

            try
            {
                if (text1[14].Contains("Configuration file version = 1.0.0.5"))
                {
                    Log.Info("Версия конфигурационного файла совместима с SacredUtils.");
                }
                else
                {
                    Log.Warn("Версия конфигурационного файла не совместима с SacredUtils.");

                    Log.Info("Создаем конфигурационный файл совместимый с SacredUtils.");

                    try
                    {
                        File.WriteAllBytes(AppSettings, Properties.Resources.AppSettings);

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
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[16] = "# - Automatically get and install updates = true                   #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Automatically get and install update\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[16] = "# - Automatically get and install updates = false                  #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Automatically get and install update\" восстановлена.");
                        }

                        if (b)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[18] = "# - Automatically get and install alpha updates = true             #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Automatically get and install alpha updates\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[18] = "# - Automatically get and install alpha updates = false            #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Automatically get and install alpha updates\" восстановлена.");
                        }

                        if (c)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[20] = "# - Minimize the program before launching Sacred = true            #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Minimize the program before launching Sacred\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[20] = "# - Minimize the program before launching Sacred = false           #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Minimize the program before launching Sacred\" восстановлена.");
                        }

                        if (d)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[22] = "# - Change the input language before running Sacred = true         #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Change the input language before running Sacred\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[22] = "# - Change the input language before running Sacred = false        #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Change the input language before running Sacred\" восстановлена.");
                        }

                        if (e)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[24] = "# - Close the program after launching Sacred = true                #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Close the program after launching Sacred\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[24] = "# - Close the program after launching Sacred = false               #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Close the program after launching Sacred\" восстановлена.");
                        }

                        if (f)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[26] = "# - Restore Settings.cfg if it is corrupted = true                 #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Restore Settings.cfg if it is corrupted\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[26] = "# - Restore Settings.cfg if it is corrupted = false                #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Restore Settings.cfg if it is corrupted\" восстановлена.");
                        }

                        if (g)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[30] = "# - Enable logging of all actions of the program = true            #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Enable logging of all actions of the program\" восстановлена.");
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[30] = "# - Enable logging of all actions of the program = false           #";
                            File.WriteAllLines(AppSettings, fileAllText);

                            Log.Info("Настройка \"Enable logging of all actions of the program\" восстановлена.");
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
