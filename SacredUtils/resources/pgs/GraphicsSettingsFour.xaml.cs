using SacredUtils.resources.prp;
using System.Windows;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class GraphicsSettingsFour
    {
        public GraphicsSettingsFour()
        {
            InitializeComponent(); DataContext = new GameGraphicsSettingsFourProperty();

            Log.Info("Initialization components for graphics settings four done!");
        }

        private void ToThreePageBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GraphicsStgThree;

                Log.Info("Game graphics settings three page was opened by user");
            }
        }
    }
}
