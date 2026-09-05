using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Domain;
using MsBox.Avalonia.Enums;

namespace DesktopUI.ViewModels
{
    public partial class UpdateViewModel : ViewModelBase
    {
        [ObservableProperty] private string _version = "x.x.x.x";
        [ObservableProperty] private string _changelog = "";
        
        [ObservableProperty] private bool _isDownloading;
        [ObservableProperty] private double _downloadPercentage;
        [ObservableProperty] private string _progressText = "";

        public Action? CloseAction { get; set; }

        private static readonly HttpClient _httpClient = new HttpClient();
        
        private CancellationTokenSource? _cancellationTokenSource;

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

        [RelayCommand]
        private async Task DownloadAsync()
        {
            IsDownloading = true;
            _cancellationTokenSource = new CancellationTokenSource();
            
            var progress = new Progress<(double Percentage, long BytesReceived, long TotalBytes)>(data =>
            {
                DownloadPercentage = data.Percentage;
                ProgressText = $"{data.BytesReceived / 1024 / 1024}MB / {data.TotalBytes / 1024 / 1024}MB";
            });
            
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    await DownloadWindowsInstaller(Path.GetTempPath() + "DartsCounter.msi", progress, _cancellationTokenSource.Token);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    await DownloadLinuxAppImage("DartsCounter.AppImage", progress, _cancellationTokenSource.Token);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    await DownloadMacOsInstaller(Path.GetTempPath() + "DartsCounter.dmg", progress, _cancellationTokenSource.Token);
                }
            }
            catch (OperationCanceledException)
            {
                
            }
            catch (HttpRequestException)
            {
                
            }
            finally
            {
                CloseAction?.Invoke();
            }
        }
        private async Task DownloadFileWithProgressAsync(string url, string destinationPath, IProgress<(double, long, long)> progress, CancellationToken cancellationToken)
        {
            using var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            response.EnsureSuccessStatusCode();

            var totalBytes = response.Content.Headers.ContentLength ?? 0L;

            await using var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);
            await using var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);

            var buffer = new byte[8192];
            var totalRead = 0L;
            var isMoreToRead = true;

            while (isMoreToRead)
            {
                var read = await contentStream.ReadAsync(buffer, cancellationToken);
                if (read == 0)
                {
                    isMoreToRead = false;
                }
                else
                {
                    await fileStream.WriteAsync(buffer.AsMemory(0, read), cancellationToken);
                    totalRead += read;

                    if (totalBytes > 0)
                    {
                        var percentage = Math.Round((double)totalRead / totalBytes * 100, 2);
                        progress?.Report((percentage, totalRead, totalBytes)); 
                    }
                }
            }
        }

        private async Task DownloadWindowsInstaller(string filePath, IProgress<(double, long, long)> progress, CancellationToken token)
        {
            try
            {
                await DownloadFileWithProgressAsync("https://github.com/maty5302/Darts-Winform/releases/latest/download/DartsCounter.msi", filePath, progress, token);
                
                var processInfo = new ProcessStartInfo()
                {
                    FileName = "msiexec.exe",
                    Arguments = $"/i \"{filePath}\"",
                    UseShellExecute = false,
                };
                Process.Start(processInfo);
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
               await MsBox.Avalonia.MessageBoxManager.GetMessageBoxStandard(
                    "Error",
                    ex.Message, ButtonEnum.Ok, Icon.Error).ShowAsync();
            }
        }

        private async Task DownloadLinuxAppImage(string filePath, IProgress<(double, long, long)> progress, CancellationToken token)
        {
            try
            {
                await DownloadFileWithProgressAsync("https://github.com/maty5302/Darts-Winform/releases/latest/download/DartsCounter.AppImage", filePath, progress, token);
                
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
                
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                await MsBox.Avalonia.MessageBoxManager.GetMessageBoxStandard(
                    "Error",
                    ex.Message, ButtonEnum.Ok, Icon.Error).ShowAsync();
            }
        }

        private async Task DownloadMacOsInstaller(string filePath, IProgress<(double, long, long)> progress, CancellationToken token)
        {
            try
            {
                await DownloadFileWithProgressAsync("https://github.com/maty5302/Darts-Winform/releases/latest/download/DartsCounter.dmg", filePath, progress, token);
                
                Process.Start(new ProcessStartInfo
                {
                    FileName = "open",
                    Arguments = $"\"{filePath}\"",
                    UseShellExecute = true
                });
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                await MsBox.Avalonia.MessageBoxManager.GetMessageBoxStandard(
                    "Error",
                    ex.Message, ButtonEnum.Ok, Icon.Error).ShowAsync();
            }
        }

        [RelayCommand]
        private void CancelDownload()
        {
            IsDownloading = false;
            
            _cancellationTokenSource?.Cancel();
            
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