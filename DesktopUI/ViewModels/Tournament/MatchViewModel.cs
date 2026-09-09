namespace DesktopUI.ViewModels.Tournament
{
    public class MatchViewModel
    {
        public string Player1Name { get; set; } = string.Empty;
        public string Player2Name { get; set; } = string.Empty;
        
        public bool IsPlayer1Winner { get; set; }
        public bool IsPlayer2Winner { get; set; }
        
        // Vlastnosti pro kreslení čar stromu
        public bool IsTopMatch { get; set; }
        public bool IsBottomMatch { get; set; }
        public bool IsFirstRound { get; set; }
        
        public bool IsFinalWinnerBox { get; set; }
        public bool HasNextRound { get; set; } = true;

        public string Player1FontWeight => IsPlayer1Winner ? "Bold" : "Normal";
        public string Player2FontWeight => IsPlayer2Winner ? "Bold" : "Normal";
        public string Player1Color => IsPlayer1Winner ? "#008000" : "Black"; 
        public string Player2Color => IsPlayer2Winner ? "#008000" : "Black";
    }
}