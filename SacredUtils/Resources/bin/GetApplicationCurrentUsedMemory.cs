using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationCurrentUsedMemory
    {
        public static void Get() => MainWindow.MainWindowInstance.MemoryLbl.Content = $"[{RuntimeInformation.FrameworkDescription.ToUpper()}] [{Process.GetCurrentProcess().Id} / {Process.GetCurrentProcess().PriorityClass.ToString().ToUpper()}] USED MEMORY {GC.GetTotalMemory(false) / 1024} KB OF {Environment.WorkingSet / 1024} KB";
    }
}
