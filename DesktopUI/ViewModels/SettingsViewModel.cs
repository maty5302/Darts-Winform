using CommunityToolkit.Mvvm.Input;
using DesktopUI.Services;

namespace DesktopUI.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsManager Settings { get; }

        public SettingsViewModel(SettingsManager settingsManager)
        {
            Settings = settingsManager;
        }
    }
}