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

        public static void Call()
        {
            Set("ProjectBirthDay"); Set("NewYear");
            Set("AuthorBirthDay"); Set("Bar");
            Set("Ireland"); Set("WindDay"); Set("Earth");
        }

        private static void Set(string day) 
        {
            if (day == "AuthorBirthDay")
            {
                var parameterDate = DateTime.ParseExact("02/27", "MM/dd", CultureInfo.InvariantCulture);
                var todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                        if (MainWindow.NoConnectImage.Visibility != 0) { MainWindow.MyBirthdayImage.Visibility = 0; }
                    }));
                }
            }

            if (day == "ProjectBirthDay")
            {
                var parameterDate = DateTime.ParseExact("10/15", "MM/dd", CultureInfo.InvariantCulture);
                var todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                        if (MainWindow.NoConnectImage.Visibility != 0) { MainWindow.BirthdayImage.Visibility = 0; }
                    }));
                }
            }

            if (day == "NewYear")
            {
                var parameterDate = DateTime.ParseExact("01/01", "MM/dd", CultureInfo.InvariantCulture);
                var todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                        if (MainWindow.NoConnectImage.Visibility != 0)
                        {
                            MainWindow.NewYearImage.Visibility = 0; 
                            MainWindow.NewYear2Image.Visibility = 0; 
                            MainWindow.NewYear3Image.Visibility = 0; 
                            MainWindow.NewYear4Image.Visibility = 0; 
                        }
                    }));
                }
            }

            if (day == "Bar")
            {
                var parameterDate = DateTime.ParseExact("02/06", "MM/dd", CultureInfo.InvariantCulture);
                var todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                        if (MainWindow.NoConnectImage.Visibility != 0) { MainWindow.BarImage.Visibility = 0; }
                    }));
                }
            }

            if (day == "Ireland")
            {
                var parameterDate = DateTime.ParseExact("03/17", "MM/dd", CultureInfo.InvariantCulture);
                var todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                        if (MainWindow.NoConnectImage.Visibility != 0) { MainWindow.IrelandImage.Visibility = 0; }
                    }));
                }
            }

            if (day == "Earth")
            {
                var parameterDate = DateTime.ParseExact("03/20", "MM/dd", CultureInfo.InvariantCulture);
                var todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                        if (MainWindow.NoConnectImage.Visibility != 0) { MainWindow.EarthImage.Visibility = 0; }
                    }));
                }
            }

            if (day == "WindDay")
            {
                var parameterDate = DateTime.ParseExact("06/15", "MM/dd", CultureInfo.InvariantCulture);
                var todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                        if (MainWindow.NoConnectImage.Visibility != 0) { MainWindow.WindDayImage.Visibility = 0; }
                    }));
                }
            }
        }
    }
}
