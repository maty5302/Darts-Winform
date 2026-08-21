using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Domain.Models;

namespace DesktopUI.ViewModels
{
    public partial class DuelSetupViewModel : ViewModelBase
    {
        [ObservableProperty] private int _score = 301;
        [ObservableProperty] private int _legs = 1;

        private bool _is2v2;
        public bool Is2v2
        {
            get => _is2v2;
            set => SetProperty(ref _is2v2, value);
        }

        [ObservableProperty] private bool _isSets;

        // TADY: Seznam už nedrží stringy, ale přímo objekty hráčů z databáze
        public ObservableCollection<PlayerDto> AvailablePlayers { get; }

        // TADY: Vybraní hráči jsou také typu PlayerDto
        [ObservableProperty] private PlayerDto? _player1;
        [ObservableProperty] private PlayerDto? _player2;
        [ObservableProperty] private PlayerDto? _player3;
        [ObservableProperty] private PlayerDto? _player4;

        private readonly Action<DuelSetupViewModel>? _onStartGameRequested;

        // Konstruktor přijímá seznam hráčů z databáze
        public DuelSetupViewModel(IEnumerable<PlayerDto> players, Action<DuelSetupViewModel> onStartGameRequested)
        {
            _onStartGameRequested = onStartGameRequested;
            AvailablePlayers = new ObservableCollection<PlayerDto>(players);

            if (AvailablePlayers.Count >= 2)
            {
                Player1 = AvailablePlayers[0];
                Player2 = AvailablePlayers[1];
            }
        }

        [RelayCommand]
        public void StartGame()
        {
            if (Is2v2)
            {
                // Kontrola pro 4 hráče
                if (Player1 == null || Player2 == null || Player3 == null || Player4 == null) return;
            }
            else
            {
                // Kontrola pro 2 hráče
                if (Player1 == null || Player2 == null) return;
            }

            _onStartGameRequested?.Invoke(this);
        }
    }
}