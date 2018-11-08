using EnumsNET;
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
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class ForceStretchSacredGameScreenshot
    {
        private static bool _argRun;

        public static void RegisterKey(bool argRun)
        {
            _argRun = argRun;

            try
            {
                Enums.TryParse(AppSettings.ApplicationSettings.ScreenShotCreateKey, out Key screenKey);

                HotkeyManager.Current.AddOrReplace("PrintScreen", screenKey, ModifierKeys.None, Get);

                CheckAvailabilityProcess();

                Log.Info("Register global PrintScreen hotkey successfully done!");
            }
            catch (Exception e)
            {
                Log.Error("Register global PrintScreen hotkey not ability (Close app used PrintScreen button)!");

                Log.Error(e.ToString);
            }
        }

        private static void CheckAvailabilityProcess()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.DelayCheckingSacredProcess)
            };

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

                Log.Info("Caused by close Sacred: Shutting down global PrintScreen hotkey done!");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString);
            }
        }

        private static void Get(object sender, HotkeyEventArgs e)
        {
            if (_argRun)
            {
                if (AppSettings.ApplicationSettings.UseAsyncCreatingScreenshots) { CreateScreenShotAsync(); }
                else { CreateScreenShot(); }
            }
            else
            {
                if (AppSettings.ApplicationSettings.UseAsyncCreatingScreenshots) { CreateScreenShotAsync(); }
                else { CreateScreenShot(); }
            }
        }

        private static void CreateScreenShotAsync()
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

        private static void CreateScreenShot()
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
        }

        private static void Stretch(Image image, int width, int height, string fileName)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            Save(destImage, fileName);
        }

        private static void Save(Bitmap capture, string fileName)
        {
            Directory.CreateDirectory(AppSettings.ApplicationSettings.ScreenShotSaveDirectory);

            capture.Save($"{AppSettings.ApplicationSettings.ScreenShotSaveDirectory}\\{fileName}"); 

            Log.Info($"Screenshot saved {fileName} to Capture folder.");

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
                    Log.Error(e.ToString);
                }
            }

            Dispose();
        }

        private static void Dispose() => GC.Collect();
    }
}
