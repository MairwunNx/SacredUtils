using Config.Net;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.bin;
using SacredUtils.resources.dlg;
using SacredUtils.resources.pgs;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace SacredUtils
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class MainWindow
    {
        public application_settings_one _appStgOne       = new application_settings_one();
        public application_settings_two _appStgTwo       = new application_settings_two();
        public chat_settings_one _chatStgOne             = new chat_settings_one();
        public font_settings_one _fontStgOne             = new font_settings_one();
        public gameplay_settings_one _gameplayStgOne     = new gameplay_settings_one();
        public graphics_settings_one _graphicsStgOne     = new graphics_settings_one();
        public modify_settings_one _modifyStgOne         = new modify_settings_one();
        public sound_settings_one _soundStgOne           = new sound_settings_one();
        public unselected_settings_one _unselectedStgOne = new unselected_settings_one();
        public DispatcherTimer _timer                    = new DispatcherTimer();

        public MainWindow()
        {
            AppLogger.Log.Info("*** Initializing SacredUtils components ...");

            InitializeComponent(); EventSubscribe(); GetPermCheckingMemory();

            AppLogger.Log.Info("Initializing SacredUtils components done!");

            SelectSettings(_unselectedStgOne, MenuGpLabel);

            GetApplicationLanguageValue.Get(); GetApplicationThemeValue.Get(); GetApplicationScaleValue.Get();

            Task.Run(() => CheckAvailabilityAlphaUpdates.GetGarbage());
        }

        private void EventSubscribe()
        {
            MenuGrLabel.Click += (s, e) => SelectSettings(_graphicsStgOne, GraphicsPanel);
            MenuSnLabel.Click += (s, e) => SelectSettings(_soundStgOne, SoundPanel);
            MenuGpLabel.Click += (s, e) => SelectSettings(_gameplayStgOne, GameplayPanel);
            MenuCtLabel.Click += (s, e) => SelectSettings(_chatStgOne, ChatPanel);
            MenuFtLabel.Click += (s, e) => SelectSettings(_fontStgOne, FontsPanel);
            MenuMdLabel.Click += (s, e) => SelectSettings(_modifyStgOne, ModifPanel);
            MenuStLabel.Click += (s, e) => SelectSettings(_appStgOne, SettingsPanel);

            HeaderPanel.MouseDown += DragWindow;
            CloseBtn.Click += (s, e) => Shutdown();
            MinimizeBtn.Click += (s, e) => WindowState = WindowState.Minimized;

            IAppSettings applicationSettings =
                new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            _timer.Interval = new TimeSpan(0, 0, applicationSettings.ShowUsedMemoryUpdateInterval);
            _timer.Tick += (s, e) => GetCurrentUsedMemory();

            Loaded += (sender, args) =>
            {
                GetLicenseState(); AppSummary.Sw.Stop();

                AppLogger.Log.Info($"Loading SacredUtils application done ({AppSummary.Sw.Elapsed.TotalMilliseconds / 1000.00} seconds)!");
            };
        }

        private void GetCurrentUsedMemory()
        {
            MemoryLbl.Content = $"[{RuntimeInformation.FrameworkDescription.ToUpper()}] [{Process.GetCurrentProcess().Id} / {Process.GetCurrentProcess().PriorityClass.ToString().ToUpper()}] USED MEMORY {GC.GetTotalMemory(false) / 1024} KB OF {Environment.WorkingSet / 1024} KB";
        }

        private void GetPermCheckingMemory()
        {
            IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            // Isabella ... Sorry please ...

            if (applicationSettings.ShowUsedMemory)
            {
                MemoryLbl.Visibility = Visibility.Visible; _timer.Start();
            }
            else
            {
                MemoryLbl.Visibility = Visibility.Hidden; _timer.Stop();
            }
        }

        private static void Shutdown()
        {
            AppLogger.Log.Info("*** Thanks for using SacredUtils! Created by MairwunNx");
            AppLogger.Log.Info("Shutting down SacredUtils ...");

            Application.Current.Shutdown();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { DragMove(); }
        }

        private void SelectSettings(UIElement element, object sender)
        {
            SettingsFrame.Content = element;

            StackPanel s = sender as StackPanel;

            if (sender.Equals(s) && s != null)
            {
                AppLogger.Log.Info($"Selected settings category {s.Name} by user");

                foreach (StackPanel sp in SettingsGrid.Children.OfType<StackPanel>())
                {
                    sp.SetResourceReference(BackgroundProperty, "CategoryNotActiveColorBrush");
                }

                s.SetResourceReference(BackgroundProperty, "CategoryActiveColorBrush");
            }
        }

        private void BaseWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            Enum.TryParse(applicationSettings.KeyRefreshSettings, out Key refresh);
            Enum.TryParse(applicationSettings.KeyGotoMainMenu, out Key toMain);

            if (e.Key == refresh)
            {
                 _appStgOne.GetSettings(); _appStgTwo.GetSettings();
            }

            if (e.Key == toMain)
            {
                SelectSettings(_unselectedStgOne, MenuGpLabel);

                foreach (StackPanel sp in SettingsGrid.Children.OfType<StackPanel>())
                {
                    sp.SetResourceReference(BackgroundProperty, "CategoryNotActiveColorBrush");
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.E)
            {
                if (File.Exists("$SacredUtils\\logs\\latest.log"))
                {
                    Process.Start("notepad", "$SacredUtils\\logs\\latest.log");
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.R)
            {
                if (File.Exists("$SacredUtils\\conf\\settings.json"))
                {
                    Process.Start("notepad", "$SacredUtils\\conf\\settings.json");
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.T)
            {
                Process.Start(AppSummary.AppPatch); Environment.Exit(0);
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.Y)
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                Process.Start(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName));
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.P)
            {
                Shutdown();
            }
        }

        private void UpdateLbl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AppDomain domain = AppDomain.CurrentDomain;

                AppLogger.Log.Info("Preparing to updating application done!");

                Process.Start("mnxupdater.exe", domain.FriendlyName + " _newVersionSacredUtilsTemp.exe");

                Shutdown();
            }
            catch (Exception ex)
            {
                AppLogger.Log.Info(ex.ToString);
            }
        }

        private void GetLicenseState()
        {
            IAppSettings licenseSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (!licenseSettings.AcceptLicense || !File.Exists("License.txt"))
            {
                File.WriteAllBytes("License.txt", Properties.Resources.AppLicense);

                UpdateLbl.IsEnabled = false; MinimizeBtn.IsEnabled = false;

                OpenLicenseDialog();
            }
        }

        private void OpenLicenseDialog()
        {
            license_dialog license = new license_dialog();

            DialogFrame.Visibility = Visibility.Visible;
            DialogFrame.Content = license;

            IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (applicationSettings.ColorTheme == "dark")
            {
                license.LicenseDialog.DialogTheme = BaseTheme.Dark;
            }

            license.LicenseDialog.IsOpen = true;

            AppLogger.Log.Info("License dialog was opened by program");
        }
    }
}
