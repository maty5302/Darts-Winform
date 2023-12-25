using Domain;
using Domain.Tournament;
using šipky_Forms;
using šipky_Forms.Database;
using šipky_Forms.Properties;
using System.Diagnostics;

namespace šipky_Forms_DotNet
{
    public partial class MainWindow : Form
    {
        private DuelGame d = new DuelGame();
        private Training train = new Training();

        private List<Player> playerList = new List<Player>();
        private Panel[] players = new Panel[10];

        private string selectedPanel = "";
        private bool isZero = false;
        private int place = 1;
        public bool mute = false;
        public int player = -1;

        private async Task CheckUpdatesAsync()
        {
            var gitVersion = await GithubIntegration.GetVersion();
            var appVersion = Application.ProductVersion.ToString();
            //var oldapp = appVersion;
            
            gitVersion = gitVersion.Replace(".", "").Replace("v", "").Replace("beta", "");
            appVersion = appVersion.Replace(".", "");

            //to remove some unexpected token because visual studio is giving it to every version file
            //revisit in another version
            int indexof = appVersion.IndexOf('+');
            if (indexof != -1)
                appVersion = appVersion.Remove(indexof);


            //MessageBox.Show(oldapp +'\n' + appVersion);

            if (string.Compare(gitVersion, appVersion) > 0)
            {
                ToolStripMenuItem newItem = new ToolStripMenuItem("Aktualizovat", new Bitmap(Resources.import), DownloadNewVersion_Click);
                this.notifyIcon1.ContextMenuStrip.Items.Insert(0, newItem);
                DownloadNewVersion.Visible = true;
                if (Convert.ToInt32(gitVersion[1] + "" + gitVersion[2]) > Convert.ToInt32(appVersion[1] + "" + appVersion[2]))
                {
                    DownloadNewVersion.BackColor = Color.FromArgb(255, 128, 128);
                    var result = MessageBox.Show("Je k dispozici důležitá aktualizace s novými funkcemi a opravami.\n Chcete jí stáhnout nyní?", "Důležítá aktualizace..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        DownloadNewVersion_Click(this, new EventArgs());
                }
            }
        }

        private void PanelsNamesBoldReset()
        {
            foreach (Control c in this.Controls) { 
                if (c is Panel)
                {
                    if (c.Name == "panelStart")
                        continue;
                    if (selectedPanel == c.Name)
                    {
                        c.Controls[2].Font = new Font("Arial", 12, FontStyle.Regular | FontStyle.Italic);
                        c.Paint += (s, ev) =>
                        {
                            ControlPaint.DrawBorder(ev.Graphics, c.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
                        };
                        c.Refresh();
                        break;
                    }
                }
            }
        }

        private void HidePanels()
        {
            foreach (var item in players)
                item.Hide();
        }

        private void LoadPlayers()
        {
            var db = new DbSipky.MyDatabase();
            playerList = db.PlayerSettings.ToList(); //before compiling make sure u have mydb.db in bin/debug or bin/release
        }

        private void setNotifyIconText(int score, int players)
        {
            this.Text = "";
            notifyIcon1.Text = "Šipky - " + score.ToString() + " / ";
            if (players == 1)
                this.Text += notifyIcon1.Text += "1 hráč";
            else if (players >= 2 && players <= 4)
                this.Text += notifyIcon1.Text += players.ToString() + " hráči";
            else
                this.Text += notifyIcon1.Text += players.ToString() + " hráčů";
        }

        public void setPlayer(int p)
        {
            player = p;
            redoItem.Enabled = !HistoryScore.IsEmpty(player);
        }

        private void MakePanels()
        {
            for (int i = 0; i < players.Length; i++)
            {
                int width = 40 + i * 150;
                int height = 220;
                if (i > 4)
                {
                    height = 361;
                    width = 40 + (i - 5) * 150;
                }

                Panel panel = new Panel();
                panel.Name = "panel" + i;
                panel.Location = new Point(width, height);
                panel.Size = new Size(122, 134);
                panel.BackColor = Color.ForestGreen;
                panel.Paint += (sender, e) =>
                {
                    ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
                };
                panel.Visible = false;
                panel.Parent = this;

                Button b = new Button();///0
				b.Location = new Point(73, 76);
                b.Size = new Size(34, 38);
                b.Text = "=";
                b.Tag = i;
                b.BackColor = Control.DefaultBackColor;
                b.Parent = panel;
                b.Click += B_Click;
                b.TabStop = false;

                TextBox t = new TextBox();//1
                t.Location = new Point(13, 76);
                t.Size = new Size(51, 38);
                t.Tag = i;
                t.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
                t.Parent = panel;
                t.Enter += T_Enter;
                t.KeyDown += T_KeyDown;
                t.TabIndex = i;

                Label name = new Label();//2
                name.Location = new Point(11, 11);
                name.Tag = i;
                name.Text = "Hráč " + i;
                name.Font = new Font("Arial", 12, FontStyle.Italic);
                name.BackColor = Color.Transparent;
                name.Parent = panel;

                Label score = new Label();//3
                score.Location = new Point(0, 37);
                score.Size = new Size(122, 37);
                score.Tag = i;
                score.Text = "501";
                score.Font = new Font("Arial", 24, FontStyle.Bold);
                score.BackColor = Color.Transparent;
                score.Parent = panel;
                score.TextAlign = ContentAlignment.MiddleCenter;

                Label average = new Label();//4
                average.Location = new Point(15, 117);
                average.Size = new Size(40, 17);
                average.Tag = i;
                average.Text = "0,00";
                average.BackColor = Color.Transparent;
                average.Parent = panel;

                Label checkout = new Label();//5
                checkout.Location = new Point(51, 117);
                checkout.Size = new Size(71, 13);
                checkout.Tag = i;
                checkout.Text = ".";
                checkout.BackColor = Color.Transparent;
                checkout.TextAlign = ContentAlignment.MiddleRight;
                checkout.Parent = panel;

                Label idk = new Label();
                idk.Text = "Ø:";
                idk.BackColor = Color.Transparent;
                idk.Location = new Point(2, 117);
                idk.Parent = panel;

                players[i] = panel;

                panelStart.BackColor = Color.FromArgb(200, Color.Transparent);
            }
        }

        public Player? GetPlayer(string playerName)
        {
            Player? p = null;
            foreach (var item in playerList)
            {
                if (item.Name == playerName)
                    p = item;
            }
            return p;
        }

        private void T_KeyDown(object sender, KeyEventArgs e)
        {
            var t = sender as TextBox;
            int check = -1;
            

            if (e.KeyCode == Keys.Enter && t != null)
            {
                e.Handled = e.SuppressKeyPress = true;
                check = int.TryParse(t.Text, out check) ? check : -1;
                
                if (check > -1){
                    B_Click(sender, e);                    
                }
                else
                {
                    SoundEffects.SoundEffects.player[0].Play(); 
                    t.Clear();
                }

                if (!isZero)
                    SendKeys.Send("{TAB}");
                else
                    isZero = false;
            }
        }

        private void T_Enter(object sender, EventArgs e)
        {
            var t = sender as TextBox;
            if (t != null)
            {
                var obj = t.Parent;
                PanelsNamesBoldReset();
                selectedPanel = obj.Name;
                obj.Paint += (s, ev) =>
                {
                    ControlPaint.DrawBorder(ev.Graphics, obj.ClientRectangle, Color.Orange, ButtonBorderStyle.Solid);
                };
                obj.Refresh();
                obj.Controls[2].Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic);

                player = (int)t.Tag;
                if (HistoryScore.IsEmpty(player))
                    redoItem.Enabled = false;
                else
                    redoItem.Enabled = true;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            MakePanels();
            LoadPlayers();
            TrayMenuContext();
            SoundEffects.SoundEffects.music.Play();
        }

        private void B_Click(object sender, EventArgs e)
        {
            var a = (dynamic)sender;
            var obj = a.Parent;
            int resultScore = -1;
            int score = int.TryParse(obj.Controls[1].Text, out score) ? score : -1;
            Player? p = GetPlayer(obj.Controls[2].Text);
            if (score > -1)
            {
                string result = CalculateScore.GetResult(int.Parse(obj.Controls[3].Text), score, mute, out resultScore);
                if (result != null)
                {
                    HistoryScore.AddHistory(player, obj.Controls[3].Text);
                    AverageScore.AddAverage(player, score);
                    obj.Controls[3].Text = result;

                    if (p != null)
                        Statistics.CheckStatistics(p, score);
                }
                else if (resultScore < 0)
                    MessageBox.Show("Přehozeno o " + resultScore, "Přehodil/a jsi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Nelze hodit více jak 180!   Tvoje: " + score, "Nepodváděj!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            obj.Controls[5].Text = Checkout.checkout(int.Parse(obj.Controls[3].Text));
            obj.Controls[4].Text = AverageScore.CalculateAverage(player);
            obj.Controls[1].Clear();

            if (obj.Controls[3].Text == "0")
            {
                if (p != null)
                {
                    if (place == 1 && (int)playerCount.Value > 1)
                        p.AddWin();
                    p.Average = Convert.ToDouble(AverageScore.CalculateAverage(player));
                }
                obj.Controls[1].Enabled = false;
                obj.Controls[0].Enabled = false;

                obj.Controls[3].Font = new Font("Arial", 18, FontStyle.Bold);
                obj.Controls[3].Text = place + ".místo";
                place++;
                isZero = true;
                if (!mute)
                    SoundEffects.SoundEffects.win.Play();

                var db = new DbSipky.MyDatabase();

                foreach (var item in playerList)
                {
                    db.PlayerSettings.Update(item);
                }
                db.SaveChanges();

            }

        }

        private void redoItem_Click(object sender, EventArgs e)
        {
            var score = HistoryScore.RedoLastScore(player);
            if (score != null)
            {
                if (player < 10)
                {
                    players[player].Controls[3].Text = score;
                    players[player].Controls[4].Text = AverageScore.CalculateAverage(player);
                }
                else
                    d.RedoLast(player, score);

                if (HistoryScore.IsEmpty(player))
                    redoItem.Enabled = false;
            }
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            place = 1;
            int count = (int)playerCount.Value;
            players.All(p => { p.Visible = false; return true; });
            for (int i = 0; i < count; i++)
            {
                AverageScore.ClearAverage();
                HistoryScore.ClearHistory();
                players[i].Controls[1].Text = "";
                players[i].Controls[1].Enabled = true;
                players[i].Controls[0].Enabled = true;
                players[i].Controls[4].Text = AverageScore.CalculateAverage(i);
                players[i].Controls[3].Text = ScoreDarts.Value.ToString();
                players[i].Controls[3].Font = new Font("Arial", 24, FontStyle.Bold);
                players[i].Controls[4].Text = "0.00";
                players[i].Controls[5].Text = ".";
                players[i].Visible = true;
            }
            if (!mute)
                SoundEffects.SoundEffects.gameon.Play();
            d.Hide();
            train.Hide();
            setNotifyIconText((int)ScoreDarts.Value, count);
        }

        private void zastavitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundEffects.SoundEffects.music.Stop();
        }

        private void přehrátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundEffects.SoundEffects.music.Play();
        }

        private void ztlumitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mute = !mute;
            ztlumitToolStripMenuItem.Checked = mute;
        }

        private void oProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs about = new AboutUs();
            about.ShowDialog();
        }

