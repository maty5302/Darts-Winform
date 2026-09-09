using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DesktopUI.ViewModels;

namespace DesktopUI.Views
{
    public partial class AboutApp : Window
    {
        public AboutApp()
        {
            InitializeComponent();
            DataContext = new AboutAppViewModel();
        }
    }
} 