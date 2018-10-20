using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace SacredUtils.resources.bin
{
    public static class GetSacredUtilsProjectBirthday
    {
        static readonly MainWindow MainWindow = (MainWindow)Application.Current.MainWindow;

        private static bool Get()
        {
            var parameterDate = DateTime.ParseExact("10/15", "MM/dd", CultureInfo.InvariantCulture);
            var todaysDate = DateTime.Today;

            return parameterDate == todaysDate;
        }

        public static void Set()
        {
            if (Get())
            {
                AppLogger.Log.Info("!!! *** HAPPY BIRTHDAY TO ME, HAPPY BIRTHDAY TO ME, HAPPY BIRTHDAY TO ME *** !!!");

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                    if (MainWindow.NoConnectImage.Visibility != 0) { MainWindow.BirthdayImage.Visibility = 0; }
                }));
            }
        }
    }
}
