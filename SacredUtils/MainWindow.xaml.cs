using MaterialDesignThemes.Wpf;
using SacredUtils.resources.bin;
using SacredUtils.resources.dlg;
using SacredUtils.resources.pgs;
using System;
using System.Diagnostics;
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
    public partial class MainWindow
    {
        public static application_settings_one AppStgOne = new application_settings_one();
        public static application_settings_two AppStgTwo = new application_settings_two();
        public static chat_settings_one ChatStgOne = new chat_settings_one();
        public static font_settings_one FontStgOne = new font_settings_one();
        public static gameplay_settings_one GameplayStgOne = new gameplay_settings_one();
        public static graphics_settings_one GraphicsStgOne = new graphics_settings_one();
        public static modify_settings_one ModifyStgOne = new modify_settings_one();
        public static sound_settings_one SoundStgOne = new sound_settings_one();
        public static unselected_settings_one UnselectedStgOne = new unselected_settings_one();
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent(); EventSubscribe(); GetPermCheckingMemory();

            SelectSettings(UnselectedStgOne, MenuGpLabel);

            if (!CheckAvailabilityInternetConnection.Connect())
            {
                NoConnectImage.Visibility = Visibility.Visible;
            }

            GetApplicationLanguageValue.Get(); GetApplicationThemeValue.Get(); GetApplicationScaleValue.Get();
        }

        private void EventSubscribe()
        {
            MenuGrLabel.Click += (s, e) => SelectSettings(GraphicsStgOne, GraphicsPanel);
            MenuSnLabel.Click += (s, e) => SelectSettings(SoundStgOne, SoundPanel);
            MenuGpLabel.Click += (s, e) => SelectSettings(GameplayStgOne, GameplayPanel);
            MenuCtLabel.Click += (s, e) => SelectSettings(ChatStgOne, ChatPanel);
            MenuFtLabel.Click += (s, e) => SelectSettings(FontStgOne, FontsPanel);
            MenuMdLabel.Click += (s, e) => SelectSettings(ModifyStgOne, ModifPanel);
            MenuStLabel.Click += (s, e) => SelectSettings(AppStgOne, SettingsPanel);

            HeaderPanel.MouseDown += DragWindow; CloseBtn.Click += (s, e) => Shutdown();
            MinimizeBtn.Click += (s, e) => WindowState = WindowState.Minimized;

            _timer.Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.ShowUsedMemoryUpdateInterval);
            _timer.Tick += (s, e) => GetCurrentUsedMemory();

            Loaded += (sender, args) =>
            {
                GetLicenseState(); AppSummary.Sw.Stop();

                AppLogger.Log.Info($"Loading SacredUtils application done ({AppSummary.Sw.Elapsed.TotalMilliseconds / 1000.00} seconds)!");

                Task.Run(() =>
                {
                    GetApplicationDownloadStatistic.Get(); CheckAvailabilityAlphaUpdates.GetPerm();
                });
            };
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
            AppLogger.Log.Info("Special thanks to Shalinorus, Keboo, JetBrains");
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

            if (sender.Equals(sender as StackPanel) && sender is StackPanel panel)
            {
                AppLogger.Log.Info($"Selected SacredUtils settings category {panel.Name} by user");

                foreach (StackPanel sp in SettingsGrid.Children.OfType<StackPanel>())
                {
                    sp.SetResourceReference(BackgroundProperty, "CategoryNotActiveColorBrush");
                } 
                
                panel.SetResourceReference(BackgroundProperty, "CategoryActiveColorBrush");
            }
        }

        private void BaseWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Enum.TryParse(AppSettings.ApplicationSettings.KeyGotoMainMenu, out Key toMain);

            if (e.Key == toMain)
            {
                SelectSettings(UnselectedStgOne, MenuGpLabel);

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
                AppLogger.Log.Info("Preparing to updating SacredUtils application done!");

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
            license_dialog license = new license_dialog();

            DialogFrame.Visibility = Visibility.Visible;
            DialogFrame.Content = license;

            if (AppSettings.ApplicationSettings.ColorTheme == "dark")
            {
                license.LicenseDialog.DialogTheme = BaseTheme.Dark;
            }

            license.LicenseDialog.IsOpen = true;
        }

        private void MemoryLbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GC.Collect();
        }
    }
}
