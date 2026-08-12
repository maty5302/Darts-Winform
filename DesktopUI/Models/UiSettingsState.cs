using System.Collections.Generic;
using System.Globalization;

namespace DesktopUI.Models
{
    public sealed class UiSettingsState
    {
        public List<string>? PlayerNames { get; set; }
        public List<string>? PlayerColors { get; set; }
        public string? MainBackgroundUri { get; set; }
        public string? CurrentLanguageCode { get; set; }
        public string? ThemePreference { get; set; }
        public bool PlayMusicOnStartup { get; set; }
        public bool SoundEffects { get; set; }
        public bool Opacity { get; set; }
        public double OpacityValue { get; set; }
    }
    
    
}