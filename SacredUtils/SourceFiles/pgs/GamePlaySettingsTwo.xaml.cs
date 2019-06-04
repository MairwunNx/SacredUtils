using SacredUtils.resources.prp;
using System.Windows;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.resources.pgs
{
    public partial class GamePlaySettingsTwo
    {
        public GamePlaySettingsTwo()
        {
            InitializeComponent(); DataContext = new GamePlaySettingsTwoProperty();

            Log.Info("Initialization components for game play settings two done!");
        }

        private void ToOnePageBtn_Click(object sender, RoutedEventArgs e) => MainWindow.MainWindowInstance.SettingsFrame.Content = MainWindow.GamePlayStgOne;

        private void ToThreePageBtn_Click(object sender, RoutedEventArgs e) => MainWindow.MainWindowInstance.SettingsFrame.Content = MainWindow.GamePlayStgThree;
    }
}
