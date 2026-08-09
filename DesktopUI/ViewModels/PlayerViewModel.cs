using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain;

namespace DesktopUI.ViewModels
{
    public partial class PlayerViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isActive;
        private int _legsWon = 0;
        private int _playerId;
        
        public Action<PlayerViewModel>? OnThrowSubmitted { get; set; }
        
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
            set 
            {
                if (SetProperty(ref _score, value))
                {
                    OnPropertyChanged(nameof(ScoreText)); 
                }
            }
        }
        
        public string ScoreText => $"{Score}";

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
            if (!int.TryParse(CurrentThrow, out int value))
            {
                CurrentThrow = "";
                return; 
            }

            if (value < 0 || value > 180)
            {
                CurrentThrow = "";
                return; 
            }

            var res = Score - value;

           
            if (res >= 0) 
            {
                Score -= value;
                CalcAverage();
                _ = SoundManagerDarts.SoundEffects.PlayScoreAsync(value);
                HistoryScore.AddHistory(_playerId, Score.ToString());
                Checkout = Domain.Checkout.checkout(Score); 
            }
            else
            {
                // Hráč přehodil (Bust). Skóre se neodečítá, ale tah mu končí.
                // Můžeš sem přidat např. logiku pro zobrazení "Bust!" na obrazovce.
            }
            CurrentThrow = "";
            OnThrowSubmitted?.Invoke(this);
        }

        private string _checkout;

        public string Checkout
        {
            get => _checkout;
            set => SetProperty(ref _checkout, value);
        }
    }
}