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

namespace SacredUtils.resources.bin
{
    public static class GetSacredGameComponentFiles
    {
        static GameGettingComponentsDialog _gameGettingComponentsDialog = new GameGettingComponentsDialog();
        static string defaultLabelText = _gameGettingComponentsDialog.GettingComponentLabel.Content.ToString();
        static string defaultLabelExtractText = _gameGettingComponentsDialog.UnpackingComponentLabel.Content.ToString();

        public static void GetComponent(Uri address, string downloadPath, string downloadFileName, string extractFolder, string componentName, string oldFileName, string newFileName)
        {
            try
            {
                if (CheckAvailabilityInternetConnection.Connect())
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        ((MainWindow)window).DialogFrame.Visibility = Visibility.Visible;
                        ((MainWindow)window).DialogFrame.Content = _gameGettingComponentsDialog;
                    }

                    if (AppSettings.ApplicationSettings.ColorTheme == "dark")
                    {
                        _gameGettingComponentsDialog.GetComponentsDialog.DialogTheme = BaseTheme.Dark;
                    }

                    if (File.Exists($"{downloadPath}\\{downloadFileName}"))
                    {
                        _gameGettingComponentsDialog.GettingComponentLabel.Visibility = Visibility.Hidden;
                        _gameGettingComponentsDialog.UnpackingComponentLabel.Visibility = Visibility.Visible;

                        _gameGettingComponentsDialog.UnpackingComponentLabel.Content = $"{defaultLabelExtractText} {componentName} (0%) ...";

                        _gameGettingComponentsDialog.GetComponentsDialog.IsOpen = true;

                        Task.Run(() =>
                        {
                            UnpackDownloadedFile(downloadPath, downloadFileName, extractFolder, defaultLabelText, oldFileName, newFileName, componentName);
                        });
                    }
                    else
                    {
                        WebClient wc = new WebClient();

                        wc.DownloadProgressChanged += (s, e) =>
                        {
                            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                            {
                                _gameGettingComponentsDialog.GettingComponentLabel.Content = $"{defaultLabelText} {componentName} ({e.ProgressPercentage}%) ...";
                            }));
                        };

                        wc.DownloadFileCompleted += (s, e) =>
                        {
                            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                            {
                                _gameGettingComponentsDialog.GettingComponentLabel.Visibility = Visibility.Hidden;
                                _gameGettingComponentsDialog.UnpackingComponentLabel.Visibility = Visibility.Visible;
                            }));

                            Task.Run(() => UnpackDownloadedFile(downloadPath, downloadFileName, extractFolder, defaultLabelText, oldFileName, newFileName, componentName));

                            AppLogger.Log.Info($"Loading sacred game component {componentName} successfully done!");

                            wc.Dispose();
                        };

                        _gameGettingComponentsDialog.GettingComponentLabel.Visibility = Visibility.Visible;
                        _gameGettingComponentsDialog.UnpackingComponentLabel.Visibility = Visibility.Hidden;

                        _gameGettingComponentsDialog.GettingComponentLabel.Content = $"{defaultLabelText} {componentName} (0%) ...";

                        _gameGettingComponentsDialog.GetComponentsDialog.IsOpen = true;

                        wc.DownloadFileTaskAsync(address, $"{downloadPath}\\{downloadFileName}");
                    }
                }
                else
                {
                    MessageBox.Show("Нет соединения с интернетом \\ No internet connection");
                }
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString());
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
                            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                            {
                                _gameGettingComponentsDialog.UnpackingComponentLabel.Content = $"{defaultLabelExtractText} {componentName} ({(int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer)}%) ...";
                            }));
                        }
                    };

                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(extractFolder, ExtractExistingFileAction.OverwriteSilently);
                    }

                    zip.Dispose();
                }

                File.Delete(newFileName); File.Move(oldFileName, newFileName); Thread.Sleep(1000);

                if (AppSettings.ApplicationSettings.DisableCachingGameComponents)
                {
                    File.Delete($"{downloadPath}\\{downloadFileName}");
                }

                AppLogger.Log.Info($"Extracting sacred game component {componentName} successfully done!");

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                    _gameGettingComponentsDialog.GetComponentsDialog.IsOpen = false;
                    _gameGettingComponentsDialog.GettingComponentLabel.Content = defaultLabelTextArg;
                    _gameGettingComponentsDialog.UnpackingComponentLabel.Content = defaultLabelExtractText;
                }));
            }
            catch (Exception exception)
            {
                AppLogger.Log.Error(exception.ToString());
            }
        }
    }
}
