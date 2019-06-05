using System;
using System.Diagnostics;
using System.Windows;
using static SacredUtils.SourceFiles.ApplicationInfo;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.SourceFiles.utils
{
    public static class ApplicationUtils
    {
        public static void Shutdown()
        {
            Log.Info(
                "Shutting down SacredUtils application ...\n\n    *** Thanks for using SacredUtils! Created by MairwunNx\n    Special thanks to Shalinorus, Keboo, JetBrains\n\n    Shalinorus - for application test, and design test.\n    Keboo - for help with code and for MDIX library.\n    JetBrains - for help free license on all products."
            );
            Application.Current.Shutdown();
        }

        public static void Reload()
        {
            Process.Start(AppPath);
            Environment.Exit(0);
        }
    }
}
