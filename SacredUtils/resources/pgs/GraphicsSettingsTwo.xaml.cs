using SacredUtils.resources.prp;
using System.Windows;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class GraphicsSettingsTwo
    {
        public GraphicsSettingsTwo()
        {
            InitializeComponent(); DataContext = new GameGraphicsSettingsTwoProperty();

            Log.Info("Initialization components for graphics settings two done!");
        }

        private void ToOnePageBtn_Click(object sender, RoutedEventArgs e) => MainWindow.MainWindowInstance.SettingsFrame.Content = MainWindow.GraphicsStgOne;

        private void ToThreePageBtn_Click(object sender, RoutedEventArgs e) => MainWindow.MainWindowInstance.SettingsFrame.Content = MainWindow.GraphicsStgThree;
    }
}
