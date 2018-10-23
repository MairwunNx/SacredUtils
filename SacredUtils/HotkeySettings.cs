using Config.Net;

namespace SacredUtils
{
    public interface IHotkeySettings
    {
        [Option(Alias = "A", DefaultValue = "A")]
        string KeyA { get; set; }

        [Option(Alias = "B", DefaultValue = "B")]
        string KeyB { get; set; }

        [Option(Alias = "C", DefaultValue = "C")]
        string KeyC { get; set; }

        [Option(Alias = "D", DefaultValue = "D")]
        string KeyD { get; set; }

        [Option(Alias = "E", DefaultValue = "E")]
        string KeyE { get; set; }

        [Option(Alias = "F", DefaultValue = "F")]
        string KeyF { get; set; }

        [Option(Alias = "F1", DefaultValue = "F1")]
        string KeyF1 { get; set; }

        [Option(Alias = "F10", DefaultValue = "F10")]
        string KeyF10 { get; set; }

        [Option(Alias = "F11", DefaultValue = "F11")]
        string KeyF11 { get; set; }

        [Option(Alias = "F12", DefaultValue = "F12")]
        string KeyF12 { get; set; }

        [Option(Alias = "F2", DefaultValue = "F2")]
        string KeyF2 { get; set; }

        [Option(Alias = "F3", DefaultValue = "F3")]
        string KeyF3 { get; set; }

        [Option(Alias = "F4", DefaultValue = "F4")]
        string KeyF4 { get; set; }

        [Option(Alias = "F5", DefaultValue = "F5")]
        string KeyF5 { get; set; }

        [Option(Alias = "F6", DefaultValue = "F6")]
        string KeyF6 { get; set; }

        [Option(Alias = "F7", DefaultValue = "F7")]
        string KeyF7 { get; set; }

        [Option(Alias = "F8", DefaultValue = "F8")]
        string KeyF8 { get; set; }

        [Option(Alias = "F9", DefaultValue = "F9")]
        string KeyF9 { get; set; }

        [Option(Alias = "G", DefaultValue = "G")]
        string KeyG { get; set; }

        [Option(Alias = "H", DefaultValue = "H")]
        string KeyH { get; set; }

        [Option(Alias = "I", DefaultValue = "I")]
        string KeyI { get; set; }

        [Option(Alias = "J", DefaultValue = "J")]
        string KeyJ { get; set; }

        [Option(Alias = "K", DefaultValue = "K")]
        string KeyK { get; set; }

        [Option(Alias = "L", DefaultValue = "L")]
        string KeyL { get; set; }

        [Option(Alias = "M", DefaultValue = "M")]
        string KeyM { get; set; }

        [Option(Alias = "N", DefaultValue = "N")]
        string KeyN { get; set; }

        [Option(Alias = "O", DefaultValue = "O")]
        string KeyO { get; set; }

        [Option(Alias = "P", DefaultValue = "P")]
        string KeyP { get; set; }

        [Option(Alias = "Q", DefaultValue = "Q")]
        string KeyQ { get; set; }

        [Option(Alias = "R", DefaultValue = "R")]
        string KeyR { get; set; }

        [Option(Alias = "S", DefaultValue = "S")]
        string KeyS { get; set; }

        [Option(Alias = "Space", DefaultValue = " ")]
        string KeySpace { get; set; }

        [Option(Alias = "T", DefaultValue = "T")]
        string KeyT { get; set; }

        [Option(Alias = "Tab", DefaultValue = "Tab")]
        string KeyTab { get; set; }

        [Option(Alias = "U", DefaultValue = "U")]
        string KeyU { get; set; }

        [Option(Alias = "V", DefaultValue = "V")]
        string KeyV { get; set; }

        [Option(Alias = "W", DefaultValue = "W")]
        string KeyW { get; set; }

        [Option(Alias = "X", DefaultValue = "X")]
        string KeyX { get; set; }

        [Option(Alias = "Y", DefaultValue = "Y")]
        string KeyY { get; set; }

        [Option(Alias = "Z", DefaultValue = "Z")]
        string KeyZ { get; set; }
    }

    public static class HotkeySettings
    {
        public static readonly IHotkeySettings GameHotkeySettings =
            new ConfigurationBuilder<IHotkeySettings>()
                .UseJsonFile("$SacredUtils\\conf\\hotkeys.json").Build();
    }
}
