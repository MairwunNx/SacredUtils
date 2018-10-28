using System.Windows;
using SacredUtils.resources.prp;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class GamePlaySettingsThree
    {
        public GamePlaySettingsThree()
        {
            InitializeComponent(); DataContext = new GamePlaySettingsThreeProperty();

            Log.Info("Initialization components for game play settings three done!");
        }

        private void ToTwoPageBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GamePlayStgTwo;

                Log.Info("Game play settings two page was opened by user");
            }
        }
    }
}
