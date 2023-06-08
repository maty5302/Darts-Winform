using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tournament
{
	public class Tournament
	{
		public List<Match> matches { get; set; }
		public List<Player> players { get; set; }
		public List<List<Match>> allmatches { get; set; }
		private int round { get; set; }

		public Tournament(List<Player> players)
		{
			this.players = players;
			this.matches = new List<Match>();
			this.allmatches = new List<List<Match>>();
			this.generateMatches();
		}

		private void generateMatches()
		{
			int matchesPerRound = this.players.Count / 2;
			if (round == 0)
				round = 1;

			for (int i = 0; i < matchesPerRound; i++)
			{
				this.matches.Add(new Match(Convert.ToInt32(this.players[i].Id), Convert.ToInt32(this.players[this.players.Count - 1 - i].Id), round));
			}
			allmatches.Add(this.matches);
		}

		public Match? getNextMatch()
		{			
			return this.matches.Find(x => x.winnerId == 0);
		}
		//if all matches are played, generate next round (getNextMatch() returns null)
        public void generateNextRound()
		{
			List<Player> winners = new List<Player>();
			foreach (Match match in matches)
			{
				if (match.winnerId != 0)
				{
					winners.Add(this.players.Find(x => x.Id == match.winnerId));
				}
			}
			if (winners.Count == matches.Count && winners.Count>=2)
			{

				matches = new List<Match>();
				int matchesPerRound = winners.Count / 2;
				round++;

				//musi to byt winners po sobe
				for (int i = 0; i < matchesPerRound; i++)
				{
					matches.Add(new Match(Convert.ToInt32(winners[i*2].Id), Convert.ToInt32(winners[i*2+1].Id), round));
				}

				allmatches.Add(matches);

			}
			else
			{
				matches = new List<Match>();
				int matchesPerRound = winners.Count / 2;
				round++;
				allmatches.Add(matches);
			}
		}

	}
}
