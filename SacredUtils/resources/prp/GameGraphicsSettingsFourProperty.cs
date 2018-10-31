using Ionic.Zip;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.arr;
using SacredUtils.resources.dlg;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.prp
{
    public class GameGraphicsSettingsFourProperty
    {
        public static ApplicationUnpackModifyDialog applicationUnpackModifyDialog = new ApplicationUnpackModifyDialog();

        private static void OpenDialog()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        ((MainWindow)window).DialogFrame.Visibility = Visibility.Visible;
                        ((MainWindow)window).DialogFrame.Content = applicationUnpackModifyDialog;
                    }
                }

                if (AppSettings.ApplicationSettings.ColorTheme == "dark")
                {
                    applicationUnpackModifyDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
                }

                applicationUnpackModifyDialog.BaseDialog.IsOpen = true;
            }));
        }

        private static void CloseDialog()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
                applicationUnpackModifyDialog.BaseDialog.IsOpen = false;
            }));
        }

        public bool StaticBog
        {
            get => AppSettings.ApplicationSettings.UseStaticBog;

            set
            {
                OpenDialog();

                if (value)
                {
                    WebClient wc = new WebClient();

                    wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1gDTxsT9TXJgSlRi7R6NUfI9A6VARIvS1", "STATIC BOG.zip").Wait();

                    UnpackResource("STATIC BOG.zip", "BOG");
                }
                else
                {
                    foreach (string file in ArraySacredGameWaterFilesD.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    foreach (string file in ArraySacredGameWaterFilesE.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    AppSettings.ApplicationSettings.UseStaticBog = false;
                }

                Thread.Sleep(1000);

                CloseDialog();
            }
        }

        public bool StaticWater
        {
            get => AppSettings.ApplicationSettings.UseStaticWater;

            set
            {
                OpenDialog();

                if (value)
                {
                    WebClient wc = new WebClient();

                    wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1iE6EC_bVfNc2H1cuc0r1Ssl-_K_WeYbu", "STATIC WATER.zip").Wait();

                    UnpackResource("STATIC WATER.zip", "WATER");
                }
                else
                {
                    foreach (string file in ArraySacredGameWaterFilesB.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    foreach (string file in ArraySacredGameWaterFilesC.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    foreach (string file in ArraySacredGameWaterFilesF.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    foreach (string file in ArraySacredGameWaterFilesG.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    AppSettings.ApplicationSettings.UseStaticWater = false;
                }

                Thread.Sleep(1000);

                CloseDialog();
            }
        }

        public bool StaticLava
        {
            get => AppSettings.ApplicationSettings.UseStaticLava;

            set
            {
                OpenDialog();

                if (value)
                {
                    WebClient wc = new WebClient();

                    wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1QgmDk8H4U0bsEGdB2MOFmtqLk3cnn2ya", "STATIC LAVA.zip").Wait();

                    UnpackResource("STATIC LAVA.zip", "LAVA");
                }
                else
                {
                    foreach (string file in ArraySacredGameLavaFilesA.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    foreach (string file in ArraySacredGameLavaFilesB.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    foreach (string file in ArraySacredGameLavaFilesC.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    foreach (string file in ArraySacredGameLavaFilesE.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    foreach (string file in ArraySacredGameLavaFilesD.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    AppSettings.ApplicationSettings.UseStaticLava = false;
                }

                Thread.Sleep(1000);

                CloseDialog();
            }
        }

        public bool OldSacred
        {
            get => AppSettings.ApplicationSettings.UseOldSacredTextures;

            set
            {
                OpenDialog();

                if (value)
                {
                    WebClient wc = new WebClient();

                    wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1Y9RvEF_rmkvfVAP7S5prBl2NTuULc4uJ", "OLD SACRED.zip").Wait();

                    UnpackResource("OLD SACRED.zip", "OLD_SACRED");
                }
                else
                {
                    foreach (string file in ArraySacredGameOldTextureFiles.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    AppSettings.ApplicationSettings.UseOldSacredTextures = false;
                }

                Thread.Sleep(1000);

                CloseDialog();
            }
        }

        public bool FootSteps
        {
            get => AppSettings.ApplicationSettings.DisableFootSteps;

            set
            {
                OpenDialog();

                if (value)
                {
                    WebClient wc = new WebClient();

                    wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1o-8qWgzsSq5xcfDGpPrOlLSWyrzxOOiP", "FOOTSTEPS.zip").Wait();

                    UnpackResource("FOOTSTEPS.zip", "FOOTSTEPS");
                }
                else
                {
                    foreach (string file in ArraySacredGameFootStepsFiles.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    AppSettings.ApplicationSettings.DisableFootSteps = false;
                }

                Thread.Sleep(1000);

                CloseDialog();
            }
        }

        public bool HealthCircles
        {
            get => AppSettings.ApplicationSettings.EnableHealthCircles;

            set
            {
                OpenDialog();

                if (value)
                {
                    foreach (string file in ArraySacredGameHealthFiles.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    AppSettings.ApplicationSettings.EnableHealthCircles = true;
                }
                else
                {
                    WebClient wc = new WebClient();

                    wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1FeTBk3uuTMBt8bxvzDRA3n8Rczsh5fyJ", "HEALTH.zip").Wait();

                    UnpackResource("HEALTH.zip", "HEALTH");
                }

                Thread.Sleep(1000);

                CloseDialog();
            }
        }

        private void UnpackResource(string fileName, string resourceName)
        {
            try
            {
                Directory.CreateDirectory("PAK");

                using (ZipFile zip = ZipFile.Read(fileName))
                {
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract("PAK", ExtractExistingFileAction.OverwriteSilently);
                    }

                    zip.Dispose();
                }

                if (resourceName == "BOG")
                {
                    for (int i = 1; i < 50; i++)
                    {
                        File.Copy("PAK\\D_WATER00.tga", i < 10 ? $"PAK\\D_WATER0{i}.tga" : $"PAK\\D_WATER{i}.tga", true);
                        File.Copy("PAK\\E_WATER00.tga", i < 10 ? $"PAK\\E_WATER0{i}.tga" : $"PAK\\E_WATER{i}.tga", true);
                    }

                    AppSettings.ApplicationSettings.UseStaticBog = true;
                }

                if (resourceName == "WATER")
                {
                    for (int i = 1; i < 50; i++)
                    {
                        File.Copy("PAK\\B_WATER00.tga", i < 10 ? $"PAK\\B_WATER0{i}.tga" : $"PAK\\B_WATER{i}.tga", true);
                        File.Copy("PAK\\C_WATER00.tga", i < 10 ? $"PAK\\C_WATER0{i}.tga" : $"PAK\\C_WATER{i}.tga", true);
                        File.Copy("PAK\\F_WATER00.tga", i < 10 ? $"PAK\\F_WATER0{i}.tga" : $"PAK\\F_WATER{i}.tga", true);
                        File.Copy("PAK\\G_WATER00.tga", i < 10 ? $"PAK\\G_WATER0{i}.tga" : $"PAK\\G_WATER{i}.tga", true);
                    }

                    AppSettings.ApplicationSettings.UseStaticWater = true;
                }

                if (resourceName == "LAVA")
                {
                    for (int i = 1; i < 50; i++)
                    {
                        File.Copy("PAK\\A_LAVA00.tga", i < 10 ? $"PAK\\A_LAVA0{i}.tga" : $"PAK\\A_LAVA{i}.tga", true);
                        File.Copy("PAK\\B_LAVA00.tga", i < 10 ? $"PAK\\B_LAVA0{i}.tga" : $"PAK\\B_LAVA{i}.tga", true);
                        File.Copy("PAK\\C_LAVA00.tga", i < 10 ? $"PAK\\C_LAVA0{i}.tga" : $"PAK\\C_LAVA{i}.tga", true);
                        File.Copy("PAK\\D_LAVA00.tga", i < 10 ? $"PAK\\D_LAVA0{i}.tga" : $"PAK\\D_LAVA{i}.tga", true);
                        File.Copy("PAK\\E_LAVA00.tga", i < 10 ? $"PAK\\E_LAVA0{i}.tga" : $"PAK\\E_LAVA{i}.tga", true);
                    }

                    AppSettings.ApplicationSettings.UseStaticLava = true;
                }

                switch (resourceName)
                {
                    case "OLD_SACRED": AppSettings.ApplicationSettings.UseOldSacredTextures = true; break;
                    case "FOOTSTEPS": AppSettings.ApplicationSettings.DisableFootSteps = true; break;
                    case "HEALTH": AppSettings.ApplicationSettings.EnableHealthCircles = false; break;
                }

                File.Delete(fileName);
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
        }
    }
}
