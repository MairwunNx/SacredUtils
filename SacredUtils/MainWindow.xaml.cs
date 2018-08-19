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
using SacredUtils.resources.pgs;
using SharpConfig;

namespace SacredUtils
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            CloseBtn.Click += (s, e) => Application.Current.Shutdown();
            MinimizeBtn.Click += (s, e) => WindowState = WindowState.Minimized;
            ToolPanel.MouseDown += DragWindow;


            chat_settings_one page = new chat_settings_one();
            SettingsFrame.Content = page;

            //            Height = Height * 1.2;
            //            Width = Width * 1.2;
            //            BaseCard.LayoutTransform = new ScaleTransform(1.2, 1.2);
            //            SettingsBorder.BorderThickness = new Thickness(0,1,1,0);
        }

        public void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { DragMove(); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogHost.IsOpen = true;
        }
    }
}
