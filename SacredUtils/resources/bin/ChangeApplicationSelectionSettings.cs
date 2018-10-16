using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
                AppLogger.Log.Info($"Selected SacredUtils settings category {panel.Name} by user");

                foreach (StackPanel sp in MainWindow.SettingsGrid.Children.OfType<StackPanel>())
                {
                    sp.SetResourceReference(Control.BackgroundProperty, "CategoryNotActiveColorBrush");
                }
                
                panel.SetResourceReference(Control.BackgroundProperty, "CategoryActiveColorBrush");

                if (panel.Name == "FontsPanel") { MainWindow.FontStgOne.ExampleTextBlock.Text = GetApplicationRandomSplashes.GetRandomSplash(); }
            }
        }

        public static void UnSelectSettings(UIElement element)
        {
            MainWindow.SettingsFrame.Content = element;

            foreach (StackPanel sp in MainWindow.SettingsGrid.Children.OfType<StackPanel>())
            {
                sp.SetResourceReference(Control.BackgroundProperty, "CategoryNotActiveColorBrush");
            }
        }
    }
}
