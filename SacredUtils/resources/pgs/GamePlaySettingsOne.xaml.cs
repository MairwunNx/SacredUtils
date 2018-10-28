using SacredUtils.resources.prp;
using System.Windows;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class GamePlaySettingsOne
    {
        public GamePlaySettingsOne()
        {
            InitializeComponent(); DataContext = new GamePlaySettingsOneProperty();

            Log.Info("Initialization components for game play settings one done!");
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
