using SacredUtils.resources.bin;
using SacredUtils.resources.pgs;
using System;
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

            GetApplicationScaleValue.Get(); GetPermissionsOnGettingMemory.Get();

            GetApplicationLicenseState.GetLicenseState();
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
            MenuPlLabel.Click += (s, e) => ApplicationStartSacredGameFile.StartDialog();
            
            UpdateLbl.MouseDown += (s, e) => ApplicationStartUtilityUpdate.Start();
            BaseWindow.PreviewKeyDown += (s, e) => ApplicationBaseWindowHotkeys.KeyDown(s, e);
            HeaderPanel.MouseDown += DragWindow; CloseBtn.Click += (s, e) => Shutdown();
            MinimizeBtn.Click += (s, e) => WindowState = WindowState.Minimized;
            MemoryLbl.MouseDown += (s, e) => GC.Collect();

            Timer.Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.ShowUsedMemoryUpdateInterval);
            Timer.Tick += (s, e) => GetApplicationCurrentUsedMemory.Get();

            Loaded += (sender, args) =>
            {
                AppSummary.Sw.Stop(); // Make Yourself ^_^

                AppLogger.Log.Info($"Loading SacredUtils application done ({AppSummary.Sw.Elapsed.TotalMilliseconds / 1000.00} seconds)!");

                Task.Run(() => { CheckAvailabilityAlphaUpdates.GetPerm(); GetNoInternetIconVisibility.Get(); });

                if (!CheckAvailabilityInternetConnection.Connect()) { NoConnectImage.Visibility = Visibility.Visible; }

                if (AppSettings.ApplicationSettings.AcceptLicense) { GetChangeLogDialogVisibility.Get(); }
            };
        }

        public static void Shutdown()
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
    }
}
