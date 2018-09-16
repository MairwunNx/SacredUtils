using SacredUtils.resources.bin;
using SacredUtils.resources.pgs;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Config.Net;
using WPFSharp.Globalizer;

namespace SacredUtils
{
    public partial class MainWindow
    {
        application_settings_one _appStgOne       = new application_settings_one();
        chat_settings_one _chatStgOne             = new chat_settings_one();
        font_settings_one _fontStgOne             = new font_settings_one();
        gameplay_settings_one _gameplayStgOne     = new gameplay_settings_one();
        graphics_settings_one _graphicsStgOne     = new graphics_settings_one();
        modify_settings_one _modifyStgOne         = new modify_settings_one();
        sound_settings_one _soundStgOne           = new sound_settings_one();
        unselected_settings_one _unselectedStgOne = new unselected_settings_one();

        public MainWindow()
        {
            GetLoggerConfig.Log.Info("*** Initializing SacredUtils components ...");

            InitializeComponent(); EventSubscribe(); GetLanguage(); GetScale();

            GetLoggerConfig.Log.Info("Initializing SacredUtils components done!");

            SelectSettings(_unselectedStgOne, MenuGpLabel);
        }

        private void EventSubscribe()
        {
            GetLoggerConfig.Log.Info("Adding events subscribes on buttons ...");

            MenuGrLabel.Click += (s, e) => SelectSettings(_graphicsStgOne, GraphicsPanel);
            MenuSnLabel.Click += (s, e) => SelectSettings(_soundStgOne, SoundPanel);
            MenuGpLabel.Click += (s, e) => SelectSettings(_gameplayStgOne, GameplayPanel);
            MenuCtLabel.Click += (s, e) => SelectSettings(_chatStgOne, ChatPanel);
            MenuFtLabel.Click += (s, e) => SelectSettings(_fontStgOne, FontsPanel);
            MenuMdLabel.Click += (s, e) => SelectSettings(_modifyStgOne, ModifPanel);
            MenuStLabel.Click += (s, e) => SelectSettings(_appStgOne, SettingsPanel);

            CloseBtn.Click += (s, e) => Application.Current.Shutdown();
            MinimizeBtn.Click += (s, e) => WindowState = WindowState.Minimized;

            HeaderPanel.MouseDown += DragWindow;

            Loaded += (sender, args) => GetLoggerConfig.Log.Info("Loading SacredUtils application fully done!");

            GetLoggerConfig.Log.Info("Adding events subscribes on buttons done!");
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { DragMove(); }
        }

        public void SelectSettings(UIElement element, object sender)
        {
            SettingsFrame.Content = element;

            StackPanel s = sender as StackPanel;

            if (sender.Equals(s) && s != null)
            {
                GetLoggerConfig.Log.Info($"Selected settings category {s.Name} by user");

                _appStgOne.GetSettings();

                foreach (StackPanel sp in SettingsGrid.Children.OfType<StackPanel>())
                {
                    sp.SetResourceReference(BackgroundProperty, "CategoryNotActiveColorBrush");
                }

                s.SetResourceReference(BackgroundProperty, "CategoryActiveColorBrush");
            }
        }

        private void GetLanguage()
        {
            GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage
                (ApplicationInfo.Lang == "ru" ? "ru-RU" : "en-US", true);
        }

        public void GetScale()
        {
            Height = Height * ApplicationInfo.Scale;
            Width = Width * ApplicationInfo.Scale;
            BaseCard.LayoutTransform = new ScaleTransform(ApplicationInfo.Scale, ApplicationInfo.Scale);
        }

        private void BaseWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.F5)
            {
                _appStgOne.GetSettings();
            }
        }
    }
}
