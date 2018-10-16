using MaterialDesignThemes.Wpf;
using SacredUtils.resources.bin;
using SacredUtils.resources.dlg;
using SacredUtils.resources.pgs;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SacredUtils
{
    public partial class MainWindow
    {
        public static readonly ApplicationSettingsOne AppStgOne = new ApplicationSettingsOne();
        public static readonly ApplicationSettingsTwo AppStgTwo = new ApplicationSettingsTwo();
        public static readonly GameChatSettingsOne ChatStgOne = new GameChatSettingsOne();
        public static readonly GameFontSettingsOne FontStgOne = new GameFontSettingsOne();
        public static readonly GamePlaySettingsOne GamePlayStgOne = new GamePlaySettingsOne();
        public static readonly GamePlaySettingsTwo GamePlayStgTwo = new GamePlaySettingsTwo();
        public static readonly GamePlaySettingsThree GamePlayStgThree = new GamePlaySettingsThree();
        public static readonly GraphicsSettingsOne GraphicsStgOne = new GraphicsSettingsOne();
        public static readonly GraphicsSettingsTwo GraphicsStgTwo = new GraphicsSettingsTwo();
        public static readonly GraphicsSettingsThree GraphicsStgThree = new GraphicsSettingsThree();
        public static readonly GraphicsSettingsFour GraphicsStgFour = new GraphicsSettingsFour();
        public static readonly UnselectedSettingsPage UnselectedStg = new UnselectedSettingsPage();
        public static readonly ModifyPageSettingsOne ModifyStgOne = new ModifyPageSettingsOne();
        public static readonly SoundSettingsOne SoundStgOne = new SoundSettingsOne();
        public static readonly DispatcherTimer Timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent(); EventSubscribe();

            ChangeApplicationSelectionSettings.UnSelectSettings(UnselectedStg);

            GetApplicationLanguageValue.Get(); GetApplicationThemeValue.Get();

            GetApplicationScaleValue.Get(); GetPermCheckingMemory();
        }

        private void EventSubscribe()
        {
            MenuGrLabel.Click += (s, e) => ChangeApplicationSelectionSettings.SelectSettings(GraphicsStgOne, GraphicsPanel);
            MenuSnLabel.Click += (s, e) => ChangeApplicationSelectionSettings.SelectSettings(SoundStgOne, SoundPanel);
            MenuGpLabel.Click += (s, e) => ChangeApplicationSelectionSettings.SelectSettings(GamePlayStgOne, GameplayPanel);
            MenuCtLabel.Click += (s, e) => ChangeApplicationSelectionSettings.SelectSettings(ChatStgOne, ChatPanel);
            MenuFtLabel.Click += (s, e) => ChangeApplicationSelectionSettings.SelectSettings(FontStgOne, FontsPanel);
            MenuMdLabel.Click += (s, e) => ChangeApplicationSelectionSettings.SelectSettings(ModifyStgOne, ModifPanel);
            MenuStLabel.Click += (s, e) => ChangeApplicationSelectionSettings.SelectSettings(AppStgOne, SettingsPanel);

            MemoryLbl.MouseDown += (s, e) => GC.Collect();
            HeaderPanel.MouseDown += DragWindow; CloseBtn.Click += (s, e) => Shutdown();
            MinimizeBtn.Click += (s, e) => WindowState = WindowState.Minimized;

            Timer.Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.ShowUsedMemoryUpdateInterval);
            Timer.Tick += (s, e) => GetCurrentUsedMemory();

            Loaded += (sender, args) =>
            {
                GetLicenseState(); AppSummary.Sw.Stop();

                AppLogger.Log.Info($"Loading SacredUtils application done ({AppSummary.Sw.Elapsed.TotalMilliseconds / 1000.00} seconds)!");

                Task.Run(() =>
                {
                    GetApplicationDownloadStatistic.Get(); CheckAvailabilityAlphaUpdates.GetPerm();

                    if (!CheckAvailabilityInternetConnection.Connect())
                    {
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                        {
                            NoConnectImage.Visibility = Visibility.Visible;
                        }));
                    }
                });

                OpenChangeLogDialog();

                if (!CheckAvailabilityInternetConnection.Connect()) { NoConnectImage.Visibility = Visibility.Visible; }
            };
        }

        private void OpenChangeLogDialog()
        {
            if (File.Exists("$SacredUtils\\temp\\updated.su"))
            {
                if (AppSettings.ApplicationSettings.ShowChangeLog)
                {
                    ApplicationChangeLogDialog applicationChangeLogDialog = new ApplicationChangeLogDialog();

                    DialogFrame.Visibility = Visibility.Visible;
                    DialogFrame.Content = applicationChangeLogDialog;
                    
                    if (AppSettings.ApplicationSettings.ColorTheme == "dark")
                    {
                        applicationChangeLogDialog.ChangeLogDialog.DialogTheme = BaseTheme.Dark;
                    }

                    applicationChangeLogDialog.ChangeLogDialog.IsOpen = true;

                    File.Delete("$SacredUtils\\temp\\updated.su");
                }
            }
        }

        private void GetCurrentUsedMemory()
        {
            MemoryLbl.Content = $"[{RuntimeInformation.FrameworkDescription.ToUpper()}] [{Process.GetCurrentProcess().Id} / {Process.GetCurrentProcess().PriorityClass.ToString().ToUpper()}] USED MEMORY {GC.GetTotalMemory(false) / 1024} KB OF {Environment.WorkingSet / 1024} KB";
        }

        private void GetPermCheckingMemory()
        {
            // Isabella ... Sorry please ...

            if (AppSettings.ApplicationSettings.ShowUsedMemory)
            {
                MemoryLbl.Visibility = Visibility.Visible; Timer.Start();
            }
            else
            {
                MemoryLbl.Visibility = Visibility.Hidden; Timer.Stop();
            }
        }

        private static void Shutdown()
        {
            AppLogger.Log.Info("============================================================");
            AppLogger.Log.Info("*** Thanks for using SacredUtils! Created by MairwunNx");
            AppLogger.Log.Info("Special thanks to Shalinorus, Keboo, JetBrains");
            AppLogger.Log.Info("============================================================");
            AppLogger.Log.Info("Shalinorus - for application test, and design test.");
            AppLogger.Log.Info("Keboo - for help with code and for MDIX library.");
            AppLogger.Log.Info("JetBrains - for help free license on all products.");
            AppLogger.Log.Info("============================================================");
            AppLogger.Log.Info("Shutting down SacredUtils application...");
            AppLogger.Log.Info("============================================================");

            Application.Current.Shutdown();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { DragMove(); }
        }

        private void BaseWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Enum.TryParse(AppSettings.ApplicationSettings.KeyGotoMainMenu, out Key toMain);
            Enum.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsLogs, out Key openLogs);
            Enum.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsSettings, out Key openSettings);
            Enum.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsDirectory, out Key openDirectory);
            Enum.TryParse(AppSettings.ApplicationSettings.KeyReloadSacredUtils, out Key reloadSacredUtils);
            Enum.TryParse(AppSettings.ApplicationSettings.KeyShutdownSacredUtils, out Key shutdownSacredUtils);
            Enum.TryParse(AppSettings.ApplicationSettings.KeyReloadFastSacredUtils, out Key fastReloadSacredUtils);
             
            if (e.Key == toMain)
            {
                ChangeApplicationSelectionSettings.UnSelectSettings(UnselectedStg);
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == openLogs)
            {
                if (File.Exists("$SacredUtils\\logs\\latest.log"))
                {
                    Process.Start("notepad", "$SacredUtils\\logs\\latest.log");
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == openSettings)
            {
                if (File.Exists("$SacredUtils\\conf\\settings.json"))
                {
                    Process.Start("notepad", "$SacredUtils\\conf\\settings.json");
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == openDirectory)
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                Process.Start(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName));
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == reloadSacredUtils)
            {
                Process.Start(AppSummary.AppPatch); Environment.Exit(0);
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == shutdownSacredUtils)
            {
                Shutdown();
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == fastReloadSacredUtils)
            {
                Process.Start(AppSummary.AppPatch, " -fast"); Environment.Exit(0);
            }
        }

        private void UpdateLbl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                File.Create("$SacredUtils\\temp\\updated.su");

                Process.Start("mnxupdater.exe", AppDomain.CurrentDomain.FriendlyName + " _newVersionSacredUtilsTemp.exe");

                Shutdown();
            }
            catch (Exception ex)
            {
                AppLogger.Log.Info(ex.ToString);
            }
        }

        private void GetLicenseState()
        {
            if (!AppSettings.ApplicationSettings.AcceptLicense || !File.Exists("License.txt"))
            {
                File.WriteAllBytes("License.txt", Properties.Resources.AppLicense);

                UpdateLbl.IsEnabled = false; MinimizeBtn.IsEnabled = false;

                OpenLicenseDialog();
            }
        }

        private void OpenLicenseDialog()
        {
            ApplicationLicenseDialog applicationLicenseDialog = new ApplicationLicenseDialog();

            DialogFrame.Visibility = Visibility.Visible;
            DialogFrame.Content = applicationLicenseDialog;

            if (AppSettings.ApplicationSettings.ColorTheme == "dark")
            {
                applicationLicenseDialog.LicenseDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationLicenseDialog.LicenseDialog.IsOpen = true;
        }

        private void MenuPlLabel_Click(object sender, RoutedEventArgs e)
        {
            ApplicationRunSacredDialog applicationRunSacredDialog = new ApplicationRunSacredDialog();

            DialogFrame.Visibility = Visibility.Visible;
            DialogFrame.Content = applicationRunSacredDialog;

            if (AppSettings.ApplicationSettings.ColorTheme == "dark")
            {
                applicationRunSacredDialog.AboutDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationRunSacredDialog.AboutDialog.IsOpen = true;
        }
    }
}
