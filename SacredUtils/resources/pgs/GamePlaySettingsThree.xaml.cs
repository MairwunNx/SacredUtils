using SacredUtils.resources.prp;
using System.Windows;
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

        private void ToTwoPageBtn_Click(object sender, RoutedEventArgs e) => MainWindow.MainWindowInstance.SettingsFrame.Content = MainWindow.GamePlayStgTwo;
    }
}
