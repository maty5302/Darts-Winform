using Avalonia.Controls;
using DesktopUI.ViewModels;
using System.Collections.Generic;
using Domain.Models;
using TournamentSetupViewModel = DesktopUI.ViewModels.Tournament.TournamentSetupViewModel;

namespace DesktopUI.Views
{
    public partial class TournamentSetupWindow : Window
    {
        public TournamentSetupWindow()
        {
            InitializeComponent();
        }

        public TournamentSetupWindow(TournamentSetupViewModel vm) : this()
        {
            DataContext = vm;
            
            vm.OnTournamentStart = (List<PlayerDto> selectedPlayers) =>
            {
                Close(selectedPlayers);
            };
        }
    }
}