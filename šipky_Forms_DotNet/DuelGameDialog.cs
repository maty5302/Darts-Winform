using Domain;

namespace šipky_Forms
{
	public partial class DuelGameDialog : Form
	{
		List<Player> players = new List<Player>();
		public int score { get; private set; }
		public int legs { get; private set; }
		public int selectedPlayer1 { get; private set; }
		public int selectedPlayer2 { get; private set; }
		public int selectedPlayer3 { get; private set; }
		public int selectedPlayer4 { get; private set; }
		public bool clicked = false;
		public bool _2v2 = false;
		public bool sets = true;

		public DuelGameDialog(List<Player> players)
		{
			InitializeComponent();
			this.players = players;
			if (players.Count < 2)
			{
				MessageBox.Show("Vytvořte dostatek hráču pro hraní duelu!", "Nedostatek hráčů", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				this.Close();
			}

			for (int i = 0; i < players.Count; i++)
			{
				cbPlayer1.Items.Add(players[i].Name);
				cbPlayer2.Items.Add(players[i].Name);
				cbPlayer3.Items.Add(players[i].Name);
				cbPlayer4.Items.Add(players[i].Name);
			}
			panel1.BackColor = Color.FromArgb(200, Color.Wheat);
		}

		private void resetError()
		{
			errorProvider1.SetError(cbPlayer1, null);
			errorProvider1.SetError(cbPlayer2, null);
			errorProvider1.SetError(cbPlayer3, null);
			errorProvider1.SetError(cbPlayer4, null);
		}

		private void startGame_Click(object sender, EventArgs e)
		{
			score = (int)DuelScore.Value;
			legs = (int)numberofLegs.Value;
			selectedPlayer1 = cbPlayer1.SelectedIndex;
			selectedPlayer2 = cbPlayer2.SelectedIndex;
			selectedPlayer3 = cbPlayer3.SelectedIndex;
			selectedPlayer4 = cbPlayer4.SelectedIndex;

			resetError();

			if (selectedPlayer1 == -1)
				errorProvider1.SetError(cbPlayer1, "Vyber hráče!");
			else if (selectedPlayer2 == -1 || selectedPlayer1 == selectedPlayer2)
				errorProvider1.SetError(cbPlayer2, "Vyber hráče!");
			else if ((selectedPlayer3 == -1 && checkBox1.Checked) || (checkBox1.Checked && (selectedPlayer1 == selectedPlayer3 || selectedPlayer2 == selectedPlayer3)))
				errorProvider1.SetError(cbPlayer3, "Vyber hráče!");
			else if ((selectedPlayer4 == -1 && checkBox1.Checked) || (checkBox1.Checked && (selectedPlayer1 == selectedPlayer4 || selectedPlayer2 == selectedPlayer4 || selectedPlayer3 == selectedPlayer4)))
				errorProvider1.SetError(cbPlayer4, "Vyber hráče!");
			else
			{
				clicked = true;
				_2v2 = checkBox1.Checked;
				sets = ch_sets.Checked;
				this.Close();
				GC.Collect();
			}



		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (players.Count < 4 && checkBox1.Checked)
			{
				MessageBox.Show("Vytvořte dostatek hráču pro hraní 2 proti 2 duelu!", "Nedostatek hráčů", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				checkBox1.Checked = false;
			}
			else
			{
				if (checkBox1.Checked)
				{
					panel1.Location = new Point(58, 49);
					panel1.Height = 219;
					l_team1.Visible = true;
					l_team2.Visible = true;
					ch_sets.Enabled = false;
				}
				else
				{
					panel1.Location = new Point(58, 67);
					panel1.Height = 156;
					l_team1.Visible = false;
					l_team2.Visible = false;
					ch_sets.Enabled = true;
				}
			}
		}

		private void ch_sets_CheckedChanged(object sender, EventArgs e)
		{
			if (ch_sets.Checked)
			{
				checkBox1.Enabled = false;
				label3.Text = "Počet setů";
			}
			else
			{
				checkBox1.Enabled = true;
				label3.Text = "Počet legů";
			}

		}
	}
}
