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

    [ObservableProperty] private ObservableCollection<PlayerDto> _players = new();

    [ObservableProperty] private PlayerDto? _selectedPlayer;

    [ObservableProperty] private string _newPlayerName = string.Empty;

    [ObservableProperty] private string _renamePlayerName = string.Empty;

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
    [ObservableProperty] private ObservableCollection<int> _availableYears = new();

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
            _ = LoadPlayerProfileAsync(value.Id);
        }
    }

    private int? _selectedYear;
    public int? SelectedYear
    {
        get => _selectedYear;
        set
        {
            if (SetProperty(ref _selectedYear, value) && SelectedPlayer != null && value.HasValue && value.Value > 0)
            {
                _ = LoadStatsForSelectedYearAsync(SelectedPlayer.Id, value.Value);
            }
        }
    }
    
    private async Task LoadStatsForSelectedYearAsync(long playerId, int year)
    {
        var stats = await _repository.GetStatsForYearAsync(playerId, year);
        UpdateStatsUi(stats);
    }
    
    private async Task LoadPlayerProfileAsync(long playerId)
    {
        var years = await _repository.GetAvailableYearsAsync(playerId);
        AvailableYears.Clear();
        foreach (var year in years)
        {
            AvailableYears.Add(year);
        }

        int currentYear = DateTime.Now.Year;
        if (AvailableYears.Contains(currentYear))
        {
            SelectedYear = currentYear;
        }
        else if (AvailableYears.Count > 0)
        {
            SelectedYear = AvailableYears[0]; 
        }
        else
        {
            SelectedYear = null;
            UpdateStatsUi(null);
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
    
    private void UpdateStatsUi(PlayerStatsDto? stats)
    {
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
    }
}