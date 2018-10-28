﻿using SacredUtils.resources.prp;
using System.Windows;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class GraphicsSettingsThree
    {
        public GraphicsSettingsThree()
        {
            InitializeComponent(); DataContext = new GameGraphicsSettingsThreeProperty();

            Log.Info("Initialization components for graphics settings three done!");
        }

        private void ToTwoPageBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GraphicsStgTwo;

                Log.Info("Game graphics settings two page was opened by user");
            }
        }

        private void ToFourPageBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GraphicsStgFour;

                Log.Info("Game graphics settings four page was opened by user");
            }
        }
    }
}
