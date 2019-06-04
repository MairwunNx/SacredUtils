using SacredUtils.resources.prp;
using System.Windows;
using static SacredUtils.Logger;

namespace SacredUtils.resources.pgs
{
    public partial class GamePlaySettingsOne
    {
        public GamePlaySettingsOne()
        {
            InitializeComponent(); DataContext = new GamePlaySettingsOneProperty();

            Log.Info("Initialization components for game play settings one done!");
        }

        private void ToTwoPageBtn_Click(object sender, RoutedEventArgs e) => MainWindow.MainWindowInstance.SettingsFrame.Content = MainWindow.GamePlayStgTwo;
    }
}
