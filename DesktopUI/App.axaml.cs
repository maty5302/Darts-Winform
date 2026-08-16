using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DesktopUI.ViewModels;
using DesktopUI.Views;

namespace DesktopUI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainViewModel = new MainViewModel();
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel,
            };

            if (mainViewModel.Settings.PlayMusicOnStartup)
            {
                _ = SoundManagerDarts.SoundEffects.PlayDartsSong();
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
}