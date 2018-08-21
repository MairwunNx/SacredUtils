using System;
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

            try
            {
                new GetLoggerConfig().Get();

                new GetAvailableFolders().Get();

                new CreateConfigurations().Create();

                Task.Run(() => new CreateRequiredFiles().Create());

                Task.Run(() => new GetLanguage().Get());

                Task.Run(() => new SendStatistic().Get());

                new GetConfigCorrectness().Get();
            }
            catch (Exception exception)
            {
                GetLoggerConfig.Log.Fatal("There was a critical error of the program, sorry please, if the program could not start. Contact the Creator of the utility.");
                GetLoggerConfig.Log.Fatal(exception.ToString);
            }

        }
    }
}