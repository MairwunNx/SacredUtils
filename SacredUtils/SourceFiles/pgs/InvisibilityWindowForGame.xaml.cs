using System;
using System.Diagnostics;
using System.Windows.Threading;

namespace SacredUtils.resources.pgs
{
    public partial class InvisibilityWindowForGame
    {
        public InvisibilityWindowForGame()
        {
            InitializeComponent(); CheckAvailabilityProcess();
        }

        private static void CheckAvailabilityProcess()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 5)
            };

            timer.Tick += (s, e) =>
            {
                Process[] pname = Process.GetProcessesByName("Sacred");

                if (pname.Length == 0) { Environment.Exit(0); }
            };

            timer.Start();
        }
    }
}
