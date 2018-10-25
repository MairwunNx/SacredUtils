using NHotkey;
using NHotkey.Wpf;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SacredUtils.resources.bin
{
    public static class ForceStretchSacredGameScreenshot
    {
        public static bool ArgRun;

        public static void RegisterKey(bool argRun)
        {
            ArgRun = argRun;

            try
            {
                HotkeyManager.Current.AddOrReplace("PrintScreen", Key.PrintScreen, ModifierKeys.None, Get);

                CheckAvailabilityProcess();

                AppLogger.Log.Info("Register global PrintScreen hotkey successfully done!");
            }
            catch (Exception e)
            {
                AppLogger.Log.Error("Register global PrintScreen hotkey not ability (Close app used PrintScreen button)!");

                AppLogger.Log.Error(e.ToString);
            }
        }

        private static void CheckAvailabilityProcess()
        {
            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.DelayCheckingSacredProcess);

            timer.Tick += (s, e) =>
            {
                Process[] pname = Process.GetProcessesByName("Sacred");

                if (pname.Length == 0) { DisableScreenShotStretching(); timer.Stop(); }
            };

            timer.Start();
        }

        private static void DisableScreenShotStretching()
        {
            try
            {
                HotkeyManager.Current.Remove("PrintScreen");

                AppLogger.Log.Info("Caused by close Sacred: Shutting down global PrintScreen hotkey done!");
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }
        }

        private static void Get(object sender, HotkeyEventArgs e)
        {
            try
            {
                if (ArgRun)
                {
                    double screenLeft = SystemParameters.VirtualScreenLeft;
                    double screenTop = SystemParameters.VirtualScreenTop;
                    double screenWidth = SystemParameters.VirtualScreenWidth;
                    double screenHeight = SystemParameters.VirtualScreenHeight;

                    using (Bitmap bmp = new Bitmap((int)screenWidth, (int)screenHeight))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            string filename = AppSettings.ApplicationSettings.ScreenShotSaveFilePrefix + DateTime.Now.ToString(AppSettings.ApplicationSettings.ScreenShotSaveFilePattern) + ".png";

                            g.CopyFromScreen((int)screenLeft, (int)screenTop, 0, 0, bmp.Size);

                            Directory.CreateDirectory(AppSettings.ApplicationSettings.ScreenShotSaveDirectory);

                            Stretch(bmp, App.ScreenWidthDevice, App.ScreenHeightDevice, filename);
                        }
                    }
                }
                else
                {
                    Task.Run(() =>
                    {
                        double screenLeft = SystemParameters.VirtualScreenLeft;
                        double screenTop = SystemParameters.VirtualScreenTop;
                        double screenWidth = SystemParameters.VirtualScreenWidth;
                        double screenHeight = SystemParameters.VirtualScreenHeight;

                        using (Bitmap bmp = new Bitmap((int)screenWidth, (int)screenHeight))
                        {
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                string filename = AppSettings.ApplicationSettings.ScreenShotSaveFilePrefix + DateTime.Now.ToString(AppSettings.ApplicationSettings.ScreenShotSaveFilePattern) + ".png";

                                g.CopyFromScreen((int)screenLeft, (int)screenTop, 0, 0, bmp.Size);

                                Directory.CreateDirectory(AppSettings.ApplicationSettings.ScreenShotSaveDirectory);

                                Stretch(bmp, MainWindow.ScreenWidthDevice, MainWindow.ScreenHeightDevice, filename);
                            }
                        }
                    });
                }
            }
            catch (Exception exception)
            {
                AppLogger.Log.Error(exception.ToString);
            }
        }

        private static void Stretch(Image image, int width, int height, string fileName)
        {
            try
            {
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);

                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }

                Save(destImage, fileName);
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }
        }

        private static void Save(Bitmap capture, string fileName)
        {
            Directory.CreateDirectory(AppSettings.ApplicationSettings.ScreenShotSaveDirectory);

            capture.Save($"{AppSettings.ApplicationSettings.ScreenShotSaveDirectory}\\{fileName}"); 

            AppLogger.Log.Info($"Screenshot saved {fileName} to Capture folder.");

            RemoveTgaScreenshots(); 
        }

        private static void RemoveTgaScreenshots()
        {
            if (AppSettings.ApplicationSettings.ScreenShotRemoveTgaAndJpgFiles)
            {
                string[] jpgScreen = Directory.GetFiles("Capture\\", "*.jpg");
                string[] tgaScreen = Directory.GetFiles("Capture\\", "*.tga");

                try
                {
                    foreach (string file in jpgScreen) { File.Delete(file); }

                    foreach (string file in tgaScreen) { File.Delete(file); }
                }
                catch (Exception e)
                {
                    AppLogger.Log.Error(e.ToString);
                }
            }

            Dispose();
        }

        private static void Dispose() => GC.Collect();
    }
}
