using MaterialDesignThemes.Wpf;
using SacredUtils.resources.bin.etc;
using SacredUtils.resources.bin.logger;
using SacredUtils.resources.dlg;
using System;
using System.Windows;

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

                    if (ApplicationInfo.Theme == "dark")
                    {
                        about.AboutDialog.DialogTheme = BaseTheme.Dark;
                    }

                    about.AboutDialog.IsOpen = true;

                    Logger.Log.Info($"{dialog} dialog was opened by user");
                }
                catch (Exception e)
                {
                    Logger.Log.Error($"Failed to open {dialog} dialog!");
                    Logger.Log.Error(e.ToString);
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

                    if (ApplicationInfo.Theme == "dark")
                    {
                        license.LicenseDialog.DialogTheme = BaseTheme.Dark;
                    }

                    license.LicenseDialog.IsOpen = true;

                    Logger.Log.Info($"{dialog} dialog was opened by user");
                }
                catch (Exception e)
                {
                    Logger.Log.Error($"Failed to open {dialog} dialog!");
                    Logger.Log.Error(e.ToString);
                }
            }
        }
    }
}
