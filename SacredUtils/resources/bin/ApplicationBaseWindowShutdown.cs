using System.Windows;

namespace SacredUtils.resources.bin
{
    public static class ApplicationBaseWindowShutdown
    {
        public static void Shutdown()
        {
            AppLogger.Log.Info("============================================================");
            AppLogger.Log.Info("*** Thanks for using SacredUtils! Created by MairwunNx");
            AppLogger.Log.Info("Special thanks to Shalinorus, Keboo, JetBrains");
            AppLogger.Log.Info("============================================================");
            AppLogger.Log.Info("Shalinorus - for application test, and design test.");
            AppLogger.Log.Info("Keboo - for help with code and for MDIX library.");
            AppLogger.Log.Info("JetBrains - for help free license on all products.");
            AppLogger.Log.Info("============================================================");
            AppLogger.Log.Info("Shutting down SacredUtils application...");
            AppLogger.Log.Info("============================================================");

            Application.Current.Shutdown();
        }
    }
}
