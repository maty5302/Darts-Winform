using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopUI.Services;
using Domain;

namespace DesktopUI.ViewModels
{
    public partial class SettingsViewModel : ViewModelBase
    {
        public SettingsManager Settings { get; }

        public SettingsViewModel(SettingsManager settingsManager)
        {
            Settings = settingsManager;
        }
    }
}