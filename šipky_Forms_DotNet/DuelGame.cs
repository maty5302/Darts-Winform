using Domain;
using šipky_Forms.Database;
using šipky_Forms_DotNet;
using System.Threading;

namespace šipky_Forms
{
    public delegate void GetWinner(int id_winner);

    public partial class DuelGame : UserControl
    {
        private int count = 0;
        private bool change = false;
        private bool _2v2 = false;
        private bool sets = false;
        private int numberOfLegs = 1;
        private int numberOfSets = 1;
        private bool muteSounds = false;
        private int scoreDuel = 501;
        private bool isZero = true;
        private Player[] playersDuel = new Player[2];
        private Player[] playersDuel2 = new Player[2];

        public int WinnerId = 0;   

        public event GetWinner Winner;

        public void GetControlsEnabled()
        {
            thrownPlayer1.Enabled = true;
            thrownPlayer2.Enabled = true;
        }

        private bool GetCurrentMute()
        {
            MainWindow form = (MainWindow)MainWindow.ActiveForm;
            if (form != null)
                return form.mute;
            else
                return false;
        }

        private void ClearFont()
        {
            PlayerOne.Font = new Font(PlayerOne.Font, FontStyle.Regular);
            PlayerTwo.Font = new Font(PlayerTwo.Font, FontStyle.Regular);
            PlayerThree.Font = new Font(PlayerThree.Font, FontStyle.Regular);
            PlayerFour.Font = new Font(PlayerFour.Font, FontStyle.Regular);
        }

        private void ChangeFocus(int index)
        {
            if (index == 10 && change && _2v2)
                PlayerThree.Font = new Font(PlayerThree.Font, FontStyle.Bold);
            else if (index == 11 && change && _2v2)
                PlayerFour.Font = new Font(PlayerFour.Font, FontStyle.Bold);
            else if (index == 10)
                PlayerOne.Font = new Font(PlayerOne.Font, FontStyle.Bold);
            else
                PlayerTwo.Font = new Font(PlayerTwo.Font, FontStyle.Bold);

            ChangePointer(index);
        }

        private void ChangePointer(int index)
        {
            pointer.Visible = true;

            if (index == 10)
                pointer.Top = 61;
            else
                pointer.Top = 137;
        }

        private void T_Enter(object sender, EventArgs e)
        {
            var b = (TextBox)sender;
            var index = 9 + Convert.ToInt32(b.Tag);
            MainWindow form = (MainWindow)MainWindow.ActiveForm;
            form.setPlayer(index);

            ClearFont();
            ChangeFocus(index);
        }

        private void T_PreKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var t = sender as TextBox;
            if (t != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.IsInputKey = true;
                }
                else if (e.KeyData == Keys.Tab)
                {
                    if (isZero && !muteSounds)
                        SoundEffects.SoundEffects.player[0].Play();
                    isZero = true;
                }
            }
        }

        private void T_KeyDown(object sender, KeyEventArgs e)
        {
            var t = sender as TextBox;
            if (t == null) return;

            if (e.KeyCode == Keys.Enter)
            {
                isZero  = false;
                B_Click(sender, e);
                e.Handled = e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");

            }

        }

        private void SaveChangesToDB()
        {
            var db = new DbSipky.MyDatabase();
            db.PlayerSettings.Update(playersDuel[0]);
            db.PlayerSettings.Update(playersDuel[1]);
            if(_2v2)
            {
                db.PlayerSettings.Update(playersDuel2[0]);
                db.PlayerSettings.Update(playersDuel2[1]);
            }
            db.SaveChanges();
        }

        private void DoStatistics(int score, int i)
        {
            if (change == true && _2v2 == true)
                Statistics.CheckStatistics(playersDuel2[i - 1], score);
            else
                Statistics.CheckStatistics(playersDuel[i - 1], score);
            SaveChangesToDB();
        }

        private void WriteWinStats(int score, int i)
        {
            playersDuel[i - 1].Average = Convert.ToDouble(AverageScore.CalculateAverage(9 + i));
            playersDuel[i - 1].AddWin();
            Statistics.CheckExpertAchievement(playersDuel[i - 1], score);

            if (_2v2 == true)
            {

                playersDuel2[i - 1].Average = Convert.ToDouble(AverageScore.CalculateAverage(9 + i));
                playersDuel2[i - 1].AddWin();
                Statistics.CheckExpertAchievement(playersDuel2[i - 1], score);
            }
            WinnerId = (int)playersDuel[i - 1].Id;
            SaveChangesToDB();
            Winner?.Invoke((int)playersDuel[i - 1].Id);
        }


        private void B_Click(object sender, EventArgs e)
        {
            var b = (dynamic)sender;
            int i = Convert.ToInt32(b.Tag);
            string playerScore = "ScorePlayer" + i;
            string playerLegs = "LegPlayer" + i;
            string playerThrows = "thrownPlayer" + i;
            string playerAverage = "AvgPlayer" + i;
            string playerCheckout = "CheckoutPlayer" + i;
            string resultScore = "";
            muteSounds = GetCurrentMute();

            int score = int.TryParse(panel3.Controls[playerThrows].Text, out score) ? score : -1;
            if (score > -1 && score < 181)
            {
                int result = -1;
                resultScore = CalculateScore.GetResult(int.Parse(panel3.Controls[playerScore].Text), score, muteSounds, out result);
                if (resultScore != null)
                {
                    HistoryScore.AddHistory(9 + i, panel3.Controls[playerScore].Text);
                    panel3.Controls[playerScore].Text = resultScore;
                    AverageScore.AddAverage(9 + i, score);

                    DoStatistics(score, i);
                    if (result == 0)
                    {
                        if (change == true && _2v2 == true)
                            playersDuel2[i - 1].highestOut = score;
                        else
                            playersDuel[i-1].highestOut = score;   

                        panel3.Controls[playerLegs].Text = (int.Parse(panel3.Controls[playerLegs].Text) + 1).ToString();
                        if (int.Parse(panel3.Controls[playerLegs].Text) == numberOfLegs && !sets)
                        {
                            WinnerLabel.Text = "Výhra hráče " + playersDuel[i - 1].Name;
                            if (_2v2)
                                WinnerLabel.Text += " a " + playersDuel2[i - 1].Name;


							thrownPlayer1.Enabled = false;
							thrownPlayer2.Enabled = false;

							WriteWinStats(score, i);

                            if(muteSounds == false)
                                SoundEffects.SoundEffects.win.Play();
                        }
                        else if (int.Parse(panel3.Controls[playerLegs].Text) == 3 && sets)
                        {
                            string set = "SetPlayer" + i;
                            panel3.Controls[set].Text = (int.Parse(panel3.Controls[set].Text) + 1).ToString();
                            if (panel3.Controls[set].Text == numberOfSets.ToString())
                            {
                                panel3.Controls[playerLegs].Text = "0";
                                WinnerLabel.Text = "Výhra hráče " + playersDuel[i - 1].Name;
                                WriteWinStats(score, i);
                                thrownPlayer1.Enabled = false;
                                thrownPlayer2.Enabled = false;                                
                            }
                            if (muteSounds == false)
                                SoundEffects.SoundEffects.win.Play();
                            panel3.Controls["LegPlayer1"].Text = "0";
                            panel3.Controls["LegPlayer2"].Text = "0";
                            var res = MessageBox.Show("Chcete pauzu před odehráním dalšího setu?", "Konec setu", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                            if(res==DialogResult.Yes)
                            {
                                MainWindow form = (MainWindow)MainWindow.ActiveForm;
                                if (form != null && form.stopwatch.IsRunning)
                                {
                                    form.timerToolStripMenuItem_Click(sender, e);
                                    MessageBox.Show("Pauza byla zahájena. Byl zastaven časovač. Pro obnovení časovače klikni na spustit časovač", "Pauza zahájena", MessageBoxButtons.OK,MessageBoxIcon.Information);
                                }
                            }

                        }
                        panel3.Controls["ScorePlayer1"].Text = scoreDuel.ToString();
                        panel3.Controls["ScorePlayer2"].Text = scoreDuel.ToString();
                        panel4.Controls["CheckoutPlayer1"].Text = ".";
                        panel4.Controls["CheckoutPlayer2"].Text = ".";

                    }
                    panel4.Controls[playerCheckout].Text = Checkout.checkout(int.Parse(resultScore));
                }

                count++;
                if (count == 2)
                {
                    count = 0;
                    change = !change;
                }
            }
            else
            {
                if(!muteSounds)
                    SoundEffects.SoundEffects.player[0].Play();
			}

            panel3.Controls[playerThrows].Text = "";
            playersDuel[i - 1].Average = Convert.ToDouble(AverageScore.CalculateAverage(9 + i));
            panel4.Controls[playerAverage].Text = AverageScore.CalculateAverage(9 + i).ToString();

        }

        public void SetDuel(int score, int legs, Player one, Player two, bool sets)
        {
            scoreDuel = score;
            if (sets)
            {
                numberOfLegs = 3;
                numberOfSets = legs;
                firstTo.Text = "První do " + numberOfSets.ToString();
                panel3.Controls["SetPlayer1"].Text = "0";
                panel3.Controls["SetPlayer2"].Text = "0";
            }
            else
            {
                numberOfLegs = legs;
                firstTo.Text = "První do " + numberOfLegs.ToString();
            }
            ResizeControls(sets);
            Reset();
            playersDuel[0] = one;
            playersDuel[1] = two;
            ScorePlayer1.Text = ScorePlayer2.Text = scoreDuel.ToString();
            PlayerOne.Text = playersDuel[0].Name;
            PlayerTwo.Text = playersDuel[1].Name;
            p1.Visible = p2.Visible = PlayerThree.Visible = PlayerFour.Visible = false;
            if(GetCurrentMute() == false)
                SoundEffects.SoundEffects.gameon.Play();
            _2v2 = false;
            this.sets = sets;
        }

        public void SetDuel(int score, int legs, Player one, Player two, Player Three, Player Four)
        {
            ResizeControls(false);
            Reset();
            scoreDuel = score;
            numberOfLegs = legs;
            playersDuel[0] = one;
            playersDuel[1] = Three;
            playersDuel2[0] = two;
            playersDuel2[1] = Four;
            ScorePlayer1.Text = ScorePlayer2.Text = scoreDuel.ToString();
            PlayerOne.Text = playersDuel[0].Name;
            PlayerTwo.Text = playersDuel[1].Name;
            PlayerThree.Text = playersDuel2[0].Name;
            PlayerFour.Text = playersDuel2[1].Name;
            p1.Visible = p2.Visible = PlayerThree.Visible = PlayerFour.Visible = true;
            firstTo.Text = "První do " + numberOfLegs.ToString();
            if (GetCurrentMute() == false)
                SoundEffects.SoundEffects.gameon.Play();
            _2v2 = true;
        }

        public void Reset()
        {
			AverageScore.ClearAverage();
			HistoryScore.ClearHistory();
			LegPlayer1.Text = LegPlayer2.Text = "0";
			AvgPlayer1.Text = AvgPlayer2.Text = "0.00";
			CheckoutPlayer1.Text = CheckoutPlayer2.Text = ".";
			thrownPlayer1.Enabled = true;
			thrownPlayer2.Enabled = true;
			WinnerLabel.Text = "";
		}

		public void RedoLast(int player, string score)
        {
            int idk = player;
            player = player - 9;

            string playerScore = "ScorePlayer" + player;
            string playerAverage = "AvgPlayer" + player;
            string playerCheckout = "CheckoutPlayer" + player;
            panel3.Controls[playerScore].Text = score;
            this.Controls[playerAverage].Text = AverageScore.CalculateAverage(idk);
            this.Controls[playerCheckout].Text = Checkout.checkout(int.Parse(score));

        }

        public DuelGame()
        {
            InitializeComponent();
        }

        private void ResizeControls(bool sets)
        {
            int offset = 89;
            if (sets)
            {
                l_sets.Visible = true;
                panel3.Width = 400;
                panel3.Location = new Point(320, 50);
                if (panel3.Controls["LegPlayer1"].Location.X == 6)
                {
                    for (int i = 0; i < panel3.Controls.Count; i++)
                    {
                        int x = panel3.Controls[i].Location.X;
                        int y = panel3.Controls[i].Location.Y;
                        panel3.Controls[i].Location = new Point(x + offset, y);
                    }
                }
            }
            else
            {
                l_sets.Visible = false;
                panel3.Width = 311;
                panel3.Location = new Point(409, 50);
                if (panel3.Controls["LegPlayer1"].Location.X != 6)
                {
                    for (int i = 0; i < panel3.Controls.Count; i++)
                    {
                        int x = panel3.Controls[i].Location.X;
                        int y = panel3.Controls[i].Location.Y;
                        panel3.Controls[i].Location = new Point(x - offset, y);
                    }
                }
            }
        }
    }
}
