using NHotkey;
using NHotkey.Wpf;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SacredUtils.resources.bin
{
    public static class ForceStretchSacredGameScreenshot
    {
        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        static IntPtr primary = GetDC(IntPtr.Zero);
        static int DESKTOPVERTRES = 117;
        static int DESKTOPHORZRES = 118;
        static int actualPixelsX = GetDeviceCaps(primary, DESKTOPHORZRES);
        static int actualPixelsY = GetDeviceCaps(primary, DESKTOPVERTRES);

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
                double screenLeft = SystemParameters.VirtualScreenLeft;
                double screenTop = SystemParameters.VirtualScreenTop;
                double screenWidth = SystemParameters.VirtualScreenWidth;
                double screenHeight = SystemParameters.VirtualScreenHeight;

                using (Bitmap bmp = new Bitmap((int)screenWidth, (int)screenHeight))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        string filename = "shoot-" + DateTime.Now.ToString("ddMMyyyy-hhmmss") + ".png";

                        g.CopyFromScreen((int)screenLeft, (int)screenTop, 0, 0, bmp.Size);
                        
                        Directory.CreateDirectory("Capture");

                        Stretch(bmp, actualPixelsX, actualPixelsY, filename);
                    }
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
            capture.Save("Capture\\" + fileName); Dispose();
        }

        private static void Dispose() => GC.Collect();
    }
}
