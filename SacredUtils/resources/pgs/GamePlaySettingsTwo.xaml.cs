using System.Windows;
using SacredUtils.resources.prp;

namespace SacredUtils.resources.pgs
{
    public partial class GamePlaySettingsTwo
    {
        public GamePlaySettingsTwo()
        {
            InitializeComponent(); DataContext = new GamePlaySettingsTwoProperty();

            AppLogger.Log.Info("Initialization components for game play settings two done!");
        }

        private void ToOnePageBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GamePlayStgOne;

                AppLogger.Log.Info("Game play settings one page was opened by user");
            }
        }

        private void ToThreePageBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GamePlayStgThree;

                AppLogger.Log.Info("Game play settings three page was opened by user");
            }
        }
    }
}
