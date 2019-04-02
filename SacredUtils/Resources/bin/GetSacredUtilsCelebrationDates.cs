using System;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace SacredUtils.resources.bin
{
    public static class GetSacredUtilsCelebrationDates
    {
        public static void Call()
        {
            Set("ProjectBirthDay"); Set("NewYear");
            Set("AuthorBirthDay"); Set("Bar");
            Set("Ireland"); Set("WindDay"); Set("Earth");
            Set("Halloween"); Set("Fun"); Set("RandomLabel");
        }

        private static void Set(string day) 
        {
            if (day == "AuthorBirthDay")
            {
                DateTime parameterDate = DateTime.ParseExact("02/27", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                    {
                        if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                        {
                            MainWindow.MainWindowInstance.MyBirthdayImage.Visibility = 0;
                        }
                    }));
                }
            }

            if (day == "ProjectBirthDay")
            {
                DateTime parameterDate = DateTime.ParseExact("10/15", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                    {
                        if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                        {
                            MainWindow.MainWindowInstance.BirthdayImage.Visibility = 0;
                        }
                    }));
                }
            }

            if (day == "NewYear")
            {
                DateTime parameterDate = DateTime.ParseExact("01/01", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                    {
                        if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                        {
                            MainWindow.MainWindowInstance.NewYearImage.Visibility = 0;
                            MainWindow.MainWindowInstance.NewYear2Image.Visibility = 0;
                            MainWindow.MainWindowInstance.NewYear3Image.Visibility = 0;
                            MainWindow.MainWindowInstance.NewYear4Image.Visibility = 0;
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
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                    {
                        if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                        {
                            MainWindow.MainWindowInstance.BarImage.Visibility = 0;
                        }
                    }));
                }
            }

            if (day == "Ireland")
            {
                DateTime parameterDate = DateTime.ParseExact("03/17", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                    {
                        if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                        {
                            MainWindow.MainWindowInstance.IrelandImage.Visibility = 0;
                        }
                    }));
                }
            }

            if (day == "Earth")
            {
                DateTime parameterDate = DateTime.ParseExact("03/20", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                    {
                        if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                        {
                            MainWindow.MainWindowInstance.EarthImage.Visibility = 0;
                        }
                    }));
                }
            }

            if (day == "WindDay")
            {
                DateTime parameterDate = DateTime.ParseExact("06/15", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                    {
                        if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                        {
                            MainWindow.MainWindowInstance.WindDayImage.Visibility = 0;
                        }
                    }));
                }
            }

            if (day == "Halloween")
            {
                DateTime parameterDate = DateTime.ParseExact("10/31", "MM/dd", CultureInfo.InvariantCulture);
                DateTime todaysDate = DateTime.Today;

                if (parameterDate == todaysDate)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                    {
                        if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                        {
                            MainWindow.MainWindowInstance.JeckLampImage.Visibility = 0;
                            MainWindow.MainWindowInstance.GhostImage.Visibility = 0;
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
                    if (!AppSettings.ApplicationSettings.DisableCelebrationFunnyDay)
                    {
                        Random rnd = new Random();

                        int randomInt = rnd.Next(0, 2);

                        if (randomInt == 2)
                        {
                            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                            {
                                RotateTransform myRotateTransform = new RotateTransform {Angle = 180};

                                TransformGroup myTransformGroup = new TransformGroup();
                                myTransformGroup.Children.Add(myRotateTransform);

                                MainWindow.MainWindowInstance.BaseGrid.RenderTransformOrigin = new Point(0.5, 0.5);
                                MainWindow.MainWindowInstance.BaseGrid.RenderTransform = myTransformGroup;
                            }));
                        }
                    }
                }
            }

            if (day == "RandomLabel")
            {
                Random rnd = new Random();

                int randomInt = rnd.Next(0, 400);

                if (randomInt == 168)
                {
                    int fontSize = Convert.ToInt32(GetDataFromGoogleDisk("https://drive.google.com/uc?export=download&id=1DzUjXAXsdXb--aAS-gmyCYQUrzEN3Dzx"));
                    string labelContent = GetDataFromGoogleDisk("https://drive.google.com/uc?export=download&id=1T9VJX7Bu8Bo6JVs_GdHWV6gP8NDnYykX");

                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                    {
                        if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                        {
                            MainWindow.MainWindowInstance.SimpleLabel.FontSize = fontSize;
                            MainWindow.MainWindowInstance.SimpleLabel.Content = labelContent;
                            MainWindow.MainWindowInstance.SimpleLabel.Visibility = 0;
                        }
                    }));
                }
            }
        }

        private static string GetDataFromGoogleDisk(string uri)
        {
            string data = new WebClient().DownloadStringTaskAsync(new Uri(uri)).Result;
            return data;
        }
    }
}
