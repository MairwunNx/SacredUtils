using System.Windows;
using SacredUtils.resources.prp;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class GamePlaySettingsTwo
    {
        public GamePlaySettingsTwo()
        {
            InitializeComponent(); DataContext = new GamePlaySettingsTwoProperty();

            Log.Info("Initialization components for game play settings two done!");
        }

        private void ToOnePageBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GamePlayStgOne;

                Log.Info("Game play settings one page was opened by user");
            }
        }

        private void ToThreePageBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GamePlayStgThree;

                Log.Info("Game play settings three page was opened by user");
            }
        }
    }
}
