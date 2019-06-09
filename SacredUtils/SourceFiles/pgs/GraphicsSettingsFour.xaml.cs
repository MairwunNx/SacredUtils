using System.Windows;
using SacredUtils.SourceFiles.prp;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.resources.pgs
{
    public partial class GraphicsSettingsFour
    {
        public GraphicsSettingsFour()
        {
            InitializeComponent(); DataContext = new GameGraphicsSettingsFourProperty();

            Log.Info("Initialization components for graphics settings four done!");
        }

        private void ToThreePageBtn_Click(object sender, RoutedEventArgs e) => MainWindow.MainWindowInstance.SettingsFrame.Content = MainWindow.GraphicsStgThree;
    }
}
