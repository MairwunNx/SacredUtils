using System.Windows.Forms;

namespace SacredUtils
{
    public static class ScreenResolution
    {
        // todo: fix not correct working on multiple screens.
        public static readonly int ScreenX = Screen.PrimaryScreen.Bounds.Width;
        public static readonly int ScreenY = Screen.PrimaryScreen.Bounds.Height;
    }
}
