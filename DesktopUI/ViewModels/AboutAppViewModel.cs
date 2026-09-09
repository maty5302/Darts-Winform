using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Domain;
using System.Diagnostics;
using System.Net.Mime;
using System.Reflection;
using Avalonia;

namespace DesktopUI.ViewModels
{
    public partial class AboutAppViewModel  : ViewModelBase
    {
        [ObservableProperty] private string _releaseNotes = Strings.AppReleaseNotesLoad;
        
        [ObservableProperty]
        private string _appVersion = "";

        public AboutAppViewModel()
        {
            _ = LoadReleaseNotesAsync();
        }

        private async Task LoadReleaseNotesAsync()
        {
            try
            {
                Version? version = Assembly.GetEntryAssembly()?.GetName().Version;
                string versionText = version?.ToString() ?? "1.0.0.0";
                
                AppVersion = $"{Strings.AppVersion} {versionText}";
                ReleaseNotes = await GithubIntegration.GetReleaseNotes($"v{versionText}");
            }
            catch
            {
                ReleaseNotes = Strings.AppReleaseNotesErr;
            }
        }
    }
}