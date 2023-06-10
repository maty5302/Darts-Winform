using Domain;
using šipky_Forms.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace šipky_Forms
{
	public partial class StatisticsForm : Form
	{
		List<Player> playerss = new List<Player>();
		int index = -1;

		private void CheckAchievements(Player p)
		{
			if (p.firstWin == true)
				firstWin.Image = Properties.Resources.a_cup;
			else
				firstWin.Image = Properties.Resources.a_cup_no;

			if (p._20Wins == true)
				Wins20.Image = Properties.Resources.a_cup_20;
			else
				Wins20.Image = Properties.Resources.a_cup_20_no;

			if (p._100Wins == true)
				Wins100.Image = Properties.Resources.a_cup_100;
			else
				Wins100.Image = Properties.Resources.a_cup_100_no;

			if (p.first180 == true)
				First180.Image = Properties.Resources.a_180;
			else
				First180.Image = Properties.Resources.a_180_no;

			if (p.profesional == true)
				Profesional.Image = Properties.Resources.a_more100;
			else
				Profesional.Image = Properties.Resources.a_more100_no;
		}

		private void UpdateList()
		{
			cb_players.Items.Clear();
			for (int i = 0; i < playerss.Count; i++)
			{
				cb_players.Items.Add(playerss[i].Name);
			}
		}

		private bool CheckIfExists(string name)
		{
			for (int i = 0; i < playerss.Count; i++)
			{
				if (playerss[i].Name == name)
					return true;
			}
			return false;
		}

		public StatisticsForm(List<Player> players)
		{
			InitializeComponent();
			playerss = players;
			UpdateList();
			tabPage1.Text += " (" + DateTime.Now.Year + ")";
		}

		private void createplayer_Click(object sender, EventArgs e)
		{
			var db = new DbSipky.MyDatabase();
			if (tb_namenewplayer.Text != "" && !CheckIfExists(tb_namenewplayer.Text))
			{
				db.PlayerSettings.Add(new Player(tb_namenewplayer.Text));
				playerss.Add(new Player(tb_namenewplayer.Text));
				errorProvider2.Icon = Properties.Resources.success;
				errorProvider2.BlinkStyle = ErrorBlinkStyle.NeverBlink;
				errorProvider2.SetError(createplayer, "Vytvořen");
			}
			else
			{
				errorProvider1.SetError(createplayer, "Zadej platné jméno");
				return;
			}

			tb_namenewplayer.Text = "";
			rename_tb.Text = "";
			UpdateList();
			db.SaveChanges();
		}

		private void cb_players_SelectedIndexChanged(object sender, EventArgs e)
		{
			index = cb_players.SelectedIndex;
			if (index != -1)
			{
				Lname.Text = LabelName.Text = playerss[index].Name;
				LabelWins.Text = playerss[index].Wins.ToString();
				LabelAverage.Text = playerss[index].Average.ToString();
				highestOut.Text = playerss[index].highestOut.ToString();
				Label60.Text = playerss[index].sixty.ToString();
				Label100.Text = playerss[index].hundred.ToString();
				Label120.Text = playerss[index].hundred20.ToString();
				Label180.Text = playerss[index].hundred80.ToString();

				LoldWin.Text = playerss[index].AllWins.ToString();
				Loldhighestout.Text = playerss[index].OldhighestOut.ToString();
				L60.Text = playerss[index].Allsixty.ToString();
				L100.Text = playerss[index].Allhundred.ToString();
				L120.Text = playerss[index].Allhundred20.ToString();
				L180.Text = playerss[index].Allhundred80.ToString();


				rename_tb.Text = playerss[index].Name;
				CheckAchievements(playerss[index]);
			}
			else
			{
				LabelName.Text = "NaN";
				LabelWins.Text = "NaN";
				LabelAverage.Text = "NaN";
				Label60.Text = "NaN";
				Label100.Text = "NaN";
				Label120.Text = "NaN";
				Label180.Text = "NaN";
				firstWin.Image = Properties.Resources.a_cup_no;
				Wins20.Image = Properties.Resources.a_cup_20_no;
				Wins100.Image = Properties.Resources.a_cup_100_no;
				First180.Image = Properties.Resources.a_180_no;
				Profesional.Image = Properties.Resources.a_more100_no;
			}
		}

		private void DeletePlayer_Click(object sender, EventArgs e)
		{
			var db = new DbSipky.MyDatabase();
			int index = cb_players.SelectedIndex;
			if (index != -1)
			{
				db.PlayerSettings.Remove(playerss[index]);
				playerss.RemoveAt(index);
				cb_players.SelectedIndex = -1;
				rename_tb.Text = "";
				index = -1;
				UpdateList();
				db.SaveChanges();
			}
		}

		private void firstWin_MouseHover(object sender, EventArgs e)
		{
			toolTip1.Show("Sladké vítězství\nVyhraj svůj první duel.", firstWin);
		}

		private void Wins20_MouseHover(object sender, EventArgs e)
		{
			toolTip1.Show("Začátek kariéry\nVyhraj 20 duelů nad soupeři.", Wins20);
		}

		private void Wins100_MouseHover(object sender, EventArgs e)
		{
			toolTip1.Show("Budoucí profesionál?\nVyhraj 100 duelů nad soupeři.", Wins100);
		}

		private void First180_MouseHover(object sender, EventArgs e)
		{
			toolTip1.Show("Má první 180!\nTref svoji prvni 180.", First180);
		}

		private void Profesional_MouseHover(object sender, EventArgs e)
		{
			toolTip1.Show("Expert na šipky\nZavři leg s více jak 100.", Profesional);
		}

		private void b_rename_Click(object sender, EventArgs e)
		{
			if (rename_tb.Text == "")
				errorProvider1.SetError(b_rename, "Nelze mít prázdné jméno");
			else if (index != -1)
			{
				var db = new DbSipky.MyDatabase();
				playerss[index].Name = rename_tb.Text;
				rename_tb.Text = "";
				cb_players.Text = "";
				db.PlayerSettings.Update(playerss[index]);
				index = -1;
				errorProvider2.Icon = Properties.Resources.success;
				errorProvider2.BlinkStyle = ErrorBlinkStyle.NeverBlink;
				errorProvider2.SetError(b_rename, "Změna provedena");
				UpdateList();
				db.SaveChanges();
			}
			else
				errorProvider1.SetError(b_rename, "Nevybrán hráč");
		}

		private void rename_tb_Enter(object sender, EventArgs e)
		{
			errorProvider1.SetError(b_rename, null);
			errorProvider2.SetError(b_rename, null);
		}

		private void tb_namenewplayer_Enter(object sender, EventArgs e)
		{
			errorProvider1.SetError(createplayer, null);
			errorProvider2.SetError(createplayer, null);
		}

		private void T_KeyDown(object sender, KeyEventArgs e)
		{
			var t = sender as TextBox;
			if (e.KeyCode == Keys.Enter && t != null)
			{
				createplayer_Click(sender, e);
				e.Handled = e.SuppressKeyPress = true;
				t.Clear();
			}

		}

		private void importHráčůToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var db = new DbSipky.MyDatabase();
			openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			openFileDialog1.Filter = "Soubor databáze hráčů zpětná kompatibilita (*.xml)|*.xml";
			if (DialogResult.OK == openFileDialog1.ShowDialog())
			{
				string pathFile = openFileDialog1.FileName;
				try
				{
					List<Player> temp = new List<Player>();
					using (FileStream fs = File.Open(pathFile, FileMode.Open, FileAccess.Read))
					{
						XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Player>));
						temp = xmlSerializer.Deserialize(fs) as List<Player>;
					}
					if (temp != null)
					{
						Statistics.CheckDateStatistics(temp);
						UpdateList();
						for (int i = 0; i < temp.Count; i++)
						{
							if (CheckIfExists(temp[i].Name))
							{
								db.PlayerSettings.Update(temp[i]);
								int index = playerss.FindIndex(x => x.Name == temp[i].Name);
								playerss[index] = temp[i];
							}
							else
							{
								db.PlayerSettings.Add(temp[i]);
								playerss.Add(temp[i]);
							}
						}
						db.SaveChanges();
					}
				}
				catch (InvalidOperationException)
				{
					MessageBox.Show("Zvoleny soubor neobsahuje statistiku hráčů.", "Neplatný soubor", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
