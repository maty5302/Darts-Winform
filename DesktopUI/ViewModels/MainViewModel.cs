using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace DesktopUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ObservableCollection<PlayerViewModel> Players { get; }
    
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
        Domain.AverageScore.ClearAverage();    
        for (int i = 0; i < PlayerCount; i++)
        {
            Players.Add(new PlayerViewModel
            {
                PlayerId = i,
                Name = $"Hráč {i+1}",
                Score = score, 
                Average = 0.00
            });
        }
    }
}