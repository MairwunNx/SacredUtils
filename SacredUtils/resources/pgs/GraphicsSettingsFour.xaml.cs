using SacredUtils.resources.prp;
using System.Windows;

namespace SacredUtils.resources.pgs
{
    public partial class GraphicsSettingsFour
    {
        public GraphicsSettingsFour()
        {
            InitializeComponent(); DataContext = new GameGraphicsSettingsFourProperty();

            AppLogger.Log.Info("Initialization components for graphics settings four done!");
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
