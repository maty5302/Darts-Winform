using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopUI.Services;
using Domain;
using Domain.Interfaces;
using Domain.Models;

namespace DesktopUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private int _playerCount = 10;
    [ObservableProperty] private int _score = 501;
    [ObservableProperty] private DuelViewModel _duelVM = new();
    [ObservableProperty] private bool _isDuelMode;
    
    public SettingsManager Settings { get; }
    
    private readonly IDartsRepository _repo;

    private int _currentPlayerIndex = 0;
    public ObservableCollection<PlayerViewModel> Players { get; } = new();

    public MainViewModel(IDartsRepository repo)
    {
        _repo = repo;
        Settings = new SettingsManager();
        _ = Settings.CheckForUpdatesAsync();
        ApplyTheme(Settings.ThemePreference);

        Settings.PropertyChanged += (s, e) => 
        {
            if (e.PropertyName == nameof(SettingsManager.ThemePreference))
                ApplyTheme(Settings.ThemePreference);
        };
    }

    private void ApplyTheme(string theme)
    {
        if (Application.Current != null)
        {
            Application.Current.RequestedThemeVariant = theme switch
            {
                "Light" => ThemeVariant.Light,
                "Dark" => ThemeVariant.Dark,
                _ => ThemeVariant.Default 
            };
        }
    }
    
    [RelayCommand]
    public void StartGame()
    {
        IsDuelMode = false;
        Players.Clear();
        foreach (var player in Players)
        {
            player.ResetPlacements();
        }
        AverageScore.ClearAverage();    
        
        for (int i = 0; i < PlayerCount; i++)
        {
            Players.Add(new PlayerViewModel
            {
                PlayerId = i,
                Name = GetPlayerName(i),              
                CardBackground = GetPlayerColor(i),   
                OpacityEnabled = Settings.OpacityEnabled,   
                OpacityValue = Settings.OpacityValue,       
                SoundEffectsEnabled = Settings.SoundEffectsEnabled, 
                
                Score = Score,
                Average = 0.00,
                OnThrowSubmitted = SwitchToNextPlayer,
                OnInputFocused = SetActivePlayer
            });
        }
        
        _currentPlayerIndex = 0;
        if (Players.Count > 0)
        {
            Players[_currentPlayerIndex].IsActive = true;
        }
        
        if (Settings.SoundEffectsEnabled)
            _ = SoundManagerDarts.SoundEffects.PlayGameOn();
    }
    
    private string GetPlayerName(int playerId)
    {
        if (playerId >= 0 && playerId < Settings.PlayerNames.Count && !string.IsNullOrWhiteSpace(Settings.PlayerNames[playerId]))
        {
            return Settings.PlayerNames[playerId];
        }
        return $"Hráč {playerId + 1}";
    }

    private string GetPlayerColor(int playerId)
    {
        if (playerId >= 0 && playerId < Settings.PlayerColors.Count && !string.IsNullOrWhiteSpace(Settings.PlayerColors[playerId]))
        {
            return Settings.PlayerColors[playerId];
        }
        return "#228B22";
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

        if (_currentPlayerIndex == selectedIndex && Players[selectedIndex].IsActive) return;

        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].IsActive = i == selectedIndex;
        }

        _currentPlayerIndex = selectedIndex;
    }

    public void RefreshActivePlayers()
    {
        foreach (var player in Players)
        {
            player.Name = GetPlayerName(player.PlayerId);
            player.CardBackground = GetPlayerColor(player.PlayerId);
        
            player.OpacityEnabled = Settings.OpacityEnabled;
            player.OpacityValue = Settings.OpacityValue;
            player.SoundEffectsEnabled = Settings.SoundEffectsEnabled;
        }
    }

    [RelayCommand]
    public void RedoLast()
    {
        if (_currentPlayerIndex >= 0 && _currentPlayerIndex < Players.Count)
        {
            var currentPlayer = Players[_currentPlayerIndex];
            if (currentPlayer.HasFinished) return;
            
            if(HistoryScore.IsEmpty(currentPlayer.PlayerId)) return;
            
            string? lastScore = HistoryScore.RedoLastScore(currentPlayer.PlayerId);
            if (lastScore != null && int.TryParse(lastScore, out int scoreValue))
            {
                currentPlayer.Score = scoreValue;
                currentPlayer.Average = AverageScore.GetAverageOfPlayer(currentPlayer.PlayerId);
                currentPlayer.Checkout = Checkout.checkout(currentPlayer.Score); 
            }
        }
    }
    
    public void StartDuel(DuelSetupViewModel config)
    {
        string team1Name;
        string team2Name;

        DuelVM.Is2V2Mode = config.Is2v2;

        if (config.Is2v2)
        {
            team1Name = $"{config.Player1?.PlayerName} & {config.Player2?.PlayerName}";
            team2Name = $"{config.Player3?.PlayerName} & {config.Player4?.PlayerName}";

            // Tým 1 IDs
            DuelVM.Player1.PlayerId = (int)(config.Player1?.Id ?? 0);
            DuelVM.Team1Player2Id = (int)(config.Player2?.Id ?? 0);
        
            // Tým 2 IDs
            DuelVM.Player2.PlayerId = (int)(config.Player3?.Id ?? 0);
            DuelVM.Team2Player2Id = (int)(config.Player4?.Id ?? 0);
        }
        else
        {
            team1Name = config.Player1?.PlayerName ?? "Hráč 1";
            team2Name = config.Player2?.PlayerName ?? "Hráč 2"; 

            DuelVM.Player1.PlayerId = (int)(config.Player1?.Id ?? 0);
            DuelVM.Player2.PlayerId = (int)(config.Player2?.Id ?? 0);
        }
        DuelVM.InitializeDuel(team1Name, team2Name, config.Score, config.Legs, config.IsSets, Settings.SoundEffectsEnabled);

        IsDuelMode = true;
    
        if (Settings.SoundEffectsEnabled)
        {
            _ = SoundManagerDarts.SoundEffects.PlayGameOn();
        }
    }
    
    public async Task<List<PlayerDto>> GetDatabasePlayersAsync()
    {
        return await _repo.GetAllPlayersAsync();
    }
}