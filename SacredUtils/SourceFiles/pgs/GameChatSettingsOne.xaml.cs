using SacredUtils.resources.prp;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class GameChatSettingsOne
    {
        public GameChatSettingsOne()
        {
            InitializeComponent(); DataContext = new GameChatSettingsOneProperty();

            Log.Info("Initialization components for game chat settings one done!");
        }
    }
}
