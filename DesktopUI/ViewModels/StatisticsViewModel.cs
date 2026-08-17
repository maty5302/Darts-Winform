using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Interfaces;
using Domain.Models;

namespace DesktopUI.ViewModels;

public partial class StatisticsViewModel : ObservableObject
{
    private readonly IDartsRepository _repository;

    [ObservableProperty]
    private ObservableCollection<PlayerDto> _players = new();

    [ObservableProperty]
    private PlayerDto? _selectedPlayer;

    [ObservableProperty]
    private string _newPlayerName = string.Empty;

    [ObservableProperty]
    private string _renamePlayerName = string.Empty;

    [ObservableProperty] private int _wins;
    [ObservableProperty] private double _average;
    [ObservableProperty] private int _highestOut;
    [ObservableProperty] private int _sixty;
    [ObservableProperty] private int _hundred;
    [ObservableProperty] private int _hundred20;
    [ObservableProperty] private int _hundred80;
    
    [ObservableProperty] private int _allWins;
    [ObservableProperty] private int _oldHighestOut;
    [ObservableProperty] private int _allSixty;
    [ObservableProperty] private int _allHundred;
    [ObservableProperty] private int _allHundred20;
    [ObservableProperty] private int _allHundred80;

    public StatisticsViewModel(IDartsRepository repository)
    {
        _repository = repository;
        _ = LoadDataAsync();
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        var list = await _repository.GetAllPlayersAsync();
        Players = new ObservableCollection<PlayerDto>(list);

        if (Players.Count > 0 && SelectedPlayer == null)
        {
            SelectedPlayer = Players[0];
        }
    }

    partial void OnSelectedPlayerChanged(PlayerDto? value)
    {
        if (value != null)
        {
            RenamePlayerName = value.PlayerName;
            _ = LoadPlayerStatsAsync(value.Id);
        }
    }

    private async Task LoadPlayerStatsAsync(long playerId)
    {
        int currentYear = DateTime.Now.Year;
        
        // Načtení dat pro aktuální rok
        var stats = await _repository.GetStatsForYearAsync(playerId, currentYear);
        if (stats != null)
        {
            Wins = stats.Wins;
            Average = stats.Average;
            HighestOut = stats.HighestOut;
            Sixty = stats.Sixty;
            Hundred = stats.Hundred;
            Hundred20 = stats.Hundred20;
            Hundred80 = stats.Hundred80;
        }
        else
        {
            Wins = 0; Average = 0; HighestOut = 0; Sixty = 0; Hundred = 0; Hundred20 = 0; Hundred80 = 0;
        }

        var allStats = await _repository.GetAllYearsStatsAsync(playerId);
        if (allStats != null)
        {
            AllWins = allStats.AllWins;
            OldHighestOut = allStats.OldHighestOut;
            AllSixty = allStats.AllSixty;
            AllHundred = allStats.AllHundred;
            AllHundred20 = allStats.AllHundred20;
            AllHundred80 = allStats.AllHundred80;
        }
    }

    [RelayCommand]
    private async Task CreatePlayerAsync()
    {
        if (string.IsNullOrWhiteSpace(NewPlayerName)) return;

        var created = await _repository.CreatePlayerAsync(NewPlayerName.Trim());
        if (created != null)
        {
            NewPlayerName = string.Empty;
            await LoadDataAsync();
            SelectedPlayer = Players.FirstOrDefault(p => p.Id == created.Id);
        }
    }

    [RelayCommand]
    private async Task DeletePlayerAsync()
    {
        if (SelectedPlayer == null) return;

        await _repository.DeletePlayerAsync(SelectedPlayer.Id);
        SelectedPlayer = null;
        await LoadDataAsync();
    }

    [RelayCommand]
    private async Task RenamePlayerAsync()
    {
        if (SelectedPlayer == null || string.IsNullOrWhiteSpace(RenamePlayerName)) return;

        await _repository.RenamePlayerAsync(SelectedPlayer.Id, RenamePlayerName.Trim());
        long currentId = SelectedPlayer.Id;
        await LoadDataAsync();
        SelectedPlayer = Players.FirstOrDefault(p => p.Id == currentId);
    }
}