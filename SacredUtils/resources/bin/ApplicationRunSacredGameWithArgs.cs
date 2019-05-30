using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SacredUtils.resources.bin
{
    public static class ApplicationRunSacredGameWithArgs
    {
        private static readonly string SacredFileName = AppSettings.ApplicationSettings.SacredExecutableFileName;
        private static readonly string SacredCheatArg = AppSettings.ApplicationSettings.SacredCheatsEnableArgument;

        public static void Run(string[] args)
        {
            if (args.Contains("-cheatsEnable"))
            {
                Process.Start(SacredFileName, SacredCheatArg);

                EnableSwitchingLanguage(args);
                EnableStretchingScreenshot(args);
                EnableEmulateHotKeys(args);
                EnableDisableWinKey(args);
            }
            else
            {
                Process.Start(SacredFileName);

                EnableSwitchingLanguage(args);
                EnableStretchingScreenshot(args);
                EnableEmulateHotKeys(args);
                EnableDisableWinKey(args);
            }
        }

        private static void EnableSwitchingLanguage(string[] args)
        {
            if (!args.Contains("-forceSwitchLanguage")) return;

            ForceSwitchKeyboardLanguageInGame.RegisterApplication();
        }

        private static void EnableStretchingScreenshot(string[] args)
        {
            if (!args.Contains("-fullScreenShot")) return;

            ForceStretchSacredGameScreenshot.RegisterKey(true);
        }

        private static void EnableEmulateHotKeys(string[] args)
        {
            if (!args.Contains("-emulateHotKeys")) return;

            ApplicationStartEmulateHotkeys.RegisterMainHotkeys();
        }

        private static void EnableDisableWinKey(string[] args)
        {
            if (!args.Contains("-disableWinKey")) return;

            ForceSacredGameDisableWinKey.RegisterKeys();
            ForceSacredGameDisableWinKey.Disable();
        }
    }
}
