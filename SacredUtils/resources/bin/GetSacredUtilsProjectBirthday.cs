using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Media;
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
            Set("Halloween"); Set("Fun");
        }

        private static void Set(string day) 
        {
            if (day == "AuthorBirthDay")
            {
                DateTime parameterDate = DateTime.ParseExact("02/27", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

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
                DateTime parameterDate = DateTime.ParseExact("10/15", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

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
                DateTime parameterDate = DateTime.ParseExact("01/01", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

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
                DateTime parameterDate = DateTime.ParseExact("02/06", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

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
                DateTime parameterDate = DateTime.ParseExact("03/17", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

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
                DateTime parameterDate = DateTime.ParseExact("03/20", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

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
                DateTime parameterDate = DateTime.ParseExact("06/15", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                        if (MainWindow.NoConnectImage.Visibility != 0) { MainWindow.WindDayImage.Visibility = 0; }
                    }));
                }
            }

            if (day == "Halloween")
            {
                DateTime parameterDate = DateTime.ParseExact("10/31", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                        if (MainWindow.NoConnectImage.Visibility != 0)
                        {
                            MainWindow.JeckLampImage.Visibility = 0; 
                            MainWindow.GhostImage.Visibility = 0;
                        }
                    }));
                }
            }

            if (day == "Fun")
            {
                DateTime parameterDate = DateTime.ParseExact("04/01", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    if (AppSettings.ApplicationSettings.DisableFoolFunnyDay)
                    {
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                        {
                            RotateTransform myRotateTransform = new RotateTransform { Angle = 180 };

                            TransformGroup myTransformGroup = new TransformGroup();
                            myTransformGroup.Children.Add(myRotateTransform);

                            MainWindow.BaseGrid.RenderTransformOrigin = new Point(0.5, 0.5);
                            MainWindow.BaseGrid.RenderTransform = myTransformGroup;
                        }));
                    }
                }
            }
        }
    }
}
