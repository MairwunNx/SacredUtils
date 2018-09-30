using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using System;
using System.Windows;
using Config.Net;

namespace SacredUtils.resources.bin.open
{
    public static class ApplicationDialog
    {
        public static void Open(string dialog)
        {
            if (dialog == "About")
            {
                try
                {
                    about_dialog about = new about_dialog();

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            ((MainWindow)window).DialogFrame.Visibility = Visibility.Visible;
                            ((MainWindow)window).DialogFrame.Content = about;
                        }
                    }

                    IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                        .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                    if (applicationSettings.ColorTheme == "dark")
                    {
                        about.AboutDialog.DialogTheme = BaseTheme.Dark;
                    }

                    about.AboutDialog.IsOpen = true;

                    AppLogger.Log.Info($"{dialog} dialog was opened by user");
                }
                catch (Exception e)
                {
                    AppLogger.Log.Error($"Failed to open {dialog} dialog!");
                    AppLogger.Log.Error(e.ToString);
                }
            }

            if (dialog == "License")
            {
                try
                {
                    license_dialog license = new license_dialog();

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            ((MainWindow)window).DialogFrame.Visibility = Visibility.Visible;
                            ((MainWindow)window).DialogFrame.Content = license;
                        }
                    }

                    IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                        .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                    if (applicationSettings.ColorTheme == "dark")
                    {
                        license.LicenseDialog.DialogTheme = BaseTheme.Dark;
                    }

                    license.LicenseDialog.IsOpen = true;

                    AppLogger.Log.Info($"{dialog} dialog was opened by user");
                }
                catch (Exception e)
                {
                    AppLogger.Log.Error($"Failed to open {dialog} dialog!");
                    AppLogger.Log.Error(e.ToString);
                }
            }
        }
    }
}
