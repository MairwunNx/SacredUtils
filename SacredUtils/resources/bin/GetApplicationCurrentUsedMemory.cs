using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationCurrentUsedMemory
    {
        static readonly MainWindow MainWindow = (MainWindow)Application.Current.MainWindow;

        public static void Get()
        {
            MainWindow.MemoryLbl.Content = $"[{RuntimeInformation.FrameworkDescription.ToUpper()}] [{Process.GetCurrentProcess().Id} / {Process.GetCurrentProcess().PriorityClass.ToString().ToUpper()}] USED MEMORY {GC.GetTotalMemory(false) / 1024} KB OF {Environment.WorkingSet / 1024} KB";
        }
    }
}
