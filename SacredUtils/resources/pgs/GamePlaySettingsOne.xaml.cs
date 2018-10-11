using SacredUtils.resources.prp;
using System.Windows;

namespace SacredUtils.resources.pgs
{
    public partial class GamePlaySettingsOne
    {
        public GamePlaySettingsOne()
        {
            InitializeComponent(); DataContext = new GamePlaySettingsOneProperty();

            AppLogger.Log.Info("Initialization components for game play settings one done!");
        }

        private void ToTwoPageBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GamePlayStgTwo;

                AppLogger.Log.Info("Game play settings two page was opened by user");
            }
        }
    }
}
