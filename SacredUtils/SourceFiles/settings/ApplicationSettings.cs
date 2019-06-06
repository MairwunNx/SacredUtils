using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SacredUtils.SourceFiles.language;
using SacredUtils.SourceFiles.theme;

namespace SacredUtils.SourceFiles.settings
{
    [JsonObject(MemberSerialization.Fields)]
    public static class ApplicationSettings
    {
        public static bool AllowCustomScreenShotResolution { get; set; }
        public static int CustomScreenShotResolutionHeight { get; set; } = 1080;
        public static int CustomScreenShotResolutionWidth { get; set; } = 1920;
        public static bool AllowLicenseFileReCreate { get; set; } = true;
        public static bool AllowLoggingMethodNames { get; set; }
        public static bool EnableShowChangeLogAfterUpdate { get; set; } = true;
        public static bool EnableShowDebugInfo { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public static Theme ApplicationUiTheme { get; set; } = Theme.Light;

        [JsonConverter(typeof(StringEnumConverter))]
        public static Language ApplicationUiLanguage { get; set; } = Language.EnUs;

        public static bool EnableArchiveOldFileOnStartup { get; set; } = true;
        public static bool EnableAutoRegisterHotKeyForWinKey { get; set; } = true;
        public static bool EnableCheckReleaseUpdates { get; set; } = true;
        public static bool EnableCheckAlphaUpdates { get; set; }
        public static bool EnableApplicationLogging { get; set; } = true;
        public static bool EnableApplicationTabKeyButton { get; set; } = true;
        public static bool EnableApplicationTelemetry { get; set; } = true;
        public static bool EnableCachingGameComponents { get; set; } = true;
        public static bool EnableCelebrationChecking { get; set; } = true;
        public static bool EnableCelebrationFunnyDay { get; set; } = true;
        public static bool EnableCheckGlobLibrary { get; set; } = true;
        public static bool EnableCheckSacredVersion { get; set; } = true;
        public static bool EnableCheckInternetConnection { get; set; } = true;
        public static bool EnablePrintBaseInfoToLog { get; set; } = true;
        public static bool EnableReCreatingLanguageFiles { get; set; } = true;
        public static bool EnableReCreatingThemeFiles { get; set; } = true;
        public static bool EnableArchiveFileCompression { get; set; } = true;
        public static bool EnableGlobalExceptionCatching { get; set; } = true;
        public static bool EnableLoggingLoadedSettings { get; set; }
        public static bool ForceEnableFullScreenMode { get; set; } = true;
        public static bool HotKeyEventArgsGameHandled { get; set; } = true;
        public static int HotKeyRegisterGameDelay { get; set; } = 1000;
        public static string HWndSacredWindowClassId { get; set; } = "Sacred";

        public static string InternetConnectionPingProvider { get; set; } =
            "http://clients3.google.com/generate_204";

        [JsonConverter(typeof(StringEnumConverter))]
        public static Key KeyPushUserToMainMenu { get; set; } = Key.Escape;

        [JsonConverter(typeof(StringEnumConverter))]
        public static Key KeyReloadProgram { get; set; } = Key.F5;

        [JsonConverter(typeof(StringEnumConverter))]
        public static Key KeyShutdownProgram { get; set; } = Key.F6;

        [JsonConverter(typeof(StringEnumConverter))]
        public static Key KeyOpenGameSettingsFile { get; set; } = Key.F3;

        [JsonConverter(typeof(StringEnumConverter))]
        public static Key KeyOpenProgramDirectory { get; set; } = Key.F4;

        [JsonConverter(typeof(StringEnumConverter))]
        public static Key KeyOpenProgramLatestLogFile { get; set; } = Key.F1;

        [JsonConverter(typeof(StringEnumConverter))]
        public static Key KeyOpenProgramSettingFile { get; set; } = Key.F2;

        public static bool EnableAutoBackupAppAndGameConfigs { get; set; } = true;
        public static int MaxLoggerArchiveLogFiles { get; set; } = 10;
        public static int MaxApplicationBackupFiles { get; set; } = 10;
        public static int MaxSacredGameBackupFiles { get; set; } = 10;
        public static bool EnableRefreshSettingsOnWindowFocus { get; set; } = true;
        public static bool EnableRemoveApplicationTempContent { get; set; } = true;
        public static bool EnableRemoveBackupFilesOnOverflow { get; set; } = true;
        public static string SacredCheatsEnableArgument { get; set; } = "CHEATS=1";
        public static string SacredConfigurationFile { get; set; } = "Settings.cfg";
        public static string SacredExecutableFileName { get; set; } = "Sacred.exe";
        public static string SacredFontSizeArray { get; set; } = "10|10|12|15|12|12|8";
        public static int SacredStartArgs { get; set; } = 1;
        public static double ApplicationGuiScale { get; set; } = 1.0;

        [JsonConverter(typeof(StringEnumConverter))]
        public static Key KeyCreateGameScreenShot { get; set; } = Key.PrintScreen;

        public static bool ScreenShotRemoveTgaAndJpgFiles { get; set; } = true;
        public static string ScreenShotSaveDirectory { get; set; } = "Capture";
        public static string ScreenShotSaveFilePattern { get; set; } = "ddMMyyyy-hh-mm-ss-fff";
        public static string ScreenShotSaveFilePrefix { get; set; } = "screen-";
        public static int ShowUsedMemoryUpdateInterval { get; set; } = 2;
        public static bool UseAsyncCreatingScreenshots { get; set; }
        public static bool UseAsyncLoadFontCollection { get; set; }
        public static bool UseCustomFontSizeValue { get; set; }
        public static bool UseSimplifiedHotKeySettings { get; set; } = true;
        public static bool VisibleNoConnectionImage { get; set; } = true;

        public static bool CloseDonateDialogAfterSelect { get; set; } = true;
        public static bool ClosePageDialogAfterSelect { get; set; } = true;
        public static string DefaultOpenLogFileProgram { get; set; } = "Notepad";
        public static int DelayCheckingSacredProcess { get; set; } = 1;
        public static int DesiredFrameRateProperty { get; set; } = 60;

        public static void LoadSettings()
        {
        }

        public static void SaveSettings()
        {
        }
    }
}
