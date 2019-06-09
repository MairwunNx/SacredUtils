using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.arr;
using SacredUtils.resources.dlg;
using SacredUtils.SourceFiles.settings;
using Theme = SacredUtils.SourceFiles.theme.Theme;

namespace SacredUtils.SourceFiles.bin
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

            if (ApplicationSettingsManager.Settings.ApplicationUiTheme == Theme.Dark)
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
                        try { File.Delete(s); }
                        catch (Exception e) { Logger.Log.Error(e.ToString); }
                    }
                }
            }).Wait();

            ApplicationClearCacheDialog.BaseLoadGrid.Visibility = Visibility.Hidden;
            ApplicationClearCacheDialog.BaseSuccGrid.Visibility = Visibility.Visible;
            ApplicationClearCacheDialog.BaseDialog.CloseOnClickAway = true;
        }
    }
}
