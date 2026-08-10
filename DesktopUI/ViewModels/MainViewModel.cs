using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace DesktopUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ObservableCollection<PlayerViewModel> Players { get; }
    private int _currentPlayerIndex = 0;
    private int playerCount = 10;
    private int score = 501;
    public int PlayerCount
    {
        get => playerCount;
        set => SetProperty(ref playerCount, value);
    }

    public int Score
    {
        get => score;
        set => SetProperty(ref score, value);
    }
    
    public MainViewModel()
    {
        Players = new ObservableCollection<PlayerViewModel>();
    }
    
    [RelayCommand]
    public void StartGame()
    {
        Players.Clear();
        PlayerViewModel.ResetPlacements();
        Domain.AverageScore.ClearAverage();    
        for (int i = 0; i < PlayerCount; i++)
        {
            Players.Add(new PlayerViewModel
            {
                PlayerId = i,
                Name = $"Hráč {i + 1}",
                Score = score,
                Average = 0.00,
                OnThrowSubmitted = SwitchToNextPlayer,
                OnInputFocused = SetActivePlayer
            });
        }
        _currentPlayerIndex = 0;
        if (Players.Count > 0)
        {
            Players[_currentPlayerIndex].IsActive = true;
        }

        _ = SoundManagerDarts.SoundEffects.PlayGameOn();
    }
    
    private void SwitchToNextPlayer(PlayerViewModel throwingPlayer)
    {
        if (Players.Count == 0) return;

        int currentIndex = Players.IndexOf(throwingPlayer);
        
        if (currentIndex == -1) return;

        _currentPlayerIndex = currentIndex;
        throwingPlayer.IsActive = false;
        for (int step = 1; step <= Players.Count; step++)
        {
            int nextIndex = (currentIndex + step) % Players.Count;
            if (!Players[nextIndex].HasFinished)
            {
                SetActivePlayer(Players[nextIndex]);
                return;
            }
        }
    }

    private void SetActivePlayer(PlayerViewModel player)
    {
        int selectedIndex = Players.IndexOf(player);
        if (selectedIndex == -1 || player.HasFinished) return;

        if (_currentPlayerIndex == selectedIndex && Players[selectedIndex].IsActive)
        {
            return;
        }

        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].IsActive = i == selectedIndex;
        }

        _currentPlayerIndex = selectedIndex;
    }
}