using SacredUtils.Resources.bin;

namespace SacredUtils.Resources.wnd
{
    public partial class LoadingWindow
    {
        public LoadingWindow()
        {
            DataContext = new BindingLanguageStrings();

            InitializeComponent();
        }
    }
}
