using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tournament
{
	public class Match
	{
		public int player1Id { get; set; }
		public int player2Id { get; set; }
		public int winnerId { get; set; }
		public int round { get; set; }

		public Match(int player1Id, int player2Id, int round)
		{
			this.player1Id = player1Id;
			this.player2Id = player2Id;
			this.round = round;
		}
	}
}
