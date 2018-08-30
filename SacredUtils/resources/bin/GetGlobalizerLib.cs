using System.Diagnostics;
using System.IO;
using static SacredUtils.resources.bin.ApplicationInfo;

namespace SacredUtils.resources.bin
{
    public class GetGlobalizerLib
    {
        public void Get()
        {
            if (!File.Exists("WPFSharp.Globalizer.dll")) { Create(); }
        }

        public void Create()
        {
            File.WriteAllBytes("WPFSharp.Globalizer.dll", Properties.Resources.WPFSharp_Globalizer);

            Process.Start(AppName);

            System.Windows.Application.Current.Shutdown();
        }
    }
}
