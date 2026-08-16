using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using DesktopUI.Models;
using Domain;

namespace DesktopUI.Services
{
    public partial class SettingsManager : ObservableObject
    {
        [ObservableProperty] private string _mainBackgroundUri = "avares://DesktopUI/Assets/Backgrounds/darts-3-develop.jpg";
        [ObservableProperty] private string _currentLanguageCode = "cs";
        [ObservableProperty] private bool _playMusicOnStartup;
        [ObservableProperty] private bool _soundEffectsEnabled;
        [ObservableProperty] private bool _opacityEnabled;
        [ObservableProperty] private string _themePreference = "System";
        [ObservableProperty] private double _opacityValue = 0.7;
        [ObservableProperty] private string _updateStatus = Strings.UpdateCheck;
        [ObservableProperty] private bool _isUpdateAvailable = false;

        // Seznamy hráčů je lepší držet jako ObservableCollection
        public ObservableCollection<string> PlayerNames { get; } = new();
        public ObservableCollection<string> PlayerColors { get; } = new();
        
        private const int MaxPlayers = 10;
        private const string DefaultPlayerColor = "#228B22";
        private static readonly string SettingsFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "DartsCounter",
            "desktopui-settings.json");

        public SettingsManager()
        {
            EnsurePlayerSettingsCapacity();
            LoadPersistedSettings();
            ApplyLanguage(CurrentLanguageCode);
        }

        private void LoadPersistedSettings()
        {
            if (!File.Exists(SettingsFilePath))
            {
                return;
            }

            try
            {
                var json = File.ReadAllText(SettingsFilePath);
                var state = JsonSerializer.Deserialize<UiSettingsState>(json);
                if (state == null)
                {
                    return;
                }

                ApplyLoadedState(state);
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"Failed to read settings: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"Failed to parse settings: {ex.Message}");
            }
        }
        
        private void ApplyLoadedState(UiSettingsState state)
        {
            EnsurePlayerSettingsCapacity();
            for (int i = 0; i < MaxPlayers; i++)
            {
                if (state.PlayerNames != null && i < state.PlayerNames.Count && !string.IsNullOrWhiteSpace(state.PlayerNames[i]))
                {
                    PlayerNames[i] = state.PlayerNames[i]!;
                }

                if (state.PlayerColors != null && i < state.PlayerColors.Count && !string.IsNullOrWhiteSpace(state.PlayerColors[i]))
                {
                    PlayerColors[i] = state.PlayerColors[i]!;
                }
            }

            if (!string.IsNullOrWhiteSpace(state.MainBackgroundUri))
            {
                MainBackgroundUri = state.MainBackgroundUri!;
            }

            PlayMusicOnStartup = state.PlayMusicOnStartup;
            ApplyLanguage(state.CurrentLanguageCode ?? "cs");
            ThemePreference = state.ThemePreference ?? "System";
            SoundEffectsEnabled = state.SoundEffects;  
            OpacityEnabled = state.Opacity;
            OpacityValue = state.OpacityValue;
        }
        
        private static string GetDefaultPlayerName(int playerNumber, string languageCode)
        {
            return languageCode == "en" ? $"Player {playerNumber}" : $"Hráč {playerNumber}";
        }
        
        private void EnsurePlayerSettingsCapacity()
        {
            while (PlayerNames.Count < MaxPlayers)
            {
                PlayerNames.Add(GetDefaultPlayerName(PlayerNames.Count + 1, CurrentLanguageCode));
            }

            while (PlayerColors.Count < MaxPlayers)
            {
                PlayerColors.Add(DefaultPlayerColor);
            }
        }
        partial void OnCurrentLanguageCodeChanged(string value)
        {
            ApplyLanguage(value);
        }

        private void ApplyLanguage(string languageCode)
        {
            var normalizedLanguageCode = string.Equals(languageCode, "en", StringComparison.OrdinalIgnoreCase) ? "en" : "cs";
            if (!string.Equals(CurrentLanguageCode, normalizedLanguageCode, StringComparison.Ordinal))
            {
                CurrentLanguageCode = normalizedLanguageCode;
                return;
            }

            var culture = new CultureInfo(CurrentLanguageCode);
            Strings.Culture = culture;
            CultureInfo.CurrentUICulture = culture;
            CultureInfo.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
        }
        
        public void SaveSettings()
        {
            var directory = Path.GetDirectoryName(SettingsFilePath);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var state = new UiSettingsState
            {
                PlayerNames = PlayerNames.ToList(),
                PlayerColors = PlayerColors.ToList(),
                MainBackgroundUri = MainBackgroundUri,
                CurrentLanguageCode = CurrentLanguageCode,
                PlayMusicOnStartup = PlayMusicOnStartup,
                ThemePreference = ThemePreference,
                SoundEffects = SoundEffectsEnabled,
                Opacity = OpacityEnabled,
                OpacityValue = OpacityValue
            };

            var json = JsonSerializer.Serialize(state, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SettingsFilePath, json);
        }
        
        public async Task CheckForUpdatesAsync()
        {
            try
            {
                var updateAvailable = await GithubIntegration.CheckForUpdates();
                if (updateAvailable)
                {
                    UpdateStatus = Strings.UpdateAvailable;
                    IsUpdateAvailable = true;
                }
                else
                {
                    UpdateStatus = Strings.UpdateUpToDate;
                    IsUpdateAvailable = false;
                }
            }
            catch
            {
                UpdateStatus = Strings.UpdateCheckFailed;
                IsUpdateAvailable = false;
            }
        }
    }
}