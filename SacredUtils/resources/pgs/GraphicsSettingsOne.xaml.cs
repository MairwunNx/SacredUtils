using SacredUtils.resources.prp;
using System.Windows;

namespace SacredUtils.resources.pgs
{
    public partial class GraphicsSettingsOne
    {
        public GraphicsSettingsOne()
        {
            InitializeComponent(); DataContext = new GameGraphicsSettingsOneProperty();

            AppLogger.Log.Info("Initialization components for graphics settings one done!");
        }

        private void ToTwoPageBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).SettingsFrame.Content = MainWindow.GraphicsStgTwo;

                AppLogger.Log.Info("Game graphics settings two page was opened by user");
            }
        }
    }
}
