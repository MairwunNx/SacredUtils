using System;
using System.Linq;
using System.Runtime.InteropServices;
using static SacredUtils.SourceFiles.ApplicationInfo;

namespace SacredUtils.SourceFiles
{
    public static class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);
    }

    public static class SystemInfo
    {
        public static int HeightResolution = 720;
        public static int WidthResolution = 1280;

        public static void Init()
        {
            if (AppArguments.Contains("-stayOnDefaultResolution")) return;
            WidthResolution = NativeMethods.GetSystemMetrics(78);
            HeightResolution = NativeMethods.GetSystemMetrics(79);
        }
    }
}
