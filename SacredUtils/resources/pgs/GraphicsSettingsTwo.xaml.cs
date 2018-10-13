using SacredUtils.resources.prp;
using System.Windows;

namespace SacredUtils.resources.pgs
{
    public partial class GraphicsSettingsTwo
    {
        public GraphicsSettingsTwo()
        {
            InitializeComponent(); DataContext = new GameGraphicsSettingsTwoProperty();

            AppLogger.Log.Info("Initialization components for graphics settings two done!");
        }

        private void ToOnePageBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GraphicsStgOne;

                AppLogger.Log.Info("Game graphics settings one page was opened by user");
            }
        }

        private void ToThreePageBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GraphicsStgThree;

                AppLogger.Log.Info("Game graphics settings three page was opened by user");
            }
        }
    }
}
