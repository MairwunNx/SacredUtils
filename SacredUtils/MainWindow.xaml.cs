using SacredUtils.resources.bin;
using SacredUtils.resources.pgs;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using static SacredUtils.AppLogger;

namespace SacredUtils
{
    public partial class MainWindow
    {
        public static MainWindow MainWindowInstance;

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

            MainWindowInstance = (MainWindow)Application.Current.MainWindow;

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

            if (AppSettings.ApplicationSettings.RefreshSettingsOnWindowFocus) { Activated += (s, e) => RefreshApplicationSettings.Refresh(); }

            Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata { DefaultValue = AppSettings.ApplicationSettings.DesiredFrameRateProperty });

            CloseBtn.Click += (s, e) => ApplicationBaseWindowShutdown.Shutdown();
            UpdateLbl.MouseDown += (s, e) => ApplicationStartUtilityUpdate.Start();
            BaseWindow.PreviewKeyDown += ApplicationBaseWindowHotkeys.KeyDown;
            MinimizeBtn.Click += (s, e) => WindowState = WindowState.Minimized;
            MemoryLbl.MouseDown += (s, e) => GC.Collect();
            HeaderPanel.MouseDown += DragWindow;

            Timer.Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.ShowUsedMemoryUpdateInterval);
            Timer.Tick += (s, e) => GetApplicationCurrentUsedMemory.Get();

            Loaded += (sender, args) =>
            {
                Task.Run(CheckAvailabilityAlphaUpdates.GetPerm);

                Task.Run(GetNoInternetIconVisibility.Get);

                if (!CheckAvailabilityInternetConnection.Connect()) { NoConnectImage.Visibility = Visibility.Visible; }

                Task.Run(GetSacredUtilsProjectBirthday.Call);

                if (File.ReadAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\LicenseAgreement.su").Contains("true")) { GetChangeLogDialogVisibility.Get(); }

                AppSummary.Sw.Stop(); // Make Yourself ^_^

                Log.Info($"Loading SacredUtils application done ({AppSummary.Sw.Elapsed.TotalMilliseconds / 1000.00} seconds)!");
            };
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == 0) { DragMove(); }
        }
    }
}
