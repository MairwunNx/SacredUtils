using Config.Net;

namespace SacredUtils
{
    public interface IAppSettings
    {
        [Option(Alias = "AcceptLicense", DefaultValue = "false")]
        bool AcceptLicense { get; set; }

        [Option(Alias = "AppUiLanguage", DefaultValue = "based on system")]
        string AppUiLanguage { get; set; }

        [Option(Alias = "ArchiveOldFileOnStartup", DefaultValue = "true")]
        bool ArchiveOldFileOnStartup { get; }

        [Option(Alias = "CheckAutoAlphaUpdate", DefaultValue = "false")]
        bool CheckAutoAlphaUpdate { get; set; }

        [Option(Alias = "CheckAutoUpdate", DefaultValue = "true")]
        bool CheckAutoUpdate { get; set; }

        [Option(Alias = "CloseDonateDialogAfterSelect", DefaultValue = "true")]
        bool CloseDonateDialogAfterSelect { get; }

        [Option(Alias = "ClosePageDialogAfterSelect", DefaultValue = "true")]
        bool ClosePageDialogAfterSelect { get; } 

        [Option(Alias = "ColorTheme", DefaultValue = "light")]
        string ColorTheme { get; set; }

        [Option(Alias = "DebugFileCreate", DefaultValue = "false")]
        bool DebugFileCreate { get; }

        [Option(Alias = "DelayCheckingSacredProcess", DefaultValue = "1")]
        int DelayCheckingSacredProcess { get; }

        [Option(Alias = "DesiredFrameRateProperty", DefaultValue = "60")]
        int DesiredFrameRateProperty { get; }

        [Option(Alias = "DisableCachingGameComponents", DefaultValue = "false")]
        bool DisableCachingGameComponents { get; }

        [Option(Alias = "DisableFootSteps", DefaultValue = "false")]
        bool DisableFootSteps { get; set; }

        [Option(Alias = "DisableLogging", DefaultValue = "false")]
        bool DisableLogging { get; }

        [Option(Alias = "DisableTelemetry", DefaultValue = "false")]
        bool DisableTelemetry { get; }

        [Option(Alias = "EnableArchiveFileCompression", DefaultValue = "true")]
        bool EnableArchiveFileCompression { get; }

        [Option(Alias = "EnableHealthCircles", DefaultValue = "true")]
        bool EnableHealthCircles { get; set; }

        [Option(Alias = "GameVoiceover", DefaultValue = "based on language")]
        string GameVoiceover { get; set; }

        [Option(Alias = "KeyGotoMainMenu", DefaultValue = "Escape")]
        string KeyGotoMainMenu { get; }

        [Option(Alias = "KeyOpenSacredUtilsDirectory", DefaultValue = "F3")]
        string KeyOpenSacredUtilsDirectory { get; }

        [Option(Alias = "KeyOpenSacredUtilsLogs", DefaultValue = "F1")]
        string KeyOpenSacredUtilsLogs { get; }

        [Option(Alias = "KeyOpenSacredUtilsSettings", DefaultValue = "F2")]
        string KeyOpenSacredUtilsSettings { get; }

        [Option(Alias = "KeyReloadFastSacredUtils", DefaultValue = "F6")]
        string KeyReloadFastSacredUtils { get; }

        [Option(Alias = "KeyReloadSacredUtils", DefaultValue = "F4")]
        string KeyReloadSacredUtils { get; }

        [Option(Alias = "KeyShutdownSacredUtils", DefaultValue = "F5")]
        string KeyShutdownSacredUtils { get; }

        [Option(Alias = "LicenseFileCreate", DefaultValue = "true")]
        bool LicenseFileCreate { get; }

        [Option(Alias = "LoggingMethodName", DefaultValue = "false")]
        bool LoggingMethodName { get; }

        [Option(Alias = "MakeAutoBackupConfigs", DefaultValue = "true")]
        bool MakeAutoBackupConfigs { get; set; }

        [Option(Alias = "MaxApplicationBackupFiles", DefaultValue = "10")]
        int MaxApplicationBackupFiles { get; }

        [Option(Alias = "MaxArchiveFiles", DefaultValue = "10")]
        int MaxArchiveFiles { get; }

        [Option(Alias = "MaxGameBackupFiles", DefaultValue = "10")]
        int MaxGameBackupFiles { get; }

        [Option(Alias = "RemoveTempContent", DefaultValue = "true")]
        bool RemoveTempContent { get; }

        [Option(Alias = "Sacred229PatchInstalled", DefaultValue = "false")]
        bool Sacred229PatchInstalled { get; set; }

        [Option(Alias = "SacredStartArgs", DefaultValue = 1)]
        int SacredStartArgs { get; set; }

        [Option(Alias = "SacredUtilsGuiScale", DefaultValue = "1.0")]
        double SacredUtilsGuiScale { get; set; }

        [Option(Alias = "ScreenShotRemoveTgaAndJpgFiles", DefaultValue = "true")]
        bool ScreenShotRemoveTgaAndJpgFiles { get; set; }

        [Option(Alias = "ScreenShotSaveDirectory", DefaultValue = "Capture")]
        string ScreenShotSaveDirectory { get; set; }

        [Option(Alias = "ScreenShotSaveFilePattern", DefaultValue = "ddMMyyyy-hh-mm-ss-fff")]
        string ScreenShotSaveFilePattern { get; set; }
        
        [Option(Alias = "ScreenShotSaveFilePrefix", DefaultValue = "screen-")]
        string ScreenShotSaveFilePrefix { get; set; }

        [Option(Alias = "ServerMultiCoreFixInstalled", DefaultValue = "false")]
        bool ServerMultiCoreFixInstalled { get; set; }

        [Option(Alias = "ShowChangeLog", DefaultValue = "true")]
        bool ShowChangeLog { get; }

        [Option(Alias = "ShowUsedMemory", DefaultValue = "false")]
        bool ShowUsedMemory { get; }

        [Option(Alias = "ShowUsedMemoryUpdateInterval", DefaultValue = "2")]
        int ShowUsedMemoryUpdateInterval { get; }

        [Option(Alias = "UseOldSacredTextures", DefaultValue = "false")]
        bool UseOldSacredTextures { get; set; }

        [Option(Alias = "UseStaticBog", DefaultValue = "false")]
        bool UseStaticBog { get; set; }

        [Option(Alias = "UseStaticLava", DefaultValue = "false")]
        bool UseStaticLava { get; set; }

        [Option(Alias = "UseStaticWater", DefaultValue = "false")]
        bool UseStaticWater { get; set; }

        [Option(Alias = "VeteranModUfoInstalled", DefaultValue = "false")]
        bool VeteranModUfoInstalled { get; set; }

        [Option(Alias = "WhatIsThisDoingHere", DefaultValue = "true")]
        bool WhatIsThisDoingHere { get; set; }
    }

    public static class AppSettings
    {
        public static readonly IAppSettings ApplicationSettings =
            new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();
    }
}