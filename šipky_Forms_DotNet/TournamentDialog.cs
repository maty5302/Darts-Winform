using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace šipky_Forms
{
	public delegate void TournamentStart(List<Player> players);

	public partial class TournamentDialog : Form
	{
		private List<Player> playerList = new List<Player>();
		private List<Player> chosedPlayers = new List<Player>();
		private List<Label> labels = new List<Label>();
		private List<ComboBox> playerChoices = new List<ComboBox>();

		public event TournamentStart? OnTournamentStart;

		public TournamentDialog(List<Player> players)
		{
			InitializeComponent();
			playerList = players;
			numericUpDown1.Increment = numericUpDown1.Value;
			playerChoices.Add(cb_player1);
			playerChoices.Add(cb_player2);
			playerChoices.Add(cb_player3);
			playerChoices.Add(cb_player4);
			foreach (ComboBox x in playerChoices)
			{
				x.Items.Clear();
				for (int i = 0; i < playerList.Count; i++)
				{
					x.Items.Add(playerList[i].Name);
				}
			}
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			int value = (int)numericUpDown1.Value;
			numericUpDown1.Increment = numericUpDown1.Value;

			int x = playerChoices.Last().Location.X;
			int y = playerChoices.Last().Location.Y + playerChoices.Last().Height + 10;
			int labelx = 0;
			if (labels.Count > 0)
				labelx = labels.Last().Location.X;

			if (value == 16)
			{
				for (int i = 0; i < value - 8; i++)
				{
					Label l = new Label();
					l.Location = new Point(labelx, y);
					l.Text = "Hráč " + (i + 9) + ":";
					l.AutoSize = true;
					labels.Add(l);
					this.Controls.Add(l);

					ComboBox box = new ComboBox();
					box.Location = new Point(x, y);
					box.Size = cb_player4.Size;
					box.Items.Clear();
					box.Tag = i + 4;
					box.DropDownStyle = ComboBoxStyle.DropDownList;
					for (int j = 0; j < playerList.Count; j++)
					{
						box.Items.Add(playerList[j].Name);
					}
					playerChoices.Add(box);
					this.Controls.Add(box);
					y += box.Height + 10;
				}
				b_startTournament.Location = new Point(b_startTournament.Location.X, y);
				this.Height = y + b_startTournament.Height + 50;

			}
			else if (value == 8)
			{
				labelx = l_player4.Location.X;
				for (int i = 0; i < value - 4; i++)
				{
					Label l = new Label();
					l.Location = new Point(labelx, y);
					l.Text = "Hráč " + (i + 5) + ":";
					l.AutoSize = true;
					labels.Add(l);
					this.Controls.Add(l);

					ComboBox box = new ComboBox();
					box.Location = new Point(x, y);
					box.Size = cb_player4.Size;
					box.Items.Clear();
					box.Tag = i + 4;
					box.DropDownStyle = ComboBoxStyle.DropDownList;
					for (int j = 0; j < playerList.Count; j++)
					{
						box.Items.Add(playerList[j].Name);
					}
					playerChoices.Add(box);
					this.Controls.Add(box);
					y += box.Height + 10;
				}
				b_startTournament.Location = new Point(b_startTournament.Location.X, y);
				this.Height = y + b_startTournament.Height + 50;

			}
			else if (value == 4 && playerChoices.Count > 4)
			{
				for (int i = 4; i < playerChoices.Count; i++)
				{
					this.Controls.Remove(playerChoices[i]);
				}
				for (int i = 0; i < labels.Count; i++)
				{
					this.Controls.Remove(labels[i]);
				}
				labels.RemoveRange(4, labels.Count - 4);
				playerChoices.RemoveRange(4, playerChoices.Count - 4);
				b_startTournament.Location = new Point(b_startTournament.Location.X, cb_player4.Location.Y + cb_player4.Height + 10);
				this.Height = b_startTournament.Location.Y + b_startTournament.Height + 50;
			}
		}

		private void b_startTournament_Click(object sender, EventArgs e)
		{
			ResetError();
			chosedPlayers.Clear();
			for (int i = 0; i < playerChoices.Count; i++)
			{
				if (playerChoices[i].SelectedItem != null && playerChoices[i].SelectedIndex != -1)
				{
					if (chosedPlayers.Contains(playerList[playerChoices[i].SelectedIndex]))
					{
						errorProvider1.SetError(playerChoices[i], "Hráč se již účastní turnaje");
						return;
					}
					chosedPlayers.Add(playerList[playerChoices[i].SelectedIndex]);
				}
				else
				{
					errorProvider1.SetError(playerChoices[i], "Vyberte hráče");
					return;
				}
			}

			this.OnTournamentStart?.Invoke(chosedPlayers);
		}

		private void ResetError()
		{
			foreach (ComboBox x in playerChoices)
			{
				errorProvider1.SetError(x, null);
			}
		}

		private void TournamentDialog_Deactivate(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