        private void nastaveníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(players, this.BackgroundImage);
            settings.OnCloseEvent += () =>
            {
                if (settings.BackroundImage1 != null)
                    this.BackgroundImage = settings.BackroundImage1;
            };
            settings.ShowDialog();
            GC.Collect();
        }

        private void statistikyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatisticsForm stats = new StatisticsForm(playerList);
            stats.ShowDialog();
        }

        private void StartDuel_Click(object sender, EventArgs e)
        {
            DuelGameDialog duel = new DuelGameDialog(playerList);
            if (!duel.IsDisposed)
                duel.ShowDialog();
            if (duel.clicked == true)
            {
                if (duel._2v2)
                {
                    d.SetDuel(duel.score, duel.legs, playerList[duel.selectedPlayer1], playerList[duel.selectedPlayer2], playerList[duel.selectedPlayer3], playerList[duel.selectedPlayer4]);
                    MainWindow.ActiveForm.Text = notifyIcon1.Text = "Šipky - Duel mezi: " + playerList[duel.selectedPlayer1].Name + "+" + playerList[duel.selectedPlayer2].Name + " a " + playerList[duel.selectedPlayer3].Name + "+" + playerList[duel.selectedPlayer4].Name;
                }
                else
                {
                    d.SetDuel(duel.score, duel.legs, playerList[duel.selectedPlayer1], playerList[duel.selectedPlayer2], duel.sets);
                    MainWindow.ActiveForm.Text = notifyIcon1.Text = "Šipky - Duel mezi: " + playerList[duel.selectedPlayer1].Name + " a " + playerList[duel.selectedPlayer2].Name;
                }
                d.Location = (Point)new Size(40, 220);
                d.Parent = this;
                HidePanels();
                train.Hide();
                d.Show();
            }
        }

        private void StartTraining_Click(object sender, EventArgs e)
        {
            HidePanels();
            d.Hide();
            train.Location = (Point)new Size(40, 220);
            train.Parent = this;
            train.Initializate();
            train.Show();
            this.Text = notifyIcon1.Text = "Šipky - Trénink";
        }

        private void DownloadNewVersion_Click(object sender, EventArgs e)
        {
            Update u = new Update();
            u.OnClose += () =>
            {
                Process.GetCurrentProcess().Kill();
            };
            u.ShowDialog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                await CheckUpdatesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nepodařilo se vyhledat aktualizace\n" + ex.ToString(), "Nastala chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrayMenuContext()
        {
            this.notifyIcon1.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.notifyIcon1.ContextMenuStrip.Items.Add("Minimalizovat do oznamovací oblasti", null, MenuMinimize_Click);
            this.notifyIcon1.ContextMenuStrip.Items.Add("Ukončit", null, MenuExit_Click);
        }

        void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void MenuMinimize_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //Tournament section
        private bool played = false;
        private bool stopLoops = false;
        private Tournament tournament1;

        private void playMatch(Match m)
        {
            if (m == null)
                return;

            d.Winner += (r) =>
            {
                played = true;
            };

            MainWindow.ActiveForm.Text = notifyIcon1.Text = "Šipky - Turnaj mezi: " + playerList.Find(x => x.Id == m.player1Id).Name + " a " + playerList.Find(x => x.Id == m.player2Id).Name + " - " + m.round + ". kolo";
            d.SetDuel(501, 3 * m.round, playerList.Find(x => x.Id == m.player1Id), playerList.Find(x => x.Id == m.player2Id), false);
            d.Location = (Point)new Size(40, 220);
            d.Parent = this;
            HidePanels();
            train.Hide();
            d.Show();
        }

        private void PlayMatches(List<Match> matches)
        {
            while (true)
            {
                foreach (Match match in matches)
                {
                    played = false; // Reset the 'played' flag

                    playMatch(match);

                    // Wait until the match is played
                    while (!played)
                    {
                        if (stopLoops)
                            return;
                        Application.DoEvents(); // Allow the application to process events and remain responsive
                    }
                    if (!mute)
                    {
                        Task.Run(() => { SoundEffects.SoundEffects.win.PlaySync(); });
                    }
                    match.winnerId = d.WinnerId;
                    // Check if there are more matches to play
                    if (matches.Find(x => x.winnerId == 0) == null)
                    {
                        tournament1.generateNextRound();
                        if (tournament1.matches.Count > 0)
                        {
                            // Play the matches of the next round
                            matches = tournament1.matches;
                        }
                        else
                        {
                            // No more matches, exit the loop
                            if (!mute)
                                SoundEffects.SoundEffects.win.Play();
                            return;
                        }
                    }
                }
            }

        }

        private void b_turnaj_Click(object sender, EventArgs e)
        {
            TournamentDialog dialog = new TournamentDialog(playerList);
            dialog.OnTournamentStart += x =>
            {
                dialog.Close();
                tournament1 = new Tournament(x);
                b_detailTournament.Enabled = true;
                PlayMatches(tournament1.matches);
            };
            dialog.Show();
        }

        private void b_detailTournament_Click(object sender, EventArgs e)
        {
            TournamentStats stats = new TournamentStats(tournament1.players, tournament1.allmatches);
            stats.ShowDialog();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopLoops = true; //For end while loops in tournament if it still running
        }

    }
}