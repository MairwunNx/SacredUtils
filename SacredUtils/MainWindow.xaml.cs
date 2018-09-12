using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Castle.Core.Logging;
using MaterialDesignThemes.Wpf;
using NLog;
using NLog.Targets;
using SacredUtils.resources.bin;
using SacredUtils.resources.dlg;
using SacredUtils.resources.pgs;
using SharpConfig;
using WPFSharp.Globalizer;

namespace SacredUtils
{
    public partial class MainWindow
    {
        application_settings_one appStgOne = new application_settings_one();
        chat_settings_one chatStgOne = new chat_settings_one();
        font_settings_one fontStgOne = new font_settings_one();
        gameplay_settings_one gameplayStgOne = new gameplay_settings_one();
        graphics_settings_one graphicsStgOne = new graphics_settings_one();
        modify_settings_one modifyStgOne = new modify_settings_one();
        sound_settings_one soundStgOne = new sound_settings_one();
        unselected_settings_one unselectedStgOne = new unselected_settings_one();

        public MainWindow()
        {
            GetLoggerConfig.Log.Info("*** Initializing SacredUtils components ...");

            InitializeComponent();

            EventSubscribe();

            GetLoggerConfig.Log.Info("Initializing SacredUtils components done!");

            GetLanguage();

            GetTheme();

            GetScale();

            SelectSettings(unselectedStgOne, MenuGpLabel);

        }

        private void EventSubscribe()
        {
            GetLoggerConfig.Log.Info("Adding events subscribes on buttons ...");

            MenuGrLabel.Click += (s, e) => SelectSettings(graphicsStgOne, GraphicsPanel);
            MenuSnLabel.Click += (s, e) => SelectSettings(soundStgOne, SoundPanel);
            MenuGpLabel.Click += (s, e) => SelectSettings(gameplayStgOne, GameplayPanel);
            MenuCtLabel.Click += (s, e) => SelectSettings(chatStgOne, ChatPanel);
            MenuFtLabel.Click += (s, e) => SelectSettings(fontStgOne, FontsPanel);
            MenuMdLabel.Click += (s, e) => SelectSettings(modifyStgOne, ModifPanel);
            MenuStLabel.Click += (s, e) => SelectSettings(appStgOne, SettingsPanel);

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

        private void SelectSettings(UIElement element, object sender)
        {
            SettingsFrame.Content = element;

            StackPanel s = sender as StackPanel;

            if (sender.Equals(s) && s != null)
            {
                GetLoggerConfig.Log.Info($"Selected settings category {s.Name} by user");

                foreach (StackPanel sp in SettingsGrid.Children.OfType<StackPanel>())
                {
                    sp.SetResourceReference(BackgroundProperty, "CategoryNotActiveColorBrush");
                }

                s.SetResourceReference(BackgroundProperty, "CategoryActiveColorBrush");
            }
        }

        private static void GetLanguage()
        {
            GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage
                (ApplicationInfo.Lang == "ru" ? "ru-RU" : "en-US", true);
        }

        private static void GetTheme()
        {
            GlobalizedApplication.Instance.StyleManager.SwitchStyle
            (ApplicationInfo.Theme == "light" ? "Light.xaml" : "Dark.xaml");
        }

        private void GetScale()
        {
            Height = Height * ApplicationInfo.Scale;
            Width = Width * ApplicationInfo.Scale;
            BaseCard.LayoutTransform = new ScaleTransform(ApplicationInfo.Scale, ApplicationInfo.Scale);
        }
    }
}
