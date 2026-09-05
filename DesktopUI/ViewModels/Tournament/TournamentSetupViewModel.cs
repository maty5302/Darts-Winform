using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Interfaces;
using Domain.Models;

namespace DesktopUI.ViewModels.Tournament
{
    public partial class TournamentSetupViewModel : ViewModelBase
    {
        private readonly IDartsRepository _repo;

        public List<int> AllowedPlayerCounts { get; } = new() { 4, 8, 16 };

        [ObservableProperty] private int _playerCount = 4;
        [ObservableProperty] private ObservableCollection<PlayerDto> _availablePlayers = new();
        [ObservableProperty] private ObservableCollection<TournamentSlot> _slots = new();
        [ObservableProperty] private string _errorMessage = string.Empty;
        [ObservableProperty] private bool _hasError;

        public Action<List<PlayerDto>>? OnTournamentStart { get; set; }

        public TournamentSetupViewModel(IDartsRepository repo)
        {
            _repo = repo;
            _ = LoadPlayersAsync();
        }

        private async Task LoadPlayersAsync()
        {
            var players = await _repo.GetAllPlayersAsync();
            AvailablePlayers = new ObservableCollection<PlayerDto>(players);
            GenerateSlots();
        }

        partial void OnPlayerCountChanged(int value)
        {
            GenerateSlots();
        }

        private void GenerateSlots()
        {
            Slots.Clear();
            for (int i = 1; i <= PlayerCount; i++)
            {
                Slots.Add(new TournamentSlot
                {
                    Label = $"{Strings.TournamentPlayer} {i}:",
                    AvailablePlayers = this.AvailablePlayers
                });
            }
        }

        [RelayCommand]
        private void StartTournament()
        {
            var selectedPlayers = Slots
                .Select(s => s.SelectedPlayer)
                .OfType<PlayerDto>()
                .ToList();

            if (selectedPlayers.Count != PlayerCount || selectedPlayers.DistinctBy(p => p.Id).Count() != PlayerCount)
            {
                ErrorMessage = Strings.TournamentSetupErrorPlayers;
                HasError = true;
                return;
            }

            HasError = false;
            OnTournamentStart?.Invoke(selectedPlayers);
        }

        public partial class TournamentSlot : ObservableObject
        {
            [ObservableProperty] private string _label = "";
            [ObservableProperty] private PlayerDto? _selectedPlayer;
            public ObservableCollection<PlayerDto> AvailablePlayers { get; set; } = new();
        }
    }
}