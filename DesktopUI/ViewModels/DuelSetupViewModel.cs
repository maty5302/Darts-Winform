using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace DesktopUI.ViewModels
{
    public partial class DuelSetupViewModel : ViewModelBase
    {
        [ObservableProperty]
        private int _score = 301;

        [ObservableProperty]
        private int _legs = 1;

        private bool _is2v2;
        public bool Is2v2
        {
            get => _is2v2;
            set => SetProperty(ref _is2v2, value);
        }

        [ObservableProperty]
        private bool _isSets;

        // Seznam hráčů pro ComboBoxy
        public ObservableCollection<string> AvailablePlayers { get; }

        // Vybraní hráči
        [ObservableProperty] private string? _player1;
        [ObservableProperty] private string? _player2;
        [ObservableProperty] private string? _player3;
        [ObservableProperty] private string? _player4;

        public DuelSetupViewModel()
        {
            // Příklad naplnění dat pro ComboBox
            AvailablePlayers = new ObservableCollection<string>
            {
                "Karel", "Petr", "Jana", "Lukáš", "Martin"
            };
        }

        [RelayCommand]
        public void StartGame()
        {
            // Zde bude logika pro spuštění duelu (např. předání dat do hlavního okna)
            // Zkontroluješ, jestli jsou vybraní hráči atd.
            
            if (Is2v2)
            {
                // Kontrola pro 4 hráče
            }
            else
            {
                // Kontrola pro 2 hráče
            }
        }
    }
}