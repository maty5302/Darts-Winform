using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using Avalonia;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopUI.Models;

namespace DesktopUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private const int MaxPlayers = 10;
    private const string DefaultPlayerColor = "#228B22";
    public ObservableCollection<PlayerViewModel> Players { get; }
    private int _currentPlayerIndex = 0;
    private int playerCount = 10;
    private int score = 501;
    private string _mainBackgroundUri = "avares://DesktopUI/Assets/Backgrounds/darts-3-develop.jpg";
    private string _currentLanguageCode = "cs";
    private bool _playMusicOnStartup;
    private bool _soundEffectsEnabled;
    private bool _opacityEnabled;
    private string _themePreference = "System";
    private double _opacityValue = 0.7;
    
    [ObservableProperty]
    private DuelViewModel _duelVM = new();

    [ObservableProperty]
    private bool _isDuelMode;
    
    private static readonly string SettingsFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "DartsCounter",
        "desktopui-settings.json");
    
    public List<string> PlayerNames { get; } = new();
    public List<string> PlayerColors { get; } = new();

    public string MainBackgroundUri
    {
        get => _mainBackgroundUri;
        set => SetProperty(ref _mainBackgroundUri, value);
    }

    public string CurrentLanguageCode
    {
        get => _currentLanguageCode;
        set => SetProperty(ref _currentLanguageCode, value);
    }

    public bool PlayMusicOnStartup
    {
        get => _playMusicOnStartup;
        set => SetProperty(ref _playMusicOnStartup, value);
    }
    public int PlayerCount
    {
        get => playerCount;
        set => SetProperty(ref playerCount, value);
    }

    public int Score
    {
        get => score;
        set => SetProperty(ref score, value);
    }
    
    public bool OpacityEnabled
    {
        get => _opacityEnabled;
        set 
        {
            if (SetProperty(ref _opacityEnabled, value))
            {
                foreach (var player in Players)
                {
                    player.OpacityEnabled = value;
                }
            }
        }
    }
    
    public bool SoundEffectsEnabled
    {
        get => _soundEffectsEnabled;
        set 
        {
            if (SetProperty(ref _soundEffectsEnabled, value))
            {
                foreach (var player in Players)
                {
                    player.SoundEffectsEnabled = value;
                }
            }
        }
    }
    
    public string ThemePreference
    {
        get => _themePreference;
        set
        {
            if (SetProperty(ref _themePreference, value))
            {
                ApplyTheme(value);
            }
        }
    }
    
    private void ApplyTheme(string theme)
    {
        if (Application.Current != null)
        {
            Application.Current.RequestedThemeVariant = theme switch
            {
                "Light" => ThemeVariant.Light,
                "Dark" => ThemeVariant.Dark,
                _ => ThemeVariant.Default // "System" nebo cokoliv jiného
            };
        }
    }
   
    public double OpacityValue
    {
        get => _opacityValue;
        set
        {
            if (SetProperty(ref _opacityValue, value))
            {
                foreach (var player in Players)
                {
                    player.OpacityValue = value;
                }
            }
        }
    }

    public MainViewModel()
    {
        Players = new ObservableCollection<PlayerViewModel>();
        InitializeDefaults();
        LoadPersistedSettings();
    }
    
    [RelayCommand]
    public void StartGame()
    {
        //IsDuelMode = true;
        
        Players.Clear();
        PlayerViewModel.ResetPlacements();
        Domain.AverageScore.ClearAverage();    
        for (int i = 0; i < PlayerCount; i++)
        {
            Players.Add(new PlayerViewModel
            {
                PlayerId = i,
                Name = GetPlayerName(i),
                CardBackground = GetPlayerColor(i),
                Score = score,
                Average = 0.00,
                OnThrowSubmitted = SwitchToNextPlayer,
                OnInputFocused = SetActivePlayer,
                OpacityEnabled = this.OpacityEnabled
            });
        }
        _currentPlayerIndex = 0;
        if (Players.Count > 0)
        {
            Players[_currentPlayerIndex].IsActive = true;
        }
        
        if(SoundEffectsEnabled)
            _ = SoundManagerDarts.SoundEffects.PlayGameOn();
    }
    
    private void SwitchToNextPlayer(PlayerViewModel throwingPlayer)
    {
        if (Players.Count == 0) return;

        int currentIndex = Players.IndexOf(throwingPlayer);
        
        if (currentIndex == -1) return;

        _currentPlayerIndex = currentIndex;
        throwingPlayer.IsActive = false;
        for (int step = 1; step <= Players.Count; step++)
        {
            int nextIndex = (currentIndex + step) % Players.Count;
            if (!Players[nextIndex].HasFinished)
            {
                SetActivePlayer(Players[nextIndex]);
                return;
            }
        }
    }

    private void SetActivePlayer(PlayerViewModel player)
    {
        int selectedIndex = Players.IndexOf(player);
        if (selectedIndex == -1 || player.HasFinished) return;

        if (_currentPlayerIndex == selectedIndex && Players[selectedIndex].IsActive)
        {
            return;
        }

        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].IsActive = i == selectedIndex;
        }

        _currentPlayerIndex = selectedIndex;
    }

    public void ApplySettings(IReadOnlyList<string> playerNames, IReadOnlyList<string> playerColors, string languageCode, string wallpaperUri, string themePreference ,  bool playMusicOnStartup, bool soundEffectsEnabled, bool opacityEnabled , double opacityValue)
    {
        EnsurePlayerSettingsCapacity();
        for (int i = 0; i < MaxPlayers; i++)
        {
            if (i < playerNames.Count)
            {
                PlayerNames[i] = string.IsNullOrWhiteSpace(playerNames[i]) ? GetDefaultPlayerName(i + 1, languageCode) : playerNames[i].Trim();
            }

            if (i < playerColors.Count)
            {
                PlayerColors[i] = string.IsNullOrWhiteSpace(playerColors[i]) ? DefaultPlayerColor : playerColors[i];
            }
        }

        MainBackgroundUri = wallpaperUri;
        PlayMusicOnStartup = playMusicOnStartup;
        ThemePreference = themePreference;
        SoundEffectsEnabled = soundEffectsEnabled;
        OpacityEnabled = opacityEnabled;
        OpacityValue = opacityValue;
        SetLanguage(languageCode);
        SaveSettings();

        foreach (var player in Players)
        {
            player.Name = GetPlayerName(player.PlayerId);
            player.CardBackground = GetPlayerColor(player.PlayerId);
        }
    }

    private void InitializeDefaults()
    {
        for (int i = 1; i <= MaxPlayers; i++)
        {
            PlayerNames.Add(GetDefaultPlayerName(i, CurrentLanguageCode));
            PlayerColors.Add(DefaultPlayerColor);
        }

        SetLanguage(CurrentLanguageCode);
    }

    private string GetPlayerName(int playerId)
    {
        if (playerId >= 0 && playerId < PlayerNames.Count && !string.IsNullOrWhiteSpace(PlayerNames[playerId]))
        {
            return PlayerNames[playerId];
        }

        return GetDefaultPlayerName(playerId + 1, CurrentLanguageCode);
    }

    private string GetPlayerColor(int playerId)
    {
        if (playerId >= 0 && playerId < PlayerColors.Count && !string.IsNullOrWhiteSpace(PlayerColors[playerId]))
        {
            return PlayerColors[playerId];
        }

        return DefaultPlayerColor;
    }

    private static string GetDefaultPlayerName(int playerNumber, string languageCode)
    {
        return languageCode == "en" ? $"Player {playerNumber}" : $"Hráč {playerNumber}";
    }

    private void SetLanguage(string languageCode)
    {
        CurrentLanguageCode = languageCode == "en" ? "en" : "cs";
        var culture = new CultureInfo(CurrentLanguageCode);
        Strings.Culture = culture;
        CultureInfo.CurrentUICulture = culture;
        CultureInfo.CurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;
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
        SetLanguage(state.CurrentLanguageCode ?? "cs");
        ThemePreference = state.ThemePreference ?? "System";
        SoundEffectsEnabled = state.SoundEffects;  
        OpacityEnabled = state.Opacity;
        OpacityValue = state.OpacityValue;
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

    private void SaveSettings()
    {
        var directory = Path.GetDirectoryName(SettingsFilePath);
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var state = new UiSettingsState
        {
            PlayerNames = PlayerNames,
            PlayerColors = PlayerColors,
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
}