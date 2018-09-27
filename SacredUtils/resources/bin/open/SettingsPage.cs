using System;
using SacredUtils.resources.bin.logger;
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

                        Logger.Log.Info("Application settings one page was opened by user");
                    }
                }
                catch (Exception e)
                {
                    Logger.Log.Error("An error occurred while user opened aso page");
                    Logger.Log.Error(e.ToString);
                }
            }

            if (settings == "AppSettingsTwo")
            {
                try
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        ((MainWindow)window).SettingsFrame.Content = ((MainWindow)window)._appStgTwo;

                        Logger.Log.Info("Application settings two page was opened by user");
                    }
                }
                catch (Exception e)
                {
                    Logger.Log.Error("An error occurred while user opened ast page");
                    Logger.Log.Error(e.ToString);
                }
            }
        }
    }
}
