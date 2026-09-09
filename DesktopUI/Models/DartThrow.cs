namespace DesktopUI.Models
{
    public class DartThrow
    {
        public int BaseScore { get; set; } 
        public int Multiplier { get; set; } 

        public int TotalScore => BaseScore switch
        {
            25 when Multiplier == 2 => 50, 
            25 when Multiplier == 1 => 25,
            _ => BaseScore * Multiplier
        };

        public override string ToString() => TotalScore.ToString();
    }
}