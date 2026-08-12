using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using DesktopUI.Models;
using DesktopUI.ViewModels;

namespace DesktopUI.Views;

public partial class DartboardWindow : Window
{
    private readonly int[] _boardNumbers = { 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5 };
    private readonly List<DartThrow> _currentThrows = new();
    private MainViewModel? _mainViewModel;
    private bool _isUpdatingUi = false; 

    public DartboardWindow(MainViewModel? mainViewModel = null)
    {
        InitializeComponent();
        _mainViewModel = mainViewModel;
        
        SubscribeToPlayerEvents();
        UpdateActivePlayerName();

        Closed += OnWindowClosed;
    }

    private void UpdateActivePlayerName()
    {
        if (_mainViewModel != null)
        {
            var activePlayer = _mainViewModel.Players.FirstOrDefault(p => p.IsActive);
            if (activePlayer != null)
            {
                ActivePlayerText.Text = $"Na řadě: {activePlayer.Name}";
            }
            else
            {
                ActivePlayerText.Text = "Na řadě: --";
            }
        }
    }

    // AI Generated logic - not my job
    private void OnDartboardPointerPressed(object sender, PointerPressedEventArgs e)
    {
        if (_currentThrows.Count >= 3) return;

        var image = sender as Image;
        if (image == null) return;

        var point = e.GetPosition(image);
        double cx = image.Bounds.Width / 2;
        double cy = image.Bounds.Height / 2;
        double dx = point.X - cx;
        double dy = point.Y - cy;

        double clickRadius = Math.Sqrt(dx * dx + dy * dy);
        double minDimension = Math.Min(image.Bounds.Width, image.Bounds.Height);
        double playableAreaRatio = 0.76;
        double maxPlayableRadius = (minDimension / 2) * playableAreaRatio;
        double relativeRadius = clickRadius / maxPlayableRadius;

        double angleRad = Math.Atan2(dy, dx);
        double angleDeg = angleRad * (180 / Math.PI) + 90;
        if (angleDeg < 0) angleDeg += 360;
        angleDeg += 9;
        if (angleDeg >= 360) angleDeg -= 360;

        int sectorIndex = (int)(angleDeg / 18);
        int baseScore = _boardNumbers[sectorIndex];

        // Určení základního skóre a násobiče z kliknutí
        int multiplier = 1;
        if (relativeRadius > 1.0)
        {
            baseScore = 0;
            multiplier = 0; // Mimo
        }
        else if (relativeRadius >= 0.953)
        {
            multiplier = 2; // Double
        }
        else if (relativeRadius >= 0.582 && relativeRadius <= 0.629)
        {
            multiplier = 3; // Treble
        }
        else if (relativeRadius <= 0.037)
        {
            baseScore = 25;
            multiplier = 2; // Bullseye (50)
        }
        else if (relativeRadius <= 0.093)
        {
            baseScore = 25;
            multiplier = 1; // Outer Bull (25)
        }

        var dart = new DartThrow { BaseScore = baseScore, Multiplier = multiplier };
        _currentThrows.Add(dart);

        UpdateUiForThrows();
    }

    private void UpdateUiForThrows()
    {
        _isUpdatingUi = true;

        ComboBox[] combos = { Dart1TypeCombo, Dart2TypeCombo, Dart3TypeCombo };
        TextBlock[] scoreTexts = { Dart1ScoreText, Dart2ScoreText, Dart3ScoreText };

        for (int i = 0; i < 3; i++)
        {
            if (i < _currentThrows.Count)
            {
                combos[i].IsEnabled = true;
                combos[i].SelectedIndex = _currentThrows[i].Multiplier; // 0=Mimo, 1=Single, 2=Double, 3=Treble
                scoreTexts[i].Text = _currentThrows[i].TotalScore.ToString();
            }
            else
            {
                combos[i].IsEnabled = false;
                combos[i].SelectedIndex = -1;
                scoreTexts[i].Text = "--";
            }
        }

        ScoreDisplay.Text = $"Naházeno: {_currentThrows.Sum(t => t.TotalScore)}";
        ConfirmButton.IsEnabled = _currentThrows.Count > 0;
        UpdateActivePlayerName();  
        _isUpdatingUi = false;
    }

    private void OnDartTypeChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_isUpdatingUi) return;

        var combo = sender as ComboBox;
        if (combo == null || combo.SelectedIndex < 0) return;

        int index = -1;
        if (combo == Dart1TypeCombo) index = 0;
        else if (combo == Dart2TypeCombo) index = 1;
        else if (combo == Dart3TypeCombo) index = 2;

        if (index >= 0 && index < _currentThrows.Count)
        {
            _currentThrows[index].Multiplier = combo.SelectedIndex;
            
            if (_currentThrows[index].BaseScore == 0 && combo.SelectedIndex > 0)
            {
                _currentThrows[index].BaseScore = 20;
            }

            UpdateUiForThrows(); 
        }
    }

    private void OnClearClicked(object sender, RoutedEventArgs e)
    {
        _currentThrows.Clear();
        UpdateUiForThrows();
    }

    private void OnConfirmClicked(object sender, RoutedEventArgs e)
    {
        int totalRoundScore = _currentThrows.Sum(t => t.TotalScore);
        
        if (_mainViewModel != null)
        {
            var activePlayer = _mainViewModel.Players.FirstOrDefault(p => p.IsActive);
            
            if (activePlayer != null)
            {
                activePlayer.CurrentThrow = totalRoundScore.ToString();
                activePlayer.SubmitThrow(); 
            }
        }
        
        OnClearClicked(sender, e);
        UpdateActivePlayerName();
    }
    
    private void SubscribeToPlayerEvents()
    {
        if (_mainViewModel == null) return;

        // Posloucháme změny v kolekci (přidání/odebrání hráčů při startu nové hry)
        _mainViewModel.Players.CollectionChanged += OnPlayersCollectionChanged;

        // Posloucháme změny vlastností u všech aktuálních hráčů
        foreach (var player in _mainViewModel.Players)
        {
            player.PropertyChanged += OnPlayerPropertyChanged;
        }
    }

    private void UnsubscribeFromPlayerEvents()
    {
        if (_mainViewModel == null) return;

        _mainViewModel.Players.CollectionChanged -= OnPlayersCollectionChanged;

        foreach (var player in _mainViewModel.Players)
        {
            player.PropertyChanged -= OnPlayerPropertyChanged;
        }
    }
    
    private void OnPlayersCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems != null)
        {
            foreach (PlayerViewModel p in e.OldItems)
                p.PropertyChanged -= OnPlayerPropertyChanged;
        }
        if (e.NewItems != null)
        {
            foreach (PlayerViewModel p in e.NewItems)
                p.PropertyChanged += OnPlayerPropertyChanged;
        }

        UpdateActivePlayerName();
    }

    private void OnPlayerPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        // Jakmile se u některého hráče změní IsActive nebo Name, přepsat jméno na terči
        if (e.PropertyName == nameof(PlayerViewModel.IsActive) || e.PropertyName == nameof(PlayerViewModel.Name))
        {
            UpdateActivePlayerName();
        }
    }
    
    private void OnWindowClosed(object? sender, EventArgs e)
    {
        UnsubscribeFromPlayerEvents();
        Closed -= OnWindowClosed;
    }
}