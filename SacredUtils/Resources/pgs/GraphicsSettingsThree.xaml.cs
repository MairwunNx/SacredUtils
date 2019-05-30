using SacredUtils.resources.prp;
using System.Windows;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class GraphicsSettingsThree
    {
        public GraphicsSettingsThree()
        {
            InitializeComponent(); DataContext = new GameGraphicsSettingsThreeProperty();

            Log.Info("Initialization components for graphics settings three done!");
        }

        private void ToTwoPageBtn_Click(object sender, RoutedEventArgs e) => MainWindow.MainWindowInstance.SettingsFrame.Content = MainWindow.GraphicsStgTwo;

        private void ToFourPageBtn_Click(object sender, RoutedEventArgs e) => MainWindow.MainWindowInstance.SettingsFrame.Content = MainWindow.GraphicsStgFour;
    }
}
