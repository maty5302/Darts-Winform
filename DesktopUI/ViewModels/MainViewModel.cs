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
using DesktopUI.Services;

namespace DesktopUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public SettingsManager Settings { get; }

    [ObservableProperty] private int _playerCount = 10;
    [ObservableProperty] private int _score = 501;
    [ObservableProperty] private DuelViewModel _duelVM = new();
    [ObservableProperty] private bool _isDuelMode;

    private int _currentPlayerIndex = 0;
    public ObservableCollection<PlayerViewModel> Players { get; } = new();

    public MainViewModel()
    {
        // 1. Inicializujeme správce nastavení (on si sám načte JSON)
        Settings = new SettingsManager();
        
        // 2. Aplikujeme téma rovnou při startu
        ApplyTheme(Settings.ThemePreference);

        // 3. Posloucháme změny (kdyby uživatel v nastavení změnil téma)
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
}