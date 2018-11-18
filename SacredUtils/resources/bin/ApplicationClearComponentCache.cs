using System;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.arr;
using SacredUtils.resources.dlg;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace SacredUtils.resources.bin
{
    public static class ApplicationClearComponentCache
    {
        static readonly ApplicationClearCacheDialog ApplicationClearCacheDialog = new ApplicationClearCacheDialog();

        public static void SearchCacheFiles()
        {
            MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.MainWindowInstance.DialogFrame.Content = ApplicationClearCacheDialog;

            ApplicationClearCacheDialog.BaseLoadGrid.Visibility = Visibility.Visible;
            ApplicationClearCacheDialog.BaseSuccGrid.Visibility = Visibility.Hidden;
            ApplicationClearCacheDialog.BaseDialog.CloseOnClickAway = false;

            if (AppSettings.ApplicationSettings.ApplicationUiColorTheme == "dark")
            {
                ApplicationClearCacheDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
            }

            ApplicationClearCacheDialog.BaseDialog.IsOpen = true;

            Task.Run(() =>
            {
                foreach (string s in ArraySacredUtilsCacheFiles.Files)
                {
                    if (File.Exists(s))
                    {
                        try
                        {
                            File.Delete(s);
                        }
                        catch (Exception e)
                        {
                            AppLogger.Log.Error(e.ToString);
                        }
                    }
                }
            }).Wait();

            ApplicationClearCacheDialog.BaseLoadGrid.Visibility = Visibility.Hidden;
            ApplicationClearCacheDialog.BaseSuccGrid.Visibility = Visibility.Visible;
            ApplicationClearCacheDialog.BaseDialog.CloseOnClickAway = true;
        }
    }
}
