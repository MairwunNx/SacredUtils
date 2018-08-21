using SacredUtils.resources.bin;
using System.Threading.Tasks;
using System.Windows;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            new GetLoggerConfig().Get();

            new GetAvailableFolders().Get();

            new CreateConfigurations().Create();

            Task.Run(() => new CreateRequiredFiles().Create());

            Task.Run(() => new GetLanguage().Get());

            new GetConfigCorrectness().Get();
        }
    }
}