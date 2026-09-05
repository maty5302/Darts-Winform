using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Domain;

namespace DesktopUI.ViewModels
{
    public partial class UpdateViewModel : ViewModelBase
    {
        [ObservableProperty] private string _version;
        [ObservableProperty] private string _changelog;
        
        [ObservableProperty] private bool _isDownloading;
        [ObservableProperty] private int _downloadPercentage;
        [ObservableProperty] private string _progressText;

        public Action? CloseAction { get; set; }

        private WebClient? _webClient;

        public UpdateViewModel()
        {
            _ = LoadChangelogAsync();
        }

        private async Task LoadChangelogAsync()
        {
            try 
            {
                Version = await GithubIntegration.GetGitVersion();
                Changelog = await GithubIntegration.GetReleaseNotes(Version);
            }
            catch (Exception)
            {
                Changelog = Strings.InternetNot;
            }
        }

        private void C_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadPercentage = e.ProgressPercentage;
            ProgressText = $"{e.BytesReceived / 1024 / 1024}MB / {e.TotalBytesToReceive / 1024 / 1024}MB";
        }

        [RelayCommand]
        private async Task DownloadAsync()
        {
            IsDownloading = true;
            
            _webClient = new WebClient();
            _webClient.DownloadProgressChanged += C_DownloadProgressChanged;
            
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    await DownloadWindowsInstaller(_webClient, "DartsCounter.msi");
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    await DownloadLinuxAppImage(_webClient, "DartsCounter.AppImage");
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    await DownloadMacOsInstaller(_webClient, "DartsCounter.dmg");
                }
            }
            catch (WebException)
            {
            }
            finally
            {
                CloseAction?.Invoke();
            }
        }

        private async Task DownloadWindowsInstaller(WebClient c, string filePath)
        {
            try
            {
                await c.DownloadFileTaskAsync("https://github.com/maty5302/Darts-Winform/releases/latest/download/DartsCounter.msi",filePath);
                var processInfo = new ProcessStartInfo()
                {
                    FileName = "msiexec.exe",
                    Arguments = $"/i \"{filePath}\"",
                    UseShellExecute = false,
                };
                Process.Start(processInfo);
            }
            catch (Exception) { }
        }

        private async Task DownloadLinuxAppImage(WebClient c, string filePath)
        {
            try
            {
                await c.DownloadFileTaskAsync("https://github.com/maty5302/Darts-Winform/releases/latest/download/DartsCounter.AppImage", filePath);
                
                Process.Start(new ProcessStartInfo
                {
                    FileName = "bash",
                    Arguments = $"-c \"chmod +x '{filePath}'\"",
                    UseShellExecute = false,
                    CreateNoWindow = true
                })?.WaitForExit();
                
                Process.Start(new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception) { }
        }

        private async Task DownloadMacOsInstaller(WebClient c, string filePath)
        {
            try
            {
                await c.DownloadFileTaskAsync("https://github.com/maty5302/Darts-Winform/releases/latest/download/DartsCounter.dmg", filePath);
                Process.Start(new ProcessStartInfo
                {
                    FileName = "open",
                    Arguments = $"\"{filePath}\"",
                    UseShellExecute = true
                });
            }
            catch (Exception) { }
        }

        [RelayCommand]
        private void CancelDownload()
        {
            IsDownloading = false;
            
            _webClient?.CancelAsync();
            _webClient?.Dispose();
            
            CloseAction?.Invoke();
        }

        [RelayCommand]
        private void ManualUpdate()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/maty5302/Darts-Winform/releases/latest",
                UseShellExecute = true
            };
            Process.Start(psi);
            CloseAction?.Invoke();
        }

        [RelayCommand]
        private void Close() => CloseAction?.Invoke();
    }
}