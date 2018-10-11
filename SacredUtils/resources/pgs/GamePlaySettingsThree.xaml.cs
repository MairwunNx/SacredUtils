using System.Windows;
using SacredUtils.resources.prp;

namespace SacredUtils.resources.pgs
{
    public partial class GamePlaySettingsThree
    {
        public GamePlaySettingsThree()
        {
            InitializeComponent(); DataContext = new GamePlaySettingsThreeProperty();

            AppLogger.Log.Info("Initialization components for game play settings three done!");
        }

        private void ToTwoPageBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GamePlayStgTwo;

                AppLogger.Log.Info("Game play settings two page was opened by user");
            }
        }
    }
}
