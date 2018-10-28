using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class ChangeApplicationSelectionSettings
    {
        static readonly MainWindow MainWindow = (MainWindow)Application.Current.MainWindow;

        public static void SelectSettings(UIElement element, object sender)
        {
            MainWindow.SettingsFrame.Content = element;

            if (sender.Equals(sender as StackPanel) && sender is StackPanel panel)
            {
                Log.Info($"Selected SacredUtils settings category {panel.Name} by user");

                foreach (StackPanel sp in MainWindow.SettingsGrid.Children.OfType<StackPanel>())
                {
                    sp.SetResourceReference(Control.BackgroundProperty, "CategoryNotActiveColorBrush");

                    foreach (Button bt in sp.Children.OfType<Button>())
                    {
                        bt.SetResourceReference(Control.ForegroundProperty, "CategoryForegroundColorBrush");
                    }

                    foreach (PackIcon pi in sp.Children.OfType<PackIcon>())
                    {
                        pi.SetResourceReference(Control.ForegroundProperty, "CategoryForegroundColorBrush");
                    }
                }
                
                panel.SetResourceReference(Control.BackgroundProperty, "CategoryActiveColorBrush");

                foreach (Button bt in panel.Children.OfType<Button>())
                {
                    bt.SetResourceReference(Control.ForegroundProperty, "CategoryForegroundActiveColorBrush");
                }

                if (panel.Name == "SettingsPanel")
                {
                    foreach (PackIcon pi in panel.Children.OfType<PackIcon>())
                    {
                        pi.SetResourceReference(Control.ForegroundProperty, "CategoryForegroundActiveColorBrush");
                    }
                }

                if (panel.Name == "FontsPanel") { MainWindow.FontStgOne.ExampleTextBlock.Text = GetApplicationRandomSplashes.GetRandomSplash(); }
            }
        }

        public static void UnSelectSettings(UIElement element)
        {
            MainWindow.SettingsFrame.Content = element;

            foreach (StackPanel sp in MainWindow.SettingsGrid.Children.OfType<StackPanel>())
            {
                sp.SetResourceReference(Control.BackgroundProperty, "CategoryNotActiveColorBrush");

                foreach (Button bt in sp.Children.OfType<Button>())
                {
                    bt.SetResourceReference(Control.ForegroundProperty, "CategoryForegroundColorBrush");
                }

                foreach (PackIcon pi in sp.Children.OfType<PackIcon>())
                {
                    pi.SetResourceReference(Control.ForegroundProperty, "CategoryForegroundColorBrush");
                }
            }
        }
    }
}
