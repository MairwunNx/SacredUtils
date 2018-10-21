using System.Windows;
using SacredUtils.resources.prp;

namespace SacredUtils.resources.pgs
{
    public partial class GameChatSettingsOne
    {
        public GameChatSettingsOne()
        {
            InitializeComponent(); DataContext = new GameChatSettingsOneProperty();

            AppLogger.Log.Info("Initialization components for game chat settings one done!");
        }
    }
}
