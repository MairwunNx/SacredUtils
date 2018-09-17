using SacredUtils.resources.bin.get;
using SacredUtils.resources.pgs;
using System.Windows;

namespace SacredUtils.resources.bin.open
{
    public static class OpenNewPage
    {
        public static void Open(string settings)
        {
            application_settings_one appStgOne = new application_settings_one();
            application_settings_two appStgTwo = new application_settings_two();

            if (settings == "AppSettingsOne")
            {
                foreach (Window window in Application.Current.Windows)
                {
                    ((MainWindow)window).SettingsFrame.Content = appStgOne;
                    ((MainWindow)window)._appStgOne.GetSettings();
                    ((MainWindow)window)._appStgOne._nums = 1;
                    ((MainWindow)window)._appStgOne.EventSubscribe();

                    GetLoggerConfig.Log.Info("Application settings one page was opened by user");
                }
            }

            if (settings == "AppSettingsTwo")
            {
                foreach (Window window in Application.Current.Windows)
                {
                    ((MainWindow)window).SettingsFrame.Content = appStgTwo;
                    ((MainWindow)window)._appStgTwo.GetSettings();

                    GetLoggerConfig.Log.Info("Application settings two page was opened by user");
                }
            }
        }
    }
}
