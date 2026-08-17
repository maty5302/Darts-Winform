using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DataLayer;
using DesktopUI.ViewModels;

namespace DesktopUI.Views
{
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();
            
            var repository = new DartsRepository(); 
            DataContext = new StatisticsViewModel(repository);
        }
    }
}