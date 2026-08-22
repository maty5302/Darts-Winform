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

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(LegsOrSetsText))]
        private bool _isSets;


        public string LegsOrSetsText => IsSets ? Strings.DuelSetNumberOfSets : Strings.DuelSetNumberOfLegs;

        public ObservableCollection<PlayerDto> AvailablePlayers { get; }

        [ObservableProperty] private PlayerDto? _player1;
        [ObservableProperty] private PlayerDto? _player2;
        [ObservableProperty] private PlayerDto? _player3;
        [ObservableProperty] private PlayerDto? _player4;

        private readonly Action<DuelSetupViewModel>? _onStartGameRequested;

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
                if (Player1 == null || Player2 == null || Player3 == null || Player4 == null) return;
            }
            else
            {
                if (Player1 == null || Player2 == null) return;
            }

            _onStartGameRequested?.Invoke(this);
        }
    }
}