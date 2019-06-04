using SacredUtils.resources.prp;
using static SacredUtils.SourceFiles.Logger;

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
