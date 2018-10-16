using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace SacredUtils.resources.dlg
{
    public partial class ApplicationRunSacredDialog
    {
        static readonly MainWindow MainWindow = (MainWindow)Application.Current.MainWindow;

        public ApplicationRunSacredDialog() => InitializeComponent();

        private void LaunchSacredBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AppSettings.ApplicationSettings.SacredStartArgs == 2)
            {
                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (RunWithEngLangCmbBox.IsChecked == true)
                    {
                        if (File.Exists("Sacred.exe"))
                        {
                            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

                            AboutDialog.IsOpen = false;

                            Process.Start("Sacred.exe", "CHEATS=1");
                        }
                    }
                    else
                    {
                        if (File.Exists("Sacred.exe"))
                        {
                            AboutDialog.IsOpen = false;

                            Process.Start("Sacred.exe", "CHEATS=1");
                        }
                    }
                }
                else
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        AboutDialog.IsOpen = false;

                        Process.Start("Sacred.exe");
                    }
                }
            }
            else if (AppSettings.ApplicationSettings.SacredStartArgs == 1)
            {
                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (RunWithEngLangCmbBox.IsChecked == true)
                    {
                        if (File.Exists("Sacred.exe"))
                        {
                            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

                            AboutDialog.IsOpen = false;

                            MainWindow.WindowState = WindowState.Minimized;

                            Process.Start("Sacred.exe", "CHEATS=1");
                        }
                    }
                    else
                    {
                        if (File.Exists("Sacred.exe"))
                        {
                            AboutDialog.IsOpen = false;

                            MainWindow.WindowState = WindowState.Minimized;

                            Process.Start("Sacred.exe", "CHEATS=1");
                        }
                    }
                }
                else
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        AboutDialog.IsOpen = false;

                        MainWindow.WindowState = WindowState.Minimized;

                        Process.Start("Sacred.exe");
                    }
                }
            }

            else if (AppSettings.ApplicationSettings.SacredStartArgs == 0)
            {
                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (RunWithEngLangCmbBox.IsChecked == true)
                    {
                        if (File.Exists("Sacred.exe"))
                        {
                            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));
                            
                            Process.Start("Sacred.exe", "CHEATS=1");

                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        if (File.Exists("Sacred.exe"))
                        {
                            Process.Start("Sacred.exe", "CHEATS=1");

                            Environment.Exit(0);
                        }
                    }
                }
                else
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        Process.Start("Sacred.exe");

                        Environment.Exit(0);
                    }
                }
            }
        }

        private void CancelLaunchBtn_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog.IsOpen = false;
        }
    }
}
