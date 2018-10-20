using SacredUtils.resources.bin;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
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
                    if (File.Exists("Sacred.exe"))
                    {
                        AboutDialog.IsOpen = false;

                        Process.Start("Sacred.exe", "CHEATS=1");

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();
                    }
                }
                else
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        AboutDialog.IsOpen = false;

                        Process.Start("Sacred.exe", "CHEATS=1");

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();
                    }
                }
            }
            else if (AppSettings.ApplicationSettings.SacredStartArgs == 1)
            {
                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        AboutDialog.IsOpen = false;

                        MainWindow.WindowState = WindowState.Minimized;

                        Process.Start("Sacred.exe", "CHEATS=1");

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();
                    }
                }
                else
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        AboutDialog.IsOpen = false;

                        MainWindow.WindowState = WindowState.Minimized;

                        Process.Start("Sacred.exe", "CHEATS=1");

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();
                    }
                }
            }
            else if (AppSettings.ApplicationSettings.SacredStartArgs == 0)
            {
                //MessageBox.Show("Notification: The mode \"Close SU before launching the game\" does not allow to emulate hot keys, screenshots and language changes.");

                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        Process.Start("Sacred.exe", "CHEATS=1");

                        Environment.Exit(0);
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

        private void EnableSwitchingLanguage()
        {
            if (RunWithEngLangCmbBox.IsChecked == true)
            {
                ForceSwitchKeyboardLanguageInGame.RegisterApplication();
            }
        }

        private void EnableStretchingScreenshot()
        { 
            if (RunWithScreenCmbBox.IsChecked == true)
            {
                ForceStretchSacredGameScreenshot.RegisterKey();
            }
        }

        private void CancelLaunchBtn_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog.IsOpen = false;
        }
    }
}
