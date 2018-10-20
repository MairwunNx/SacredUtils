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
        public static void RegisterKey()
        {
            try
            {
                HotkeyManager.Current.AddOrReplace("PrintScreen", Key.PrintScreen, ModifierKeys.None, Get);

                CheckAvailabilityProcess();
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }
        }

        private static void CheckAvailabilityProcess()
        {
            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = new TimeSpan(0, 0, 1);

            timer.Tick += (s, e) =>
            {
                Process[] pname = Process.GetProcessesByName("Sacred");

                if (pname.Length == 0) { DisableScreenShotStretching(); }
            };

            timer.Start();
        }

        private static void DisableScreenShotStretching()
        {
            try
            {
                HotkeyManager.Current.Remove("PrintScreen");
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
                            string filename = "screen-" + DateTime.Now.ToString("ddMMyyyy-hhmmss") + ".png";

                            g.CopyFromScreen((int)screenLeft, (int)screenTop, 0, 0, bmp.Size);

                            Directory.CreateDirectory("Capture");

                            Stretch(bmp, MainWindow.ScreenWidthDevice, MainWindow.ScreenHeightDevice, filename);
                        }
                    }
                });
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

            capture.Save("Capture\\" + fileName); Dispose();

            AppLogger.Log.Info($"Screenshot saved {fileName} to Capture folder.");
        }

        private static void Dispose() => GC.Collect();
    }
}
