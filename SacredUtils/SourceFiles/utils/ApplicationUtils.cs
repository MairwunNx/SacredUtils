using System;
using System.Diagnostics;
using System.Windows;

namespace SacredUtils.SourceFiles.utils
{
    public static class ApplicationUtils
    {
        public static void Shutdown()
        {
            Logger.Log.Info("Shutting down SacredUtils application ...\n\n    *** Thanks for using SacredUtils! Created by MairwunNx\n    Special thanks to Shalinorus, Keboo, JetBrains\n\n    Shalinorus - for application test, and design test.\n    Keboo - for help with code and for MDIX library.\n    JetBrains - for help free license on all products.");
            Application.Current.Shutdown();
        }

        public static void Reload()
        {
            Process.Start(ApplicationInfo.AppPath);
            Environment.Exit(0);
        }
    }
}
