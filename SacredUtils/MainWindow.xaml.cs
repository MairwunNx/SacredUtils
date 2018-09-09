using System;
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
using SacredUtils.resources.pgs;
using SharpConfig;
using WPFSharp.Globalizer;

namespace SacredUtils
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            application_settings_one appStgOne       = new application_settings_one();
            chat_settings_one chatStgOne             = new chat_settings_one();
            font_settings_one fontStgOne             = new font_settings_one();
            gameplay_settings_one gameplayStgOne     = new gameplay_settings_one();
            graphics_settings_one graphicsStgOne     = new graphics_settings_one();
            modify_settings_one modifyStgOne         = new modify_settings_one();
            sound_settings_one soundStgOne           = new sound_settings_one();
            unselected_settings_one unselectedStgOne = new unselected_settings_one();

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

            SelectSettings(unselectedStgOne, MenuGpLabel);

            Height = Height * 1.3;
            Width = Width * 1.3;
            BaseCard.LayoutTransform = new ScaleTransform(1.3, 1.3);


            GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage
            (ApplicationInfo.Lang == "ru" ? "ru-RU" : "en-US", true);

            GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage("ru-RU", true);

            GlobalizedApplication.Instance.StyleManager.SwitchStyle("Light.xaml");

        }

        public void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { DragMove(); }
        }

        public void SelectSettings(UIElement element, object sender)
        {
            SettingsFrame.Content = element;

            StackPanel s = sender as StackPanel;

            if (sender.Equals(s) && s != null)
            {
                foreach (StackPanel sp in SettingsGrid.Children.OfType<StackPanel>())
                {
                    sp.SetResourceReference(BackgroundProperty, "CategoryNotActiveColorBrush");
                }

                s.SetResourceReference(BackgroundProperty, "CategoryActiveColorBrush");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //            ErrorDialog.Visibility = Visibility.Visible;
            //            ErrorDialog.IsOpen = true;
            //GlobalizedApplication.Instance.StyleManager.SwitchStyle("Dark.xaml");
        }
    }
}
