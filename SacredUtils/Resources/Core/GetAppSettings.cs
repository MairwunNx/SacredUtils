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
                }
            }

            var text1 = File.ReadAllLines(AppSettings, Encoding.ASCII);

            try
            {
                if (!text1[14].Contains("Configuration file version = 1.0.0.5"))
                {
                    try
                    {
                        File.WriteAllBytes(AppSettings, Properties.Resources.AppSettings);
                    }
                    catch (Exception exception)
                    {
                         Log.Error(exception.ToString());
                    }

                    try
                    {
                        if (a)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[16] = "# - Automatically get and install updates = true                   #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[16] = "# - Automatically get and install updates = false                  #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }

                        if (b)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[18] = "# - Automatically get and install alpha updates = true             #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[18] = "# - Automatically get and install alpha updates = false            #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }

                        if (c)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[20] = "# - Minimize the program before launching Sacred = true            #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[20] = "# - Minimize the program before launching Sacred = false           #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }

                        if (d)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[22] = "# - Change the input language before running Sacred = true         #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[22] = "# - Change the input language before running Sacred = false        #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }

                        if (e)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[24] = "# - Close the program after launching Sacred = true                #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[24] = "# - Close the program after launching Sacred = false               #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }

                        if (f)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[26] = "# - Restore Settings.cfg if it is corrupted = true                 #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[26] = "# - Restore Settings.cfg if it is corrupted = false                #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }

                        if (g)
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[30] = "# - Enable logging of all actions of the program = true            #";
                            File.WriteAllLines(AppSettings, fileAllText);
                        }
                        else
                        {
                            var fileAllText = File.ReadAllLines(AppSettings);
                            fileAllText[30] = "# - Enable logging of all actions of the program = false           #";
                            File.WriteAllLines(AppSettings, fileAllText);
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
                 Log.Fatal(exception.ToString());
            }
        }
    }
}
