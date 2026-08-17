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
        private int _playerId;
        private static int _nextPlacement = 1;
        private int? _placement;
        private bool isEnabled = true;
        [ObservableProperty]
        private bool _soundEffectsEnabled;
        
        private double _opacityValue = 0.7;
        
        public Action<PlayerViewModel>? OnThrowSubmitted { get; set; }
        public Action<PlayerViewModel>? OnInputFocused { get; set; }
        
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
                    OnPropertyChanged(nameof(DisplayText));
                    OnPropertyChanged(nameof(DisplayFontSize));
                }
            }
        }
        
        public string ScoreText => $"{Score}";
        
        public string DisplayText => _placement.HasValue ? $"{_placement.Value}. místo" : ScoreText;
        public double DisplayFontSize => _placement.HasValue ? 26 : 42;
        public bool HasFinished => _placement.HasValue;

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

        private string _cardBackground = "#228B22";
        public string CardBackground
        {
            get => _cardBackground;
            set => SetProperty(ref _cardBackground, value);
        }

        private void CalcAverage()
        {
            Average = Domain.AverageScore.AddAverage(_playerId, int.Parse(CurrentThrow));
        }
        
        private string _currentThrow = "";

        public string CurrentThrow
        {
            get => _currentThrow;
            set => SetProperty(ref _currentThrow, value);
        }

        [RelayCommand]
        public void SubmitThrow()
        {
            if (_placement.HasValue)
            {
                CurrentThrow = "";
                return;
            }

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

           
            if (res > 0) 
            {
                HistoryScore.AddHistory(_playerId, Score.ToString());
                Score -= value;
                CalcAverage();
                if (SoundEffectsEnabled)
                    _ = SoundManagerDarts.SoundEffects.PlayScoreAsync(value);
                Checkout = Domain.Checkout.checkout(Score); 
            }
            else if (res == 0)
            {
                HistoryScore.AddHistory(_playerId, Score.ToString());
                Score = 0;
                _placement = _nextPlacement++;
                IsEnabled = false;
                OnPropertyChanged(nameof(DisplayText));
                OnPropertyChanged(nameof(DisplayFontSize));
                OnPropertyChanged(nameof(IsEnabled));
                CalcAverage();
                if(SoundEffectsEnabled)
                    _ = SoundManagerDarts.SoundEffects.PlayWinnerSong();
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

        private string _checkout = "";

        public string Checkout
        {
            get => _checkout;
            set => SetProperty(ref _checkout, value);
        }

        public static void ResetPlacements()
        {
            _nextPlacement = 1;
        }
        
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }

        public void NotifyInputFocused()
        {
            if (!HasFinished)
            {
                OnInputFocused?.Invoke(this);
            }
        }
        
        private bool _opacityEnabled;

        public bool OpacityEnabled
        {
            get => _opacityEnabled;
            set
            {
                if (SetProperty(ref _opacityEnabled, value))
                {
                    OnPropertyChanged(nameof(OpacityPlayerCard));
                }
            }
        }
        
        public double OpacityValue
        {
            get => _opacityValue;
            set
            {
                if (SetProperty(ref _opacityValue, value))
                {
                    OnPropertyChanged(nameof(OpacityPlayerCard));
                }
            }
        }

        public double OpacityPlayerCard => OpacityEnabled ? OpacityValue : 1.0;
    }
}