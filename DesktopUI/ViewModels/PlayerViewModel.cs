using System;
using CommunityToolkit.Mvvm.Input;

namespace DesktopUI.ViewModels
{
    public partial class PlayerViewModel : ViewModelBase
    {
        private int _playerId;

        public int PlayerId
        {
            get => _playerId;
            set => SetProperty(ref _playerId, value);
        }
        
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value); // Předpokládá implementaci INotifyPropertyChanged
        }

        private int _score;
        public int Score
        {
            get => _score;
            set => SetProperty(ref _score, value);
        }

        private double _average;
        public double Average
        {
            get => _average;
            set
            {
                if (SetProperty(ref _average, value))
                {
                    OnPropertyChanged(nameof(AverageText)); 
                }
            }
        }
        
        public string AverageText => $"Ø {Average:F2}";

        private void CalcAverage()
        {
            Average = Domain.AverageScore.AddAverage(_playerId, int.Parse(CurrentThrow));
        }
        
        private string _currentThrow;

        public string CurrentThrow
        {
            get => _currentThrow;
            set => SetProperty(ref _currentThrow, value);
        }

        [RelayCommand]
        public void SubmitThrow()
        {
            if (int.TryParse(CurrentThrow, out int value))
            {
                if (value > 0 && (Score - value) >= 0 && value <= 180)
                {
                    Score -= value;
                    CalcAverage();
                }
            }
            
            CurrentThrow = "";
        }
    }
}