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
            
            DataContext = new DuelSetupViewModel(dbPlayers, (config) => 
            {
                mainViewModel.StartDuel(config); 
                this.Close(); 
            });
        }
    }
}