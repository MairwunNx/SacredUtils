using System;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using SacredUtils.SourceFiles;
using SacredUtils.SourceFiles.bin;

namespace SacredUtils.resources.bin
{
    public static class GetSacredUtilsCelebrationDates
    {
        private static readonly DateTime TodayDate = DateTime.Today;
        private static readonly DateTime FounderBirthDayDate = DateTime.ParseExact("02/27", "MM/dd", CultureInfo.InvariantCulture);
        private static readonly DateTime ProjectBirthDayDate = DateTime.ParseExact("10/15", "MM/dd", CultureInfo.InvariantCulture);
        private static readonly DateTime NewYearDayDate = DateTime.ParseExact("01/01", "MM/dd", CultureInfo.InvariantCulture);
        private static readonly DateTime NewYearDayTwoDate = DateTime.ParseExact("01/02", "MM/dd", CultureInfo.InvariantCulture);
        private static readonly DateTime NewYearDayThreeDate = DateTime.ParseExact("01/03", "MM/dd", CultureInfo.InvariantCulture);
        private static readonly DateTime IrelandDayDate = DateTime.ParseExact("03/17", "MM/dd", CultureInfo.InvariantCulture);
        private static readonly DateTime EarthDayDate = DateTime.ParseExact("03/20", "MM/dd", CultureInfo.InvariantCulture);
        private static readonly DateTime WindDayDate = DateTime.ParseExact("06/15", "MM/dd", CultureInfo.InvariantCulture);
        private static readonly DateTime HalloweenDayDate = DateTime.ParseExact("10/31", "MM/dd", CultureInfo.InvariantCulture);
        private static readonly DateTime JustFunDayDate = DateTime.ParseExact("04/01", "MM/dd", CultureInfo.InvariantCulture);

        public static void CheckDates()
        {
            if (AppSettings.ApplicationSettings.DisableCelebrationChecking) return;

            if (FounderBirthDayDate == TodayDate)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                {
                    if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                    {
                        MainWindow.MainWindowInstance.MyBirthdayImage.Visibility = 0;
                    }
                }));
            }

            if (ProjectBirthDayDate == TodayDate)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                {
                    if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                    {
                        MainWindow.MainWindowInstance.BirthdayImage.Visibility = 0;
                    }
                }));
            }

            if (NewYearDayDate == TodayDate ||
                NewYearDayTwoDate == TodayDate ||
                NewYearDayThreeDate == TodayDate)
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

            if (IrelandDayDate == TodayDate)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                {
                    if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                    {
                        MainWindow.MainWindowInstance.IrelandImage.Visibility = 0;
                    }
                }));
            }

            if (EarthDayDate == TodayDate)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                {
                    if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                    {
                        MainWindow.MainWindowInstance.EarthImage.Visibility = 0;
                    }
                }));
            }

            if (WindDayDate == TodayDate)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                {
                    if (MainWindow.MainWindowInstance.NoConnectImage.Visibility != 0)
                    {
                        MainWindow.MainWindowInstance.WindDayImage.Visibility = 0;
                    }
                }));
            }

            if (HalloweenDayDate == TodayDate)
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

            if (JustFunDayDate == TodayDate)
            {
                if (!AppSettings.ApplicationSettings.DisableCelebrationFunnyDay)
                {
                    Random rnd = new Random();
                    int randomInt = rnd.Next(0, 4);

                    if (randomInt == 3)
                    {
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                        {
                            RotateTransform myRotateTransform = new RotateTransform { Angle = 180 };

                            TransformGroup myTransformGroup = new TransformGroup();
                            myTransformGroup.Children.Add(myRotateTransform);

                            MainWindow.MainWindowInstance.BaseGrid.RenderTransformOrigin = new Point(0.5, 0.5);
                            MainWindow.MainWindowInstance.BaseGrid.RenderTransform = myTransformGroup;
                        }));
                    }
                }
            } 

            if (!NetworkUtils.Connect()) return;
            
            Random random = new Random();
            int randomNumber = random.Next(0, 400);

            if (randomNumber != 168) return;

            int fontSize = Convert.ToInt32(GetDataFromGoogleDisk("https://drive.google.com/uc?export=download&id=1DzUjXAXsdXb--aAS-gmyCYQUrzEN3Dzx"));
            string labelContent = GetDataFromGoogleDisk("https://drive.google.com/uc?export=download&id=1T9VJX7Bu8Bo6JVs_GdHWV6gP8NDnYykX");

            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
            {
                if (MainWindow.MainWindowInstance.NoConnectImage.Visibility == 0) return;

                MainWindow.MainWindowInstance.SimpleLabel.FontSize = fontSize;
                MainWindow.MainWindowInstance.SimpleLabel.Content = labelContent;
                MainWindow.MainWindowInstance.SimpleLabel.Visibility = 0;
            }));
        }

        private static string GetDataFromGoogleDisk(string uri)
        {
            string data = new WebClient().DownloadStringTaskAsync(new Uri(uri)).Result;
            return data;
        }
    }
}
