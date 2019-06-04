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
using SacredUtils.resources.bin;
using SacredUtils.SourceFiles.bin;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.resources.prp
{
    public class GameGraphicsSettingsFourProperty
    {
        private static readonly ApplicationUnpackModifyDialog ApplicationUnpackModifyDialog = new ApplicationUnpackModifyDialog();

        private static void OpenDialog()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
                MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
                MainWindow.MainWindowInstance.DialogFrame.Content = ApplicationUnpackModifyDialog;

                if (AppSettings.ApplicationSettings.ApplicationUiColorTheme == "dark")
                {
                    ApplicationUnpackModifyDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
                }

                ApplicationUnpackModifyDialog.BaseDialog.IsOpen = true;
            }));
        }

        private static void CloseDialog()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
                ApplicationUnpackModifyDialog.BaseDialog.IsOpen = false;
            }));
        }

        public bool StaticBog
        {
            get => ModifySettings.ModificationSettings.UseSacredStaticBogTexture;

            set
            {
                OpenDialog();

                if (value)
                {
                    if (NetworkUtils.Connect())
                    {
                        WebClient wc = new WebClient();

                        wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1gDTxsT9TXJgSlRi7R6NUfI9A6VARIvS1", "STATIC BOG.zip").Wait();

                        UnpackResource("STATIC BOG.zip", "BOG");
                    }
                }
                else
                {
                    foreach (string file in ArraySacredGameWaterFiles.Files)
                    {
                        if (File.Exists($"PAK\\D{file}")) { File.Delete($"PAK\\D{file}"); }
                    }

                    foreach (string file in ArraySacredGameWaterFiles.Files)
                    {
                        if (File.Exists($"PAK\\E{file}")) { File.Delete($"PAK\\E{file}"); }
                    }

                    ModifySettings.ModificationSettings.UseSacredStaticBogTexture = false;
                }

                Thread.Sleep(1000);

                CloseDialog();
            }
        }

        public bool StaticWater
        {
            get => ModifySettings.ModificationSettings.UseSacredStaticWaterTexture;

            set
            {
                OpenDialog();

                if (value)
                {
                    if (NetworkUtils.Connect())
                    {
                        WebClient wc = new WebClient();

                        wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1iE6EC_bVfNc2H1cuc0r1Ssl-_K_WeYbu", "STATIC WATER.zip").Wait();

                        UnpackResource("STATIC WATER.zip", "WATER");
                    }
                }
                else
                {
                    foreach (string file in ArraySacredGameWaterFiles.Files)
                    {
                        if (File.Exists($"PAK\\B{file}")) { File.Delete($"PAK\\B{file}"); }
                    }

                    foreach (string file in ArraySacredGameWaterFiles.Files)
                    {
                        if (File.Exists($"PAK\\C{file}")) { File.Delete($"PAK\\C{file}"); }
                    }

                    foreach (string file in ArraySacredGameWaterFiles.Files)
                    {
                        if (File.Exists($"PAK\\F{file}")) { File.Delete($"PAK\\F{file}"); }
                    }

                    foreach (string file in ArraySacredGameWaterFiles.Files)
                    {
                        if (File.Exists($"PAK\\G{file}")) { File.Delete($"PAK\\G{file}"); }
                    }

                    ModifySettings.ModificationSettings.UseSacredStaticWaterTexture = false;
                }

                Thread.Sleep(1000);

                CloseDialog();
            }
        }

        public bool StaticLava
        {
            get => ModifySettings.ModificationSettings.UseSacredStaticLavaTexture;

            set
            {
                OpenDialog();

                if (value)
                {
                    if (NetworkUtils.Connect())
                    {
                        WebClient wc = new WebClient();

                        wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1QgmDk8H4U0bsEGdB2MOFmtqLk3cnn2ya", "STATIC LAVA.zip").Wait();

                        UnpackResource("STATIC LAVA.zip", "LAVA");
                    }
                }
                else
                {
                    foreach (string file in ArraySacredGameLavaFiles.Files)
                    {
                        if (File.Exists($"PAK\\A{file}")) { File.Delete($"PAK\\A{file}"); }
                    }

                    foreach (string file in ArraySacredGameLavaFiles.Files)
                    {
                        if (File.Exists($"PAK\\B{file}")) { File.Delete($"PAK\\B{file}"); }
                    }

                    foreach (string file in ArraySacredGameLavaFiles.Files)
                    {
                        if (File.Exists($"PAK\\C{file}")) { File.Delete($"PAK\\C{file}"); }
                    }

                    foreach (string file in ArraySacredGameLavaFiles.Files)
                    {
                        if (File.Exists($"PAK\\E{file}")) { File.Delete($"PAK\\E{file}"); }
                    }

                    foreach (string file in ArraySacredGameLavaFiles.Files)
                    {
                        if (File.Exists($"PAK\\D{file}")) { File.Delete($"PAK\\D{file}"); }
                    }

                    ModifySettings.ModificationSettings.UseSacredStaticLavaTexture = false;
                }

                Thread.Sleep(1000);

                CloseDialog();
            }
        }

        public bool OldSacred
        {
            get => ModifySettings.ModificationSettings.UseSacredOldTextures;

            set
            {
                OpenDialog();

                if (value)
                {
                    if (NetworkUtils.Connect())
                    {
                        WebClient wc = new WebClient();

                        wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1Y9RvEF_rmkvfVAP7S5prBl2NTuULc4uJ", "OLD SACRED.zip").Wait();

                        UnpackResource("OLD SACRED.zip", "OLD_SACRED");
                    }
                }
                else
                {
                    foreach (string file in ArraySacredGameOldTextureFiles.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    ModifySettings.ModificationSettings.UseSacredOldTextures = false;
                }

                Thread.Sleep(1000);

                CloseDialog();
            }
        }

        public bool FootSteps
        {
            get => ModifySettings.ModificationSettings.SacredRemovePlayerFootSteps;

            set
            {
                OpenDialog();

                if (value)
                {
                    if (NetworkUtils.Connect())
                    {
                        WebClient wc = new WebClient();

                        wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1o-8qWgzsSq5xcfDGpPrOlLSWyrzxOOiP", "FOOTSTEPS.zip").Wait();

                        UnpackResource("FOOTSTEPS.zip", "FOOTSTEPS");
                    }
                }
                else
                {
                    foreach (string file in ArraySacredGameFootStepsFiles.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    ModifySettings.ModificationSettings.SacredRemovePlayerFootSteps = false;
                }

                Thread.Sleep(1000);

                CloseDialog();
            }
        }

        public bool HealthCircles
        {
            get => ModifySettings.ModificationSettings.EnableVisibilityHealthCircles;

            set
            {
                OpenDialog();

                if (value)
                {
                    foreach (string file in ArraySacredGameHealthFiles.Files)
                    {
                        if (File.Exists($"PAK\\{file}")) { File.Delete($"PAK\\{file}"); }
                    }

                    ModifySettings.ModificationSettings.EnableVisibilityHealthCircles = true;
                }
                else
                {
                    if (NetworkUtils.Connect())
                    {
                        WebClient wc = new WebClient();

                        wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1FeTBk3uuTMBt8bxvzDRA3n8Rczsh5fyJ", "HEALTH.zip").Wait();

                        UnpackResource("HEALTH.zip", "HEALTH");
                    }
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
                }

                if (resourceName == "BOG")
                {
                    for (int i = 1; i < 50; i++)
                    {
                        File.Copy("PAK\\D_WATER00.tga", i < 10 ? $"PAK\\D_WATER0{i}.tga" : $"PAK\\D_WATER{i}.tga", true);
                        File.Copy("PAK\\E_WATER00.tga", i < 10 ? $"PAK\\E_WATER0{i}.tga" : $"PAK\\E_WATER{i}.tga", true);
                    }

                    ModifySettings.ModificationSettings.UseSacredStaticBogTexture = true;
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

                    ModifySettings.ModificationSettings.UseSacredStaticWaterTexture = true;
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

                    ModifySettings.ModificationSettings.UseSacredStaticLavaTexture = true;
                }

                switch (resourceName)
                {
                    case "OLD_SACRED": ModifySettings.ModificationSettings.UseSacredOldTextures = true; break;
                    case "FOOTSTEPS": ModifySettings.ModificationSettings.SacredRemovePlayerFootSteps = true; break;
                    case "HEALTH": ModifySettings.ModificationSettings.EnableVisibilityHealthCircles = false; break;
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
