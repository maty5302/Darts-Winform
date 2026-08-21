using System.Collections.Generic;
using Avalonia.Controls;
using DesktopUI.ViewModels;
using Domain.Models;

namespace DesktopUI.Views
{
    public partial class DuelSetupWindow : Window
    {
        public DuelSetupWindow(MainViewModel mainViewModel ,IEnumerable<PlayerDto> dbPlayers)
        {
            InitializeComponent();
            
            // Propojíme data: předáme jména ze Settings a definujeme, co se stane při kliknutí na Hra
            DataContext = new DuelSetupViewModel(dbPlayers, (config) => 
            {
                mainViewModel.StartDuel(config); // Spustí duel v hlavním okně
                this.Close(); // Zavře toto malé nastavovací okno
            });
        }
    }
}