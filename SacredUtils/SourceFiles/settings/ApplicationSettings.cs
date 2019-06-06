using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SacredUtils.SourceFiles.language;
using SacredUtils.SourceFiles.theme;

namespace SacredUtils.SourceFiles.settings
{
    public class ApplicationSettings
    {
        public bool AllowCustomScreenShotResolution { get; set; }
        public int CustomScreenShotResolutionHeight { get; set; } = 1080;
        public int CustomScreenShotResolutionWidth { get; set; } = 1920;
        public bool AllowLicenseFileReCreate { get; set; } = true;
        public bool AllowLoggingMethodNames { get; set; }
        public bool EnableShowChangeLogAfterUpdate { get; set; } = true;
        public bool EnableShowDebugInfo { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Theme ApplicationUiTheme { get; set; } = Theme.Light;

        [JsonConverter(typeof(StringEnumConverter))]
        public Language ApplicationUiLanguage { get; set; } = Language.EnUs;

        public bool EnableArchiveOldFileOnStartup { get; set; } = true;
        public bool EnableAutoRegisterHotKeyForWinKey { get; set; } = true;
        public bool EnableCheckReleaseUpdates { get; set; } = true;
        public bool EnableCheckAlphaUpdates { get; set; }
        public bool EnableApplicationLogging { get; set; } = true;
        public bool EnableApplicationTabKeyButton { get; set; } = true;
        public bool EnableApplicationTelemetry { get; set; } = true;
        public bool EnableCachingGameComponents { get; set; } = true;
        public bool EnableCelebrationChecking { get; set; } = true;
        public bool EnableCelebrationFunnyDay { get; set; } = true;
        public bool EnableCheckGlobLibrary { get; set; } = true;
        public bool EnableCheckSacredVersion { get; set; } = true;
        public bool EnableCheckInternetConnection { get; set; } = true;
        public bool EnablePrintBaseInfoToLog { get; set; } = true;
        public bool EnableReCreatingLanguageFiles { get; set; } = true;
        public bool EnableReCreatingThemeFiles { get; set; } = true;
        public bool EnableArchiveFileCompression { get; set; } = true;
        public bool EnableGlobalExceptionCatching { get; set; } = true;
        public bool EnableLoggingLoadedSettings { get; set; }
        public bool ForceEnableFullScreenMode { get; set; } = true;
        public bool HotKeyEventArgsGameHandled { get; set; } = true;
        public int HotKeyRegisterGameDelay { get; set; } = 1000;
        public string HWndSacredWindowClassId { get; set; } = "Sacred";

        public string InternetConnectionPingProvider { get; set; } =
            "http://clients3.google.com/generate_204";

        [JsonConverter(typeof(StringEnumConverter))]
        public Key KeyPushUserToMainMenu { get; set; } = Key.Escape;

        [JsonConverter(typeof(StringEnumConverter))]
        public Key KeyReloadProgram { get; set; } = Key.F5;

        [JsonConverter(typeof(StringEnumConverter))]
        public Key KeyShutdownProgram { get; set; } = Key.F6;

        [JsonConverter(typeof(StringEnumConverter))]
        public Key KeyOpenGameSettingsFile { get; set; } = Key.F3;

        [JsonConverter(typeof(StringEnumConverter))]
        public Key KeyOpenProgramDirectory { get; set; } = Key.F4;

        [JsonConverter(typeof(StringEnumConverter))]
        public Key KeyOpenProgramLatestLogFile { get; set; } = Key.F1;

        [JsonConverter(typeof(StringEnumConverter))]
        public Key KeyOpenProgramSettingFile { get; set; } = Key.F2;

        public bool EnableAutoBackupAppAndGameConfigs { get; set; } = true;
        public int MaxLoggerArchiveLogFiles { get; set; } = 10;
        public int MaxApplicationBackupFiles { get; set; } = 10;
        public int MaxSacredGameBackupFiles { get; set; } = 10;
        public bool EnableRefreshSettingsOnWindowFocus { get; set; } = true;
        public bool EnableRemoveApplicationTempContent { get; set; } = true;
        public bool EnableRemoveBackupFilesOnOverflow { get; set; } = true;
        public string SacredCheatsEnableArgument { get; set; } = "CHEATS=1";
        public string SacredConfigurationFile { get; set; } = "Settings.cfg";
        public string SacredExecutableFileName { get; set; } = "Sacred.exe";
        public string SacredFontSizeArray { get; set; } = "10|10|12|15|12|12|8";
        public int SacredStartArgs { get; set; } = 1;
        public double ApplicationGuiScale { get; set; } = 1.0;

        [JsonConverter(typeof(StringEnumConverter))]
        public Key KeyCreateGameScreenShot { get; set; } = Key.PrintScreen;

        public bool ScreenShotRemoveTgaAndJpgFiles { get; set; } = true;
        public string ScreenShotSaveDirectory { get; set; } = "Capture";
        public string ScreenShotSaveFilePattern { get; set; } = "ddMMyyyy-hh-mm-ss-fff";
        public string ScreenShotSaveFilePrefix { get; set; } = "screen-";
        public int ShowUsedMemoryUpdateInterval { get; set; } = 2;
        public bool UseAsyncCreatingScreenshots { get; set; }
        public bool UseAsyncLoadFontCollection { get; set; }
        public bool UseCustomFontSizeValue { get; set; }
        public bool UseSimplifiedHotKeySettings { get; set; } = true;
        public bool VisibleNoConnectionImage { get; set; } = true;

        public bool CloseDonateDialogAfterSelect { get; set; } = true;
        public bool ClosePageDialogAfterSelect { get; set; } = true;
        public string DefaultOpenLogFileProgram { get; set; } = "Notepad";
        public int DelayCheckingSacredProcess { get; set; } = 1;
        public int DesiredFrameRateProperty { get; set; } = 60;
    }
}
