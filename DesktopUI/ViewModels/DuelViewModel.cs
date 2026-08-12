using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DesktopUI.ViewModels
{
    public partial class DuelViewModel : ViewModelBase
    {
        // The two players bound to the UI
        [ObservableProperty]
        private PlayerViewModel _player1;

        [ObservableProperty]
        private PlayerViewModel _player2;

        // Track how many legs each player has won
        [ObservableProperty]
        private int _player1Legs;

        [ObservableProperty]
        private int _player2Legs;

        [ObservableProperty]
        private int _numberOfLegs;

        [ObservableProperty]
        private int _scoreToBeat;

        public DuelViewModel()
        {
            // Reset domain logic if needed for a fresh duel
            Domain.AverageScore.ClearAverage();
            PlayerViewModel.ResetPlacements();

            // Initialize Player 1
            Player1 = new PlayerViewModel
            {
                PlayerId = 0,
                Name = "Player 1", // You can pass actual names from a setup window later
                Score = 301,       // Standard starting score for the duel
                Average = 0.00,
                IsActive = true,   // Player 1 starts
                OnThrowSubmitted = SwitchTurn,
                OnInputFocused = SetActivePlayer
            };

            // Initialize Player 2
            Player2 = new PlayerViewModel
            {
                PlayerId = 1,
                Name = "Player 2",
                Score = 301,
                Average = 0.00,
                IsActive = false,
                OnThrowSubmitted = SwitchTurn,
                OnInputFocused = SetActivePlayer
            };

            Player1Legs = 0;
            Player2Legs = 0;
        }

        /// <summary>
        /// Automatically called by PlayerViewModel when a throw is submitted (Enter is pressed)
        /// </summary>
        private void SwitchTurn(PlayerViewModel throwingPlayer)
        {
            // If Player 1 just threw, switch to Player 2
            if (throwingPlayer == Player1)
            {
                Player1.IsActive = false;
                
                // Only switch if the other player hasn't already finished the game
                if (!Player2.HasFinished)
                {
                    Player2.IsActive = true;
                }
            }
            // If Player 2 just threw, switch to Player 1
            else if (throwingPlayer == Player2)
            {
                Player2.IsActive = false;
                
                if (!Player1.HasFinished)
                {
                    Player1.IsActive = true;
                }
            }
        }

        /// <summary>
        /// Called when the user manually clicks into one of the text boxes
        /// </summary>
        private void SetActivePlayer(PlayerViewModel focusedPlayer)
        {
            if (focusedPlayer.HasFinished) return;

            if (focusedPlayer == Player1)
            {
                Player1.IsActive = true;
                Player2.IsActive = false;
            }
            else if (focusedPlayer == Player2)
            {
                Player2.IsActive = true;
                Player1.IsActive = false;
            }
        }
        
        /// <summary>
        /// Optional: Command to reset the board for the next Leg
        /// </summary>
        [RelayCommand]
        public void NextLeg()
        {
            // Add win logic here (e.g., if Player1 won, Player1Legs++)
            
            PlayerViewModel.ResetPlacements();
            
            Player1.Score = 301;
            Player1.CurrentThrow = "";
            
            Player2.Score = 301;
            Player2.CurrentThrow = "";

            // Alternate who starts the next leg
            Player1.IsActive = !Player1.IsActive;
            Player2.IsActive = !Player1.IsActive;
        }
    }
}