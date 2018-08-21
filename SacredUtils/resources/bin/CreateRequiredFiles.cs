using System.IO;
using Config.Net;

namespace SacredUtils.resources.bin
{
    public interface IReqiredFilesSettings
    {
        bool DebugFileCreate { get; }
        bool LicenseFileCreate { get; }
    }
    public class CreateRequiredFiles
    {
        public IReqiredFilesSettings ReqiredFilesSettings = new ConfigurationBuilder<IReqiredFilesSettings>()
            .UseJsonFile("$SacredUtils\\conf\\reqiredfiles.json").Build();

        public void Create()
        {
            GetLoggerConfig.Log.Info("Check permission to create debug file");

            if (ReqiredFilesSettings.DebugFileCreate)
            {
                File.WriteAllBytes("SacredUtils.pdb", Properties.Resources.SacredUtils);

                GetLoggerConfig.Log.Info("Debug file were created in this folder");
            }

            GetLoggerConfig.Log.Info("Check permission to create license file");

            if (ReqiredFilesSettings.LicenseFileCreate)
            {
                File.WriteAllBytes("License.txt", Properties.Resources.license);

                GetLoggerConfig.Log.Info("License file were created in this folder");
            }
        }
    }
}
