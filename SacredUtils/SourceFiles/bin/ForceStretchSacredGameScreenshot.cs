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
using NHotkey;
using NHotkey.Wpf;
using SacredUtils.SourceFiles.settings;
using SacredUtils.SourceFiles.utils;

namespace SacredUtils.SourceFiles.bin
{
    public static class ForceStretchSacredGameScreenshot
    {
        private static bool _argRun;

        public static void RegisterKey(bool argRun)
        {
            _argRun = argRun;

            try
            {
                HotkeyManager.Current.AddOrReplace("PrintScreen", ApplicationSettingsManager.Settings.KeyCreateGameScreenShot,
                    ModifierKeys.None,
                    Get);
                CheckAvailabilityProcess();
                Logger.Log.Info("Register global PrintScreen hotkey successfully done!");
            }
            catch (Exception e)
            {
                Logger.Log.Error(
                    "Register global PrintScreen hotkey not ability (Close app used PrintScreen button)!");
                Logger.Log.Error(e.ToString);
            }
        }

        private static void CheckAvailabilityProcess()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0,
                    ApplicationSettingsManager.Settings.DelayCheckingSacredProcess)
            };

            timer.Tick += (s, e) =>
            {
                Process[] pname = Process.GetProcessesByName("Sacred");
                if (pname.Length != 0) return;

                DisableScreenShotStretching();
                timer.Stop();
            };

            timer.Start();
        }

        private static void DisableScreenShotStretching()
        {
            try
            {
                HotkeyManager.Current.Remove("PrintScreen");

                Logger.Log.Info("Caused by close Sacred: Shutting down global PrintScreen hotkey done!");
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString);
            }
        }

        private static void Get(object sender, HotkeyEventArgs e)
        {
            if (_argRun)
            {
                if (ApplicationSettingsManager.Settings.UseAsyncCreatingScreenshots)
                {
                    CreateScreenShotAsync();
                }
                else
                {
                    CreateScreenShot();
                }
            }
            else
            {
                if (ApplicationSettingsManager.Settings.UseAsyncCreatingScreenshots)
                {
                    CreateScreenShotAsync();
                }
                else
                {
                    CreateScreenShot();
                }
            }
        }

        private static void CreateScreenShotAsync() => Task.Run(CaptureScreen);

        private static void CreateScreenShot() => CaptureScreen();

        private static void CaptureScreen()
        {
            double screenLeft = SystemParameters.VirtualScreenLeft;
            double screenTop = SystemParameters.VirtualScreenTop;
            double screenWidth = SystemParameters.VirtualScreenWidth;
            double screenHeight = SystemParameters.VirtualScreenHeight;

            using (Bitmap bmp = new Bitmap((int) screenWidth, (int) screenHeight))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    string filename = ApplicationSettingsManager.Settings.ScreenShotSaveFilePrefix +
                                      DateTime.Now.ToString(ApplicationSettingsManager.Settings
                                          .ScreenShotSaveFilePattern) + ".png";

                    g.CopyFromScreen((int) screenLeft, (int) screenTop, 0, 0, bmp.Size);
                    Directory.CreateDirectory(ApplicationSettingsManager.Settings
                        .ScreenShotSaveDirectory);

                    if (ApplicationSettingsManager.Settings.AllowCustomScreenShotResolution)
                    {
                        Stretch(bmp,
                            ApplicationSettingsManager.Settings.CustomScreenShotResolutionWidth,
                            ApplicationSettingsManager.Settings.CustomScreenShotResolutionHeight,
                            filename);
                    }
                    else
                    {
                        Stretch(
                            bmp,
                            SystemInfo.WidthResolution,
                            SystemInfo.HeightResolution,
                            filename
                        );
                    }
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
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height,
                        GraphicsUnit.Pixel, wrapMode);
                }
            }

            Save(destImage, fileName);
        }

        private static void Save(Bitmap capture, string fileName)
        {
            Directory.CreateDirectory(ApplicationSettingsManager.Settings.ScreenShotSaveDirectory);
            capture.Save($"{ApplicationSettingsManager.Settings.ScreenShotSaveDirectory}\\{fileName}");
            Logger.Log.Info($"Screenshot saved {fileName} to Capture folder.");
            RemoveTgaScreenshots();
        }

        private static void RemoveTgaScreenshots()
        {
            if (ApplicationSettingsManager.Settings.ScreenShotRemoveTgaAndJpgFiles)
            {
                if (Directory.Exists("Capture"))
                {
                    string[] jpgScreen = Directory.GetFiles("Capture\\", "*.jpg");
                    string[] tgaScreen = Directory.GetFiles("Capture\\", "*.tga");

                    try
                    {
                        foreach (string file in jpgScreen)
                        {
                            File.Delete(file);
                        }

                        foreach (string file in tgaScreen)
                        {
                            File.Delete(file);
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.Log.Error(e.ToString);
                    }
                }
            }

            Dispose();
        }

        private static void Dispose() => GC.Collect();
    }
}
