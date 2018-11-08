using Ionic.Zip;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.bin;
using SacredUtils.resources.dlg;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class ModifyPageSettingsOne
    {
        ApplicationConverHtmlToSacred applicationConverHtmlToSacred = new ApplicationConverHtmlToSacred();

        public ModifyPageSettingsOne()
        {
            InitializeComponent();

            VeteranModBtn.SetResourceReference(ContentProperty,
                !ModifySettings.ModificationSettings.VeteranModUfoInstalled ? "String0088" : "String0089");

            Sacred229PathBtn.SetResourceReference(ContentProperty,
                !ModifySettings.ModificationSettings.SacredUnofficialPatchInstalled ? "String0090" : "String0091");

            ServerCoreFixBtn.SetResourceReference(ContentProperty,
                !ModifySettings.ModificationSettings.ServerMultiCoreFixInstalled ? "String0092" : "String0093");

            Log.Info("Initialization components for app modify page one done!");
        }

        private void VeteranModBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ModifySettings.ModificationSettings.VeteranModUfoInstalled)
            {
                Directory.CreateDirectory("bin"); Directory.CreateDirectory("pak");

                File.WriteAllBytes("bin\\balance.bin", Properties.Resources.SacredBalanceVanilla);
                File.WriteAllBytes("pak\\creature.pak", Properties.Resources.SacredCreatureVanilla);

                VeteranModBtn.SetResourceReference(ContentProperty, "String0088");

                ModifySettings.ModificationSettings.VeteranModUfoInstalled = false;
            }
            else
            {
                Directory.CreateDirectory("bin"); Directory.CreateDirectory("pak");

                File.WriteAllBytes("bin\\balance.bin", Properties.Resources.SacredBalanceVeteran);
                File.WriteAllBytes("pak\\creature.pak", Properties.Resources.SacredCreatureVeteran);

                VeteranModBtn.SetResourceReference(ContentProperty, "String0089");

                ModifySettings.ModificationSettings.VeteranModUfoInstalled = true;
            }
        }

        private void Sacred229PathBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ModifySettings.ModificationSettings.SacredUnofficialPatchInstalled)
            {
                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/QRe3uOT73XgkeR"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "SacredPatched228.zip", Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName),
                    "2.28.01 Patch", "SacredPatched228.exe", AppSettings.ApplicationSettings.SacredFileName);

                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "LANGUAGE : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line == null)
                {
                    switch (MainWindow.ChatStgOne.UiLanguageCmbBox.SelectedIndex)
                    {
                        case 0: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "RU"); break;
                        case 1: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "US"); break;
                        case 2: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "DE"); break;
                        case 3: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "SP"); break;
                        case 4: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "FR"); break;
                    }
                }

                Sacred229PathBtn.SetResourceReference(ContentProperty, "String0090");

                ModifySettings.ModificationSettings.SacredUnofficialPatchInstalled = false;
            }
            else
            {
                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/P-gzohuQ3XgkfQ"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "SacredPatched22914.zip", Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName),
                    "2.29.14 Patch", "SacredPatched22914.exe", AppSettings.ApplicationSettings.SacredFileName);

                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "LANGUAGE : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line == null)
                {
                    switch (MainWindow.ChatStgOne.UiLanguageCmbBox.SelectedIndex)
                    {
                        case 0: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "RU"); break;
                        case 1: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "US"); break;
                        case 2: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "DE"); break;
                        case 3: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "SP"); break;
                        case 4: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "FR"); break;
                    }
                }

                Sacred229PathBtn.SetResourceReference(ContentProperty, "String0091");

                ModifySettings.ModificationSettings.SacredUnofficialPatchInstalled = true;
            }
        }

        private void ServerCoreFixBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ModifySettings.ModificationSettings.ServerMultiCoreFixInstalled)
            {
                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/Mkw_Odf63XgkeF"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "ServerPatched228.zip", Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName),
                    "GameServer Vanilla", "ServerPatched228.exe", "gameserver.exe");

                ServerCoreFixBtn.SetResourceReference(ContentProperty, "String0092");

                ModifySettings.ModificationSettings.ServerMultiCoreFixInstalled = false;
            }
            else
            {
                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/VH3BGz3D3XgkeM"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "ServerPatched229.zip", Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName),
                    "GameServer Fix", "ServerPatched229.exe", "gameserver.exe");

                ServerCoreFixBtn.SetResourceReference(ContentProperty, "String0093");

                ModifySettings.ModificationSettings.ServerMultiCoreFixInstalled = true;
            }
        }

        private void UnpackGlobalResBtn_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("global.res"))
            {
                File.WriteAllBytes("Sacredres2Csv.exe", Properties.Resources.SacredRes2Csv);

                Process.Start("Sacredres2Csv.exe", "-csv -oglobal.csv global.res");

                MessageBox.Show("Successfully decompiled global.res file to current folder.", "Info!");

                File.Delete("Sacredres2Csv.exe");
            }
            else
            {
                MessageBox.Show("An error has occurred! Or not error (404) File not found!\nTry moving \"scripts\\...\\global.res\" to folder with the SacredUtils application.", "Info!");
            }
        }

        private void PackGlobalResBtn_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("global.res") && File.Exists("global.csv"))
            {
                File.WriteAllBytes("Sacredres2Csv.exe", Properties.Resources.SacredRes2Csv);

                Process.Start("Sacredres2Csv.exe", "-res -oglobal.res global.csv");

                MessageBox.Show("Successfully compiled global.res file in current folder.\nNow you can copy \"global.res\" to \"scripts\\...\\global.res\"", "Info!");

                File.Delete("global.csv"); File.Delete("Sacredres2Csv.exe");
            }
            else
            {
                MessageBox.Show("An error has occurred! Or not error (404) File not found!\nTry moving \"scripts\\...\\global.res\" to folder with the SacredUtils application.", "Info!");
            }
        }

        private void EditBalanceBtn_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    Directory.CreateDirectory("bin\\TYPE_ADDED_UTILITY\\Balance");

                    WebClient wc = new WebClient();

                    wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1IJ_UJwL6V6oB-KCrXIGj_59lLZGhiZcJ", "bin\\TYPE_ADDED_UTILITY\\Balance\\BalanceEditor.zip").Wait();

                    using (ZipFile zip = ZipFile.Read("bin\\TYPE_ADDED_UTILITY\\Balance\\BalanceEditor.zip"))
                    {
                        foreach (ZipEntry file in zip)
                        {
                            file.Extract("bin\\TYPE_ADDED_UTILITY\\Balance", ExtractExistingFileAction.OverwriteSilently);
                        }

                        zip.Dispose();
                    }

                    Process.Start("bin\\TYPE_ADDED_UTILITY\\Balance\\BalanceEditor.exe");
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            });
        }

        private void RunSacredHotkeyTweakerBtn_Click(object sender, RoutedEventArgs e)
        {
            ApplicationHotkeyChangeDialog applicationHotkey = new ApplicationHotkeyChangeDialog();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    ((MainWindow)window).DialogFrame.Visibility = Visibility.Visible;
                    ((MainWindow)window).DialogFrame.Content = applicationHotkey;
                }
            }

            if (AppSettings.ApplicationSettings.ColorTheme == "dark")
            {
                applicationHotkey.HotkeyEditDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationHotkey.HotkeyEditDialog.IsOpen = true;
        }

        private void EditCreatureBtn_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    Directory.CreateDirectory("bin\\TYPE_ADDED_UTILITY\\Creature");

                    WebClient wc = new WebClient();

                    wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1o6kHQYJErUFnfbrO0rmXCoHmFe_dGdWI", "bin\\TYPE_ADDED_UTILITY\\Creature\\CreatureEditor.zip").Wait();

                    using (ZipFile zip = ZipFile.Read("bin\\TYPE_ADDED_UTILITY\\Creature\\CreatureEditor.zip"))
                    {
                        foreach (ZipEntry file in zip)
                        {
                            file.Extract("bin\\TYPE_ADDED_UTILITY\\Creature", ExtractExistingFileAction.OverwriteSilently);
                        }

                        zip.Dispose();
                    }

                    Process.Start("bin\\TYPE_ADDED_UTILITY\\Creature\\CreatureEditor.exe");
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            });
        }

        private void EditWeaponBtn_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    Directory.CreateDirectory("bin\\TYPE_ADDED_UTILITY\\Weapon");

                    WebClient wc = new WebClient();

                    wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1KqM53E5eeqV96voOISamHk39e__dgsoE", "bin\\TYPE_ADDED_UTILITY\\Weapon\\WeaponEditor.zip").Wait();

                    using (ZipFile zip = ZipFile.Read("bin\\TYPE_ADDED_UTILITY\\Weapon\\WeaponEditor.zip"))
                    {
                        foreach (ZipEntry file in zip)
                        {
                            file.Extract("bin\\TYPE_ADDED_UTILITY\\Weapon", ExtractExistingFileAction.OverwriteSilently);
                        }

                        zip.Dispose();
                    }

                    Process.Start("bin\\TYPE_ADDED_UTILITY\\Weapon\\WeaponEditor.exe");
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            });
        }

        private void RunSacredHeroResetterBtn_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    Directory.CreateDirectory("bin\\TYPE_ADDED_UTILITY\\HeroResetter");

                    WebClient wc = new WebClient();

                    wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1tJ6dPj0dXJqGPs8pNbDJ1DkQCGV_VADt", "bin\\TYPE_ADDED_UTILITY\\HeroResetter\\HeroResetter.zip").Wait();

                    using (ZipFile zip = ZipFile.Read("bin\\TYPE_ADDED_UTILITY\\HeroResetter\\HeroResetter.zip"))
                    {
                        foreach (ZipEntry file in zip)
                        {
                            file.Extract("bin\\TYPE_ADDED_UTILITY\\HeroResetter", ExtractExistingFileAction.OverwriteSilently);
                        }

                        zip.Dispose();
                    }

                    Process.Start("bin\\TYPE_ADDED_UTILITY\\HeroResetter\\SHR.exe");
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            });
        }

        private void RunCharModifBtn_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    Directory.CreateDirectory("bin\\TYPE_ADDED_UTILITY\\HeroEditor");

                    WebClient wc = new WebClient();

                    wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1fOvBcZlk1dY-IIsRgkuOHiJAsyWdmiUp", "bin\\TYPE_ADDED_UTILITY\\HeroEditor\\HeroEditor.zip").Wait();

                    using (ZipFile zip = ZipFile.Read("bin\\TYPE_ADDED_UTILITY\\HeroEditor\\HeroEditor.zip"))
                    {
                        foreach (ZipEntry file in zip)
                        {
                            file.Extract("bin\\TYPE_ADDED_UTILITY\\HeroEditor", ExtractExistingFileAction.OverwriteSilently);
                        }

                        zip.Dispose();
                    }

                    Process.Start("bin\\TYPE_ADDED_UTILITY\\HeroEditor\\she.exe");
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            });
        }

        private void RunConvertColors_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    ((MainWindow)window).DialogFrame.Visibility = Visibility.Visible;
                    ((MainWindow)window).DialogFrame.Content = applicationConverHtmlToSacred;
                }
            }

            if (AppSettings.ApplicationSettings.ColorTheme == "dark")
            {
                applicationConverHtmlToSacred.ConvertColorsDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationConverHtmlToSacred.ConvertColorsDialog.IsOpen = true;
        }

        private void StartCheckingComponentsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(AppSettings.ApplicationSettings.SacredFileName))
            {
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(AppSettings.ApplicationSettings.SacredFileName);

                string fileVersion =
                    $"{versionInfo.FileMajorPart}.{versionInfo.FileMinorPart}.{versionInfo.FileBuildPart}.{versionInfo.FilePrivatePart}";

                FrameworkElement element = new FrameworkElement();

                if (fileVersion != "2.0.2.8" && fileVersion != "2.29.13.0" && fileVersion != "2.0.2.118")
                {
                    MessageBox.Show(element.FindResource("String0156") as string);
                }
                else
                {
                    File.WriteAllBytes("$SacredUtils\\conf\\ch.files.txt", Properties.Resources.ch_files);

                    MessageBoxResult result = MessageBox.Show(element.FindResource("String0158") as string, "", MessageBoxButton.OKCancel);

                    if (result == MessageBoxResult.OK)
                    {
                        GameCheckingComponentsDialog gameCheckingComponentsDialog = new GameCheckingComponentsDialog();

                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).DialogFrame.Visibility = Visibility.Visible;
                                ((MainWindow)window).DialogFrame.Content = gameCheckingComponentsDialog;
                            }
                        }

                        if (AppSettings.ApplicationSettings.ColorTheme == "dark")
                        {
                            gameCheckingComponentsDialog.CheckComponentsDialog.DialogTheme = BaseTheme.Dark;
                        }

                        gameCheckingComponentsDialog.CheckingComponents.Visibility = Visibility.Visible;

                        gameCheckingComponentsDialog.CheckComponentsDialog.IsOpen = true;

                        gameCheckingComponentsDialog.CheckComponents();
                    }
                }
            }
            else
            {
                FrameworkElement element = new FrameworkElement();

                MessageBox.Show(element.FindResource("String0157") as string);
            }
        }
    }
}
