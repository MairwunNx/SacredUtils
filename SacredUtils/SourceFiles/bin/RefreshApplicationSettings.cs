using SacredUtils.resources.prp;
using SacredUtils.SourceFiles.prp;

namespace SacredUtils.resources.bin
{
    public static class RefreshApplicationSettings
    {
        public static void Refresh()
        {
            MainWindow.ChatStgOne.DataContext = null;
            MainWindow.FontStgOne.DataContext = null;
            MainWindow.GamePlayStgOne.DataContext = null;
            MainWindow.GamePlayStgTwo.DataContext = null;
            MainWindow.GamePlayStgThree.DataContext = null;
            MainWindow.GraphicsStgOne.DataContext = null;
            MainWindow.GraphicsStgTwo.DataContext = null;
            MainWindow.GraphicsStgThree.DataContext = null;
            MainWindow.SoundStgOne.DataContext = null;

            MainWindow.ChatStgOne.DataContext = new GameChatSettingsOneProperty();
            MainWindow.FontStgOne.DataContext = new GameFontSettingsOneProperty();
            MainWindow.GamePlayStgOne.DataContext = new GamePlaySettingsOneProperty();
            MainWindow.GamePlayStgTwo.DataContext = new GamePlaySettingsTwoProperty();
            MainWindow.GamePlayStgThree.DataContext = new GamePlaySettingsThreeProperty();
            MainWindow.GraphicsStgOne.DataContext = new GameGraphicsSettingsOneProperty();
            MainWindow.GraphicsStgTwo.DataContext = new GameGraphicsSettingsTwoProperty();
            MainWindow.GraphicsStgThree.DataContext = new GameGraphicsSettingsThreeProperty();
            MainWindow.SoundStgOne.DataContext = new GameSoundSettingsOneProperty();
        }
    }
}
