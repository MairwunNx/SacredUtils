using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Castle.Core.Logging;
using FluentFTP;
using NLog;
using NLog.Targets;
using SacredUtils.resources.bin;
using SacredUtils.resources.pgs;
using SharpConfig;

namespace SacredUtils
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            application_settings_one appStgOne = new application_settings_one();
            application_settings_two appStgTwo = new application_settings_two();
            chat_settings_one chatStgOne = new chat_settings_one();
            font_settings_one fontStgOne = new font_settings_one();
            gameplay_settings_one gameplayStgOne = new gameplay_settings_one();
            gameplay_settings_two gameplayStgTwo = new gameplay_settings_two();
            gameplay_settings_three gameplayStgThree = new gameplay_settings_three();
            graphics_settings_one graphicsStgOne = new graphics_settings_one();
            graphics_settings_two graphicsStgTwo = new graphics_settings_two();
            graphics_settings_three graphicsStgThree = new graphics_settings_three();
            graphics_settings_four graphicsStgFour = new graphics_settings_four();
            modify_settings_one modifyStgOne = new modify_settings_one();
            sound_settings_one soundStgOne = new sound_settings_one();
            unselected_settings_one unselectedStgOne = new unselected_settings_one();

            GraphicsPanel.MouseLeftButtonDown += (s, e) => SelectSettings(graphicsStgOne);
            SoundPanel.MouseLeftButtonDown += (s, e) => SelectSettings(soundStgOne);
            GameplayPanel.MouseLeftButtonDown += (s, e) => SelectSettings(gameplayStgOne);
            ChatPanel.MouseLeftButtonDown += (s, e) => SelectSettings(chatStgOne);
            FontsPanel.MouseLeftButtonDown += (s, e) => SelectSettings(fontStgOne);
            ModifPanel.MouseLeftButtonDown += (s, e) => SelectSettings(modifyStgOne);
            SettingsPanel.MouseLeftButtonDown += (s, e) => SelectSettings(appStgOne);

            CloseBtn.Click += (s, e) => Application.Current.Shutdown();
            MinimizeBtn.Click += (s, e) => WindowState = WindowState.Minimized;

            HeaderPanel.MouseDown += DragWindow;

            SelectSettings(unselectedStgOne);

            Height = Height * 1.3;
            Width = Width * 1.3;
            BaseCard.LayoutTransform = new ScaleTransform(1.3, 1.3);
        }

        public void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { DragMove(); }
        }

        public void SelectSettings(UIElement element)
        {
            SettingsFrame.Content = element;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ErrorDialog.Visibility = Visibility.Visible;
            ErrorDialog.IsOpen = true;
        }
    }
}
