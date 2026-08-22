namespace Domain.Models
{
	public class Match
	{
		public int Player1Id { get; set; }
		public int Player2Id { get; set; }
		public int WinnerId { get; set; }
		public int Round { get; set; }

		public Match(int player1Id, int player2Id, int round)
		{
			this.Player1Id = player1Id;
			this.Player2Id = player2Id;
			this.Round = round;
		}
	}
}
