using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Player
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string PlayerName { get; set; }
        
        public List<YearlyStatistic> Statistics { get; set; } = new();

        public Player()
        {
            PlayerName = string.Empty;
        }

        public Player(string playerName)
        {
            PlayerName = playerName;
        }
    }
}