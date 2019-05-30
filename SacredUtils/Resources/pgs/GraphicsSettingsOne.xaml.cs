using SacredUtils.resources.prp;
using System.Windows;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class GraphicsSettingsOne
    {
        public GraphicsSettingsOne()
        {
            InitializeComponent(); DataContext = new GameGraphicsSettingsOneProperty();

            Log.Info("Initialization components for graphics settings one done!");
        }

        private void ToTwoPageBtn_Click(object sender, RoutedEventArgs e) => MainWindow.MainWindowInstance.SettingsFrame.Content = MainWindow.GraphicsStgTwo;
    }
}
