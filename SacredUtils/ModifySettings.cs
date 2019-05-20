using Config.Net;

// ReSharper disable InconsistentNaming
namespace SacredUtils
{
    public interface IModifySettings
    {
        [Option(Alias = "EnableVisibilityHealthCircles", DefaultValue = "false")]
        bool EnableVisibilityHealthCircles { get; set; }

        [Option(Alias = "SacredRemovePlayerFootSteps", DefaultValue = "false")]
        bool SacredRemovePlayerFootSteps { get; set; }

        [Option(Alias = "SacredUnofficialPatchInstalled", DefaultValue = "false")]
        bool SacredUnofficialPatchInstalled { get; set; }

        [Option(Alias = "SacredVoiceoverLanguage", DefaultValue = "based on language")]
        string SacredVoiceoverLanguage { get; set; }

        [Option(Alias = "ServerMultiCoreFixInstalled", DefaultValue = "false")]
        bool ServerMultiCoreFixInstalled { get; set; }

        [Option(Alias = "UseSacredOldTextures", DefaultValue = "false")]
        bool UseSacredOldTextures { get; set; }

        [Option(Alias = "UseSacredStaticBogTexture", DefaultValue = "false")]
        bool UseSacredStaticBogTexture { get; set; }

        [Option(Alias = "UseSacredStaticLavaTexture", DefaultValue = "false")]
        bool UseSacredStaticLavaTexture { get; set; }

        [Option(Alias = "UseSacredStaticWaterTexture", DefaultValue = "false")]
        bool UseSacredStaticWaterTexture { get; set; }

        [Option(Alias = "VeteranModUfoInstalled", DefaultValue = "false")]
        bool VeteranModUfoInstalled { get; set; }
    }

    public static class ModifySettings
    {
        public static readonly IModifySettings ModificationSettings =
            new ConfigurationBuilder<IModifySettings>()
                .UseJsonFile("$SacredUtils\\conf\\mk.setg.json")
                .Build();
    }
}
