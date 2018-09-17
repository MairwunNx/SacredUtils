using System;
using SacredUtils.resources.bin.get;
using System.Windows;

namespace SacredUtils.resources.bin.open
{
    public static class OpenNewPage
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
                        ((MainWindow)window)._appStgOne.GetSettings();

                        GetLoggerConfig.Log.Info("Application settings one page was opened by user");
                    }
                }
                catch (Exception e)
                {
                    GetLoggerConfig.Log.Error("An error occurred while user opened aso page");
                    GetLoggerConfig.Log.Error(e.ToString);
                }
            }

            if (settings == "AppSettingsTwo")
            {
                try
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        ((MainWindow)window).SettingsFrame.Content = ((MainWindow)window)._appStgTwo;
                        ((MainWindow)window)._appStgTwo.GetSettings();

                        GetLoggerConfig.Log.Info("Application settings two page was opened by user");
                    }
                }
                catch (Exception e)
                {
                    GetLoggerConfig.Log.Error("An error occurred while user opened ast page");
                    GetLoggerConfig.Log.Error(e.ToString);
                }
            }
        }
    }
}
