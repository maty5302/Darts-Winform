namespace šipky_Forms_DotNet
{
	partial class MainWindow
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            menuStrip1 = new MenuStrip();
            redoItem = new ToolStripMenuItem();
            hudbaToolStripMenuItem = new ToolStripMenuItem();
            přehrátToolStripMenuItem = new ToolStripMenuItem();
            zastavitToolStripMenuItem = new ToolStripMenuItem();
            ztlumitToolStripMenuItem = new ToolStripMenuItem();
            statistikyToolStripMenuItem = new ToolStripMenuItem();
            nastaveníToolStripMenuItem = new ToolStripMenuItem();
            oProgramuToolStripMenuItem = new ToolStripMenuItem();
            DownloadNewVersion = new ToolStripMenuItem();
            panelStart = new Panel();
            b_detailTournament = new Button();
            b_turnaj = new Button();
            StartTraining = new Button();
            StartDuel = new Button();
            labelScore = new Label();
            ScoreDarts = new NumericUpDown();
            labelPlayers = new Label();
            StartGame = new Button();
            playerCount = new NumericUpDown();
            labelDarts = new Label();
            checkTimer = new CheckBox();
            notifyIcon1 = new NotifyIcon(components);
            label1 = new Label();
            openFileDialog2 = new OpenFileDialog();
            panelTimer = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            panelStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ScoreDarts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerCount).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Items.AddRange(new ToolStripItem[] { redoItem, hudbaToolStripMenuItem, statistikyToolStripMenuItem, nastaveníToolStripMenuItem, oProgramuToolStripMenuItem, DownloadNewVersion });
            menuStrip1.Name = "menuStrip1";
            // 
            // redoItem
            // 
            resources.ApplyResources(redoItem, "redoItem");
            redoItem.Image = šipky_Forms.Properties.Resources.back;
            redoItem.Name = "redoItem";
            redoItem.Click += redoItem_Click;
            // 
            // hudbaToolStripMenuItem
            // 
            resources.ApplyResources(hudbaToolStripMenuItem, "hudbaToolStripMenuItem");
            hudbaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { přehrátToolStripMenuItem, zastavitToolStripMenuItem, ztlumitToolStripMenuItem });
            hudbaToolStripMenuItem.Image = šipky_Forms.Properties.Resources.music;
            hudbaToolStripMenuItem.Name = "hudbaToolStripMenuItem";
            // 
            // přehrátToolStripMenuItem
            // 
            resources.ApplyResources(přehrátToolStripMenuItem, "přehrátToolStripMenuItem");
            přehrátToolStripMenuItem.Image = šipky_Forms.Properties.Resources.play;
            přehrátToolStripMenuItem.Name = "přehrátToolStripMenuItem";
            přehrátToolStripMenuItem.Click += přehrátToolStripMenuItem_Click;
            // 
            // zastavitToolStripMenuItem
            // 
            resources.ApplyResources(zastavitToolStripMenuItem, "zastavitToolStripMenuItem");
            zastavitToolStripMenuItem.Image = šipky_Forms.Properties.Resources.pause;
            zastavitToolStripMenuItem.Name = "zastavitToolStripMenuItem";
            zastavitToolStripMenuItem.Click += zastavitToolStripMenuItem_Click;
            // 
            // ztlumitToolStripMenuItem
            // 
            resources.ApplyResources(ztlumitToolStripMenuItem, "ztlumitToolStripMenuItem");
            ztlumitToolStripMenuItem.Image = šipky_Forms.Properties.Resources.mute;
            ztlumitToolStripMenuItem.Name = "ztlumitToolStripMenuItem";
            ztlumitToolStripMenuItem.Click += ztlumitToolStripMenuItem_Click;
            // 
            // statistikyToolStripMenuItem
            // 
            resources.ApplyResources(statistikyToolStripMenuItem, "statistikyToolStripMenuItem");
            statistikyToolStripMenuItem.Image = šipky_Forms.Properties.Resources.stats;
            statistikyToolStripMenuItem.Name = "statistikyToolStripMenuItem";
            statistikyToolStripMenuItem.Click += statistikyToolStripMenuItem_Click;
            // 
            // nastaveníToolStripMenuItem
            // 
            resources.ApplyResources(nastaveníToolStripMenuItem, "nastaveníToolStripMenuItem");
            nastaveníToolStripMenuItem.Image = šipky_Forms.Properties.Resources.settings;
            nastaveníToolStripMenuItem.Name = "nastaveníToolStripMenuItem";
            nastaveníToolStripMenuItem.Click += nastaveníToolStripMenuItem_Click;
            // 
            // oProgramuToolStripMenuItem
            // 
            resources.ApplyResources(oProgramuToolStripMenuItem, "oProgramuToolStripMenuItem");
            oProgramuToolStripMenuItem.Image = šipky_Forms.Properties.Resources.about;
            oProgramuToolStripMenuItem.Name = "oProgramuToolStripMenuItem";
            oProgramuToolStripMenuItem.Click += oProgramuToolStripMenuItem_Click;
            // 
            // DownloadNewVersion
            // 
            resources.ApplyResources(DownloadNewVersion, "DownloadNewVersion");
            DownloadNewVersion.Alignment = ToolStripItemAlignment.Right;
            DownloadNewVersion.BackColor = SystemColors.Info;
            DownloadNewVersion.Image = šipky_Forms.Properties.Resources.import;
            DownloadNewVersion.Name = "DownloadNewVersion";
            DownloadNewVersion.Click += DownloadNewVersion_Click;
            // 
            // panelStart
            // 
            resources.ApplyResources(panelStart, "panelStart");
            panelStart.BackColor = Color.White;
            panelStart.Controls.Add(b_detailTournament);
            panelStart.Controls.Add(b_turnaj);
            panelStart.Controls.Add(StartTraining);
            panelStart.Controls.Add(StartDuel);
            panelStart.Controls.Add(labelScore);
            panelStart.Controls.Add(ScoreDarts);
            panelStart.Controls.Add(labelPlayers);
            panelStart.Controls.Add(StartGame);
            panelStart.Controls.Add(playerCount);
            panelStart.Controls.Add(labelDarts);
            panelStart.Controls.Add(checkTimer);
            panelStart.Name = "panelStart";
            // 
            // b_detailTournament
            // 
            resources.ApplyResources(b_detailTournament, "b_detailTournament");
            b_detailTournament.Name = "b_detailTournament";
            b_detailTournament.TabStop = false;
            b_detailTournament.UseVisualStyleBackColor = true;
            b_detailTournament.Click += b_detailTournament_Click;
            // 
            // b_turnaj
            // 
            resources.ApplyResources(b_turnaj, "b_turnaj");
            b_turnaj.Name = "b_turnaj";
            b_turnaj.TabStop = false;
            b_turnaj.UseVisualStyleBackColor = true;
            b_turnaj.Click += b_turnaj_Click;
            // 
            // StartTraining
            // 
            resources.ApplyResources(StartTraining, "StartTraining");
            StartTraining.Name = "StartTraining";
            StartTraining.TabStop = false;
            StartTraining.UseVisualStyleBackColor = true;
            StartTraining.Click += StartTraining_Click;
            // 
            // StartDuel
            // 
            resources.ApplyResources(StartDuel, "StartDuel");
            StartDuel.Name = "StartDuel";
            StartDuel.TabStop = false;
            StartDuel.UseVisualStyleBackColor = true;
            StartDuel.Click += StartDuel_Click;
            // 
            // labelScore
            // 
            resources.ApplyResources(labelScore, "labelScore");
            labelScore.BackColor = Color.Transparent;
            labelScore.Name = "labelScore";
            // 
            // ScoreDarts
            // 
            resources.ApplyResources(ScoreDarts, "ScoreDarts");
            ScoreDarts.Increment = new decimal(new int[] { 200, 0, 0, 0 });
            ScoreDarts.Maximum = new decimal(new int[] { 901, 0, 0, 0 });
            ScoreDarts.Minimum = new decimal(new int[] { 301, 0, 0, 0 });
            ScoreDarts.Name = "ScoreDarts";
            ScoreDarts.ReadOnly = true;
            ScoreDarts.TabStop = false;
            ScoreDarts.Value = new decimal(new int[] { 301, 0, 0, 0 });
            // 
            // labelPlayers
            // 
            resources.ApplyResources(labelPlayers, "labelPlayers");
            labelPlayers.BackColor = Color.Transparent;
            labelPlayers.Name = "labelPlayers";
            // 
            // StartGame
            // 
            resources.ApplyResources(StartGame, "StartGame");
            StartGame.Name = "StartGame";
            StartGame.TabStop = false;
            StartGame.UseVisualStyleBackColor = true;
            StartGame.Click += StartGame_Click;
            // 
            // playerCount
            // 
            resources.ApplyResources(playerCount, "playerCount");
            playerCount.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            playerCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            playerCount.Name = "playerCount";
            playerCount.ReadOnly = true;
            playerCount.TabStop = false;
            playerCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelDarts
            // 
            resources.ApplyResources(labelDarts, "labelDarts");
            labelDarts.BackColor = Color.Transparent;
            labelDarts.Name = "labelDarts";
            // 
            // checkTimer
            // 
            resources.ApplyResources(checkTimer, "checkTimer");
            checkTimer.BackColor = Color.Transparent;
            checkTimer.Checked = true;
            checkTimer.CheckState = CheckState.Checked;
            checkTimer.Name = "checkTimer";
            checkTimer.UseVisualStyleBackColor = false;
            checkTimer.CheckedChanged += checkTimer_CheckedChanged;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            resources.ApplyResources(notifyIcon1, "notifyIcon1");
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // openFileDialog2
            // 
            resources.ApplyResources(openFileDialog2, "openFileDialog2");
            // 
            // panelTimer
            // 
            resources.ApplyResources(panelTimer, "panelTimer");
            panelTimer.Name = "panelTimer";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = šipky_Forms.Properties.Resources.darts_3;
            Controls.Add(panelTimer);
            Controls.Add(label1);
            Controls.Add(panelStart);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainWindow";
            FormClosing += MainWindow_FormClosing;
            Load += MainWindow_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelStart.ResumeLayout(false);
            panelStart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ScoreDarts).EndInit();
            ((System.ComponentModel.ISupportInitialize)playerCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
		private Panel panelStart;
		private Label labelDarts;
		private Button StartGame;
		private NumericUpDown playerCount;
		private Label labelPlayers;
		private NumericUpDown ScoreDarts;
		private Label labelScore;
		private ToolStripMenuItem hudbaToolStripMenuItem;
		private ToolStripMenuItem přehrátToolStripMenuItem;
		private ToolStripMenuItem zastavitToolStripMenuItem;
		private ToolStripMenuItem ztlumitToolStripMenuItem;
		private ToolStripMenuItem nastaveníToolStripMenuItem;
		private ToolStripMenuItem oProgramuToolStripMenuItem;
		private ToolStripMenuItem statistikyToolStripMenuItem;
		private Button StartTraining;
		private Button StartDuel;
		public ToolStripMenuItem redoItem;
		private Label label1;
		public NotifyIcon notifyIcon1;
		private ToolStripMenuItem DownloadNewVersion;
		private Button b_turnaj;
		private OpenFileDialog openFileDialog2;
		private Button b_detailTournament;
        private Label panelTimer;
        private System.Windows.Forms.Timer timer1;
        private CheckBox checkTimer;
    }
}