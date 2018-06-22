using System;
using System.IO;
using System.Text;
using System.Windows;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class GetAppSettings
    {
        public void LoadAppSettings()
        {
            var text = File.ReadAllLines(AppSettingsFile, Encoding.ASCII);
            
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

            try
            {
                var strings = File.ReadAllLines(AppSettingsFile, Encoding.ASCII);

                if (!strings[14].Contains("Configuration file version = 1.0.0.5"))
                {
                    try
                    {
                        File.WriteAllBytes(AppSettingsFile, Properties.Resources.AppSettings);
                    }
                    catch (Exception exception)
                    {
                         Log.Error(exception.ToString());
                    }

                    if (a)
                    {
                        ChangeApplicationSettings(16,
                            "# - Automatically get and install updates = true                   #");
                    }
                    else
                    {
                        ChangeApplicationSettings(16,
                            "# - Automatically get and install updates = false                  #");
                    }

                    if (b)
                    {
                        ChangeApplicationSettings(18,
                            "# - Automatically get and install alpha updates = true             #");
                    }
                    else
                    {
                        ChangeApplicationSettings(18,
                            "# - Automatically get and install alpha updates = false            #");
                    }

                    if (c)
                    {
                        ChangeApplicationSettings(20,
                            "# - Minimize the program before launching Sacred = true            #");
                    }
                    else
                    {
                        ChangeApplicationSettings(20,
                            "# - Minimize the program before launching Sacred = false           #");
                    }

                    if (d)
                    {
                        ChangeApplicationSettings(22,
                            "# - Change the input language before running Sacred = true         #");
                    }
                    else
                    {
                        ChangeApplicationSettings(22,
                            "# - Change the input language before running Sacred = false        #");
                    }

                    if (e)
                    {
                        ChangeApplicationSettings(24,
                            "# - Close the program after launching Sacred = true                #");
                    }
                    else
                    {
                        ChangeApplicationSettings(24,
                            "# - Close the program after launching Sacred = false               #");
                    }

                    if (f)
                    {
                        ChangeApplicationSettings(26,
                            "# - Restore Settings.cfg if it is corrupted = true                 #");
                    }
                    else
                    {
                        ChangeApplicationSettings(26,
                            "# - Restore Settings.cfg if it is corrupted = false                #");
                    }

                    if (g)
                    {
                        ChangeApplicationSettings(30,
                            "# - Enable logging of all actions of the program = true            #");
                    }
                    else
                    {
                        ChangeApplicationSettings(30,
                            "# - Enable logging of all actions of the program = false           #");
                    }
                }
            }
            catch (Exception exception)
            {
                 Log.Fatal(exception.ToString()); Environment.Exit(0);
            }
        }

        public void ChangeApplicationSettings(int index, string parametr)
        {
            try
            {
                var readAllLines = File.ReadAllLines(AppSettingsFile);
                readAllLines[index] = parametr;
                File.WriteAllLines(AppSettingsFile, readAllLines);
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
        }
    }
}
