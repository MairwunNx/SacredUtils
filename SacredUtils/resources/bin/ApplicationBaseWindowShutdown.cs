using System.Windows;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class ApplicationBaseWindowShutdown
    {
        public static void Shutdown()
        {
            Log.Info("============================================================");
            Log.Info("*** Thanks for using SacredUtils! Created by MairwunNx");
            Log.Info("Special thanks to Shalinorus, Keboo, JetBrains");
            Log.Info("============================================================");
            Log.Info("Shalinorus - for application test, and design test.");
            Log.Info("Keboo - for help with code and for MDIX library.");
            Log.Info("JetBrains - for help free license on all products.");
            Log.Info("============================================================");
            Log.Info("Shutting down SacredUtils application...");
            Log.Info("============================================================");

            Application.Current.Shutdown();
        }
    }
}
