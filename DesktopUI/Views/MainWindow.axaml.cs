using System;
using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using DesktopUI.Services;
using DesktopUI.ViewModels;

namespace DesktopUI.Views;

public partial class MainWindow : Window
{
    private MainViewModel? _boundViewModel;

    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnDataContextChanged(EventArgs e)
    {
        base.OnDataContextChanged(e);
    
        if (_boundViewModel != null)
        {
            _boundViewModel.Settings.PropertyChanged -= SettingsOnPropertyChanged;
        }
    
        _boundViewModel = DataContext as MainViewModel;
        if (_boundViewModel == null)
        {
            return;
        }
    
        _boundViewModel.Settings.PropertyChanged += SettingsOnPropertyChanged;
        
        ApplyWallpaper(_boundViewModel.Settings.MainBackgroundUri);
    }
    
    private void SettingsOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SettingsManager.MainBackgroundUri) && _boundViewModel != null)
        {
            ApplyWallpaper(_boundViewModel.Settings.MainBackgroundUri);
        }
    }

    private void ApplyWallpaper(string wallpaperUri)
    {
        var uri = Uri.TryCreate(wallpaperUri, UriKind.Absolute, out var parsedUri)
            ? parsedUri
            : new Uri("avares://DesktopUI/Assets/Backgrounds/darts-3-develop.jpg");

        if (!AssetLoader.Exists(uri))
        {
            uri = new Uri("avares://DesktopUI/Assets/Backgrounds/darts-3-develop.jpg");
        }

        using var stream = AssetLoader.Open(uri);
        var bitmap = new Bitmap(stream);
        Background = new ImageBrush(bitmap) { Stretch = Stretch.UniformToFill };
    }

    private void Button_OnClickAbout(object? sender, RoutedEventArgs e)
    {
        AboutApp app = new AboutApp
        {
            DataContext = new AboutAppViewModel() 
        };
        app.ShowDialog(this);
    }

    private void Button_OnClickDuel(object? sender, RoutedEventArgs e)
    {
        DuelSetupWindow setup = new DuelSetupWindow();
        setup.Width = 300;
        setup.Height = 600;
        setup.ShowDialog(this);
    }

    private void PlayMenuItem_OnClick(object? sender, RoutedEventArgs e)
    {
        _ = SoundManagerDarts.SoundEffects.PlayDartsSong();
    }

    private async void Button_OnClickSettings(object? sender, RoutedEventArgs e)
    {
       if (DataContext is not MainViewModel vm)
       {
            return;
       }
       var settingsVM = new SettingsViewModel(vm.Settings);

       SettingsWindow settingsWindow = new SettingsWindow(settingsVM);
    
       await settingsWindow.ShowDialog(this);
       vm.RefreshActivePlayers();
        
       if (settingsWindow.RequiresMainWindowReload)
       {
           var newWindow = new MainWindow
           {
               DataContext = vm,
               Width = Width,
               Height = Height
           };
        
           newWindow.Show();
           Close();
       }
    }

    private void Button_OnClickStatistics(object? sender, RoutedEventArgs e)
    {
        StatisticsWindow stats  = new StatisticsWindow();
        stats.ShowDialog(this);
    }

    private void Button_OnClickBack(object? sender, RoutedEventArgs e)
    {
        
    }

    private void Button_OnClickDartBoard(object? sender, RoutedEventArgs e)
    {
        DartboardWindow experiment = new DartboardWindow(_boundViewModel);
        experiment.Show();
    }
}