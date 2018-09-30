using System;
using System.Windows;

namespace SacredUtils.resources.bin.open
{
    public static class SettingsPage
    {
        public static void Open(string settings)
        {
            if (settings == "AppSettingsOne")
            {
                try
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        ((MainWindow)window).SettingsFrame.Content = ((MainWindow)window)._appStgOne;

                        AppLogger.Log.Info("Application settings one page was opened by user");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.Log.Error("An error occurred while user opened aso page");
                    AppLogger.Log.Error(ex.ToString);
                }
            }
        }
    }
}
