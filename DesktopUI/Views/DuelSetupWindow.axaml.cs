using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Controls;
using DesktopUI.ViewModels;

namespace DesktopUI.Views
{
    public partial class DuelSetupWindow : Window
    {
        public DuelSetupWindow()
        {
            InitializeComponent();
            DataContext = new DuelSetupViewModel();
        }
    }
}