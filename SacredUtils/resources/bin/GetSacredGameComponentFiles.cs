using Ionic.Zip;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class GetSacredGameComponentFiles
    {
        static readonly GameGettingComponentsDialog GameGettingComponentsDialog = new GameGettingComponentsDialog();
        static readonly string DefaultLabelText = GameGettingComponentsDialog.GettingComponentLabel.Content.ToString();
        static readonly string DefaultLabelExtractText = GameGettingComponentsDialog.UnpackingComponentLabel.Content.ToString();

        public static void GetComponent(Uri address, string downloadPath, string downloadFileName, string extractFolder, string componentName, string oldFileName, string newFileName)
        {
            if (CheckAvailabilityInternetConnection.Connect())
            {
                MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
                MainWindow.MainWindowInstance.DialogFrame.Content = GameGettingComponentsDialog;

                if (AppSettings.ApplicationSettings.ApplicationUiColorTheme == "dark")
                {
                    GameGettingComponentsDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
                }

                if (File.Exists($"{downloadPath}\\{downloadFileName}"))
                {
                    GameGettingComponentsDialog.GettingComponentLabel.Visibility = Visibility.Hidden;
                    GameGettingComponentsDialog.UnpackingComponentLabel.Visibility = Visibility.Visible;

                    GameGettingComponentsDialog.UnpackingComponentLabel.Content = $"{DefaultLabelExtractText} {componentName} (0%) ...";

                    GameGettingComponentsDialog.BaseDialog.IsOpen = true;

                    Task.Run(() => UnpackDownloadedFile(downloadPath, downloadFileName, extractFolder, DefaultLabelText, oldFileName, newFileName, componentName));
                }
                else
                {
                    WebClient wc = new WebClient();

                    wc.DownloadProgressChanged += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new ThreadStart(delegate
                        {
                            GameGettingComponentsDialog.GettingComponentLabel.Content = $"{DefaultLabelText} {componentName} ({e.ProgressPercentage}%) ...";
                        }));
                    };

                    wc.DownloadFileCompleted += (s, e) =>
                    {
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new ThreadStart(delegate
                        {
                            GameGettingComponentsDialog.GettingComponentLabel.Visibility = Visibility.Hidden;
                            GameGettingComponentsDialog.UnpackingComponentLabel.Visibility = Visibility.Visible;
                        }));

                        Task.Run(() => UnpackDownloadedFile(downloadPath, downloadFileName, extractFolder, DefaultLabelText, oldFileName, newFileName, componentName));

                        Log.Info($"Loading sacred game component {componentName} successfully done!");

                        wc.Dispose();
                    };

                    GameGettingComponentsDialog.GettingComponentLabel.Visibility = Visibility.Visible;
                    GameGettingComponentsDialog.UnpackingComponentLabel.Visibility = Visibility.Hidden;

                    GameGettingComponentsDialog.GettingComponentLabel.Content = $"{DefaultLabelText} {componentName} (0%) ...";

                    GameGettingComponentsDialog.BaseDialog.IsOpen = true;

                    wc.DownloadFileTaskAsync(address, $"{downloadPath}\\{downloadFileName}");
                }
            }
            else
            {
                MessageBox.Show("Нет соединения с интернетом \\ No internet connection");
            }
        }

        private static void UnpackDownloadedFile(string downloadPath, string downloadFileName, string extractFolder, string defaultLabelTextArg, string oldFileName, string newFileName, string componentName)
        {
            try
            {
                Directory.CreateDirectory(extractFolder);

                using (ZipFile zip = ZipFile.Read($"{downloadPath}\\{downloadFileName}"))
                {
                    zip.ExtractProgress += (s, e) =>
                    {
                        if (e.EventType == ZipProgressEventType.Extracting_EntryBytesWritten)
                        {
                            Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new ThreadStart(delegate
                            {
                                GameGettingComponentsDialog.UnpackingComponentLabel.Content = $"{DefaultLabelExtractText} {componentName} ({(int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer)}%) ...";
                            }));
                        }
                    };

                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(extractFolder, ExtractExistingFileAction.OverwriteSilently);
                    }
                }

                File.Delete(newFileName); File.Move(oldFileName, newFileName); Thread.Sleep(1000);

                if (AppSettings.ApplicationSettings.DisableCachingGameComponents)
                {
                    File.Delete($"{downloadPath}\\{downloadFileName}");
                }

                Log.Info($"Extracting sacred game component {componentName} successfully done!");

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new ThreadStart(delegate
                {
                    GameGettingComponentsDialog.BaseDialog.IsOpen = false;
                    GameGettingComponentsDialog.GettingComponentLabel.Content = defaultLabelTextArg;
                    GameGettingComponentsDialog.UnpackingComponentLabel.Content = DefaultLabelExtractText;
                }));
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
        }
    }
}
