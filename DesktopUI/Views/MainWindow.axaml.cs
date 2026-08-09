using Avalonia.Controls;
using Avalonia.Interactivity;

namespace DesktopUI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        AboutApp app  = new AboutApp();
        app.ShowDialog(this);
    }

    private void Button_OnClickDuel(object? sender, RoutedEventArgs e)
    {
        DuelSetupWindow setup = new DuelSetupWindow();
        setup.Width = 300;
        setup.Height = 600;
        setup.ShowDialog(this);
    }
}