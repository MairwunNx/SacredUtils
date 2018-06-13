using SacredUtils.Resources.Core;

namespace SacredUtils.Resources.Windows
{
    public partial class LoadingWindow
    {
        public LoadingWindow()
        {
            InitializeComponent(); DataContext = new AppStrings();
        }
    }
}
