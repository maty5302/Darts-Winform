using Domain;
using Domain.Tournament;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace šipky_Forms
{
	public partial class TournamentStats : Form
	{
		private int defaultNumberOfPlayers;
		private int numberOfPlayers;
		private List<Player> allPlayers = new List<Player>();
		private List<List<Match>> allMatches = new List<List<Match>>();

		public TournamentStats(List<Player> players, List<List<Match>> matches)
		{
			InitializeComponent();
			numberOfPlayers = players.Count;
			defaultNumberOfPlayers = players.Count;
			allPlayers = players;
			allMatches = matches;
			this.Paint += TournamentStats_Paint;
		}

		private void AdjustForm()
		{
			this.Width = this.Controls.Cast<Control>().Max(c => c.Right) + 25;
			this.Height = this.Controls.Cast<Control>().Max(c => c.Bottom) + 50;
		}

		private void TournamentStats_Paint(object sender, PaintEventArgs e)
		{
			CreateLines(e.Graphics);
			CreateTextBoxes(e.Graphics);
			AdjustForm();
		}

		private void CreateLines(Graphics e)
		{

			Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
			Graphics g = e;

			int x = 10;
			int y = 10;
			int nasobek = 1;
			int width = 80;
			int height = 10;
			int defaulty = y;

			while (numberOfPlayers > 0)
			{
				for (int i = 0; i < numberOfPlayers; i++)
				{
					if (i % 2 == 0 && i != numberOfPlayers - 1)
					{
						g.DrawLine(pen, x + width, y + 10, x + width + width / 2 + height, y + 10);
						g.DrawLine(pen, x + width + width / 2 + height, y + height, x + width + width / 2 + height, y + 15 * nasobek);
					}
					else if (i % 2 == 1)
					{
						g.DrawLine(pen, x + width, y + 12, x + width + width / 2 + height, y + 12);
						g.DrawLine(pen, x + width + width / 2 + height, y + height + 2, x + width + width / 2 + height, y - 12 * nasobek);
					}
					y += 25 * nasobek;
				}

				numberOfPlayers /= 2;
				x = x + width + 10;
				y = defaulty = defaulty + 12 * nasobek;
				nasobek *= 2;
			}

			numberOfPlayers = defaultNumberOfPlayers;
		}

		private void CreateTextBoxes(Graphics g)
		{
			int x = 10;
			int y = 10;
			int defaulty = y;
			int nasobek = 1;
			int width = 80;
			int height = 10;

			int round = 0;

			while (numberOfPlayers > 0)
			{
				int count = 0;
				List<Match> matches = new List<Match>();
				if (allMatches.Count > round)
					matches = allMatches[round];
				else
					matches = new List<Match>();
				for (int i = 0; i < numberOfPlayers; i++)
				{
					if (i % 2 == 0 && i != 0)
					{
						count++;
					}
					TextBox text1 = new TextBox();
					text1.Size = new Size(width, height);
					text1.Font = new Font("Segoe UI", 9);
					text1.TextAlign = HorizontalAlignment.Center;
					text1.Location = new Point(x, y);
					if (count < matches.Count || matches.Count != 0)
					{
						if (i % 2 == 0)
							text1.Text = allPlayers.Find(p => p.Id == matches[count].player1Id).Name;
						else
							text1.Text = allPlayers.Find(p => p.Id == matches[count].player2Id).Name;
					}
					else if (matches.Count == 0 && (round == allMatches.Count || numberOfPlayers == 1))
					{
						List<Match>? match;
						if (numberOfPlayers == 1)
							match = allMatches.FindLast(m => m.Count == 1);
						else
							match = allMatches.Last();

						if (match != null && match.Count != 0)
						{
							if (match[i].winnerId != 0)
								text1.Text = allPlayers.Find(p => p.Id == match[i].winnerId).Name;
						}
					}
					y += 25 * nasobek;
					text1.Visible = true;
					text1.Enabled = false;
					this.Controls.Add(text1);

				}
				round++;

				numberOfPlayers /= 2;
				x = x + width + 10;
				y = defaulty = defaulty + 12 * nasobek;

				nasobek *= 2;

			}

		}

	}

}
