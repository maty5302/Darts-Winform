namespace šipky_Forms
{
	partial class DuelGameDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuelGameDialog));
			DuelScore = new NumericUpDown();
			cbPlayer1 = new ComboBox();
			startGame = new Button();
			numberofLegs = new NumericUpDown();
			cbPlayer2 = new ComboBox();
			errorProvider1 = new ErrorProvider(components);
			panel1 = new Panel();
			ch_sets = new CheckBox();
			l_team2 = new Label();
			l_team1 = new Label();
			label6 = new Label();
			label7 = new Label();
			cbPlayer4 = new ComboBox();
			cbPlayer3 = new ComboBox();
			checkBox1 = new CheckBox();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)DuelScore).BeginInit();
			((System.ComponentModel.ISupportInitialize)numberofLegs).BeginInit();
			((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// DuelScore
			// 
			DuelScore.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			DuelScore.Increment = new decimal(new int[] { 200, 0, 0, 0 });
			DuelScore.Location = new Point(102, 22);
			DuelScore.Maximum = new decimal(new int[] { 901, 0, 0, 0 });
			DuelScore.Minimum = new decimal(new int[] { 301, 0, 0, 0 });
			DuelScore.Name = "DuelScore";
			DuelScore.ReadOnly = true;
			DuelScore.Size = new Size(80, 23);
			DuelScore.TabIndex = 0;
			DuelScore.TextAlign = HorizontalAlignment.Center;
			DuelScore.Value = new decimal(new int[] { 301, 0, 0, 0 });
			// 
			// cbPlayer1
			// 
			cbPlayer1.DropDownStyle = ComboBoxStyle.DropDownList;
			cbPlayer1.FormattingEnabled = true;
			cbPlayer1.Location = new Point(102, 85);
			cbPlayer1.Name = "cbPlayer1";
			cbPlayer1.Size = new Size(80, 23);
			cbPlayer1.TabIndex = 1;
			// 
			// startGame
			// 
			startGame.Location = new Point(118, 267);
			startGame.Name = "startGame";
			startGame.Size = new Size(75, 23);
			startGame.TabIndex = 2;
			startGame.Text = "Hra";
			startGame.UseVisualStyleBackColor = true;
			startGame.Click += startGame_Click;
			// 
			// numberofLegs
			// 
			numberofLegs.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			numberofLegs.Location = new Point(102, 53);
			numberofLegs.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
			numberofLegs.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			numberofLegs.Name = "numberofLegs";
			numberofLegs.ReadOnly = true;
			numberofLegs.Size = new Size(80, 23);
			numberofLegs.TabIndex = 3;
			numberofLegs.TextAlign = HorizontalAlignment.Center;
			numberofLegs.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// cbPlayer2
			// 
			cbPlayer2.DropDownStyle = ComboBoxStyle.DropDownList;
			cbPlayer2.FormattingEnabled = true;
			cbPlayer2.Location = new Point(102, 114);
			cbPlayer2.Name = "cbPlayer2";
			cbPlayer2.Size = new Size(80, 23);
			cbPlayer2.TabIndex = 4;
			// 
			// errorProvider1
			// 
			errorProvider1.ContainerControl = this;
			// 
			// panel1
			// 
			panel1.Controls.Add(ch_sets);
			panel1.Controls.Add(l_team2);
			panel1.Controls.Add(l_team1);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(cbPlayer4);
			panel1.Controls.Add(cbPlayer3);
			panel1.Controls.Add(checkBox1);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(DuelScore);
			panel1.Controls.Add(cbPlayer2);
			panel1.Controls.Add(numberofLegs);
			panel1.Controls.Add(cbPlayer1);
			panel1.Location = new Point(58, 67);
			panel1.Name = "panel1";
			panel1.Size = new Size(200, 155);
			panel1.TabIndex = 5;
			// 
			// ch_sets
			// 
			ch_sets.AutoSize = true;
			ch_sets.Location = new Point(99, 137);
			ch_sets.Name = "ch_sets";
			ch_sets.Size = new Size(48, 19);
			ch_sets.TabIndex = 16;
			ch_sets.Text = "Sety";
			ch_sets.UseVisualStyleBackColor = true;
			ch_sets.CheckedChanged += ch_sets_CheckedChanged;
			// 
			// l_team2
			// 
			l_team2.AutoSize = true;
			l_team2.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
			l_team2.Location = new Point(3, 143);
			l_team2.Name = "l_team2";
			l_team2.Size = new Size(52, 12);
			l_team2.TabIndex = 15;
			l_team2.Text = "Druhý tým";
			l_team2.Visible = false;
			// 
			// l_team1
			// 
			l_team1.AutoSize = true;
			l_team1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
			l_team1.Location = new Point(2, 73);
			l_team1.Name = "l_team1";
			l_team1.Size = new Size(47, 12);
			l_team1.TabIndex = 14;
			l_team1.Text = "První tým";
			l_team1.Visible = false;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.BackColor = Color.Transparent;
			label6.Location = new Point(26, 188);
			label6.Name = "label6";
			label6.Size = new Size(65, 15);
			label6.TabIndex = 13;
			label6.Text = "Hráč čtvrtý";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.BackColor = Color.Transparent;
			label7.Location = new Point(26, 159);
			label7.Name = "label7";
			label7.Size = new Size(56, 15);
			label7.TabIndex = 12;
			label7.Text = "Hráč třetí";
			// 
			// cbPlayer4
			// 
			cbPlayer4.DropDownStyle = ComboBoxStyle.DropDownList;
			cbPlayer4.FormattingEnabled = true;
			cbPlayer4.Location = new Point(102, 185);
			cbPlayer4.Name = "cbPlayer4";
			cbPlayer4.Size = new Size(80, 23);
			cbPlayer4.TabIndex = 11;
			// 
			// cbPlayer3
			// 
			cbPlayer3.DropDownStyle = ComboBoxStyle.DropDownList;
			cbPlayer3.FormattingEnabled = true;
			cbPlayer3.Location = new Point(102, 156);
			cbPlayer3.Name = "cbPlayer3";
			cbPlayer3.Size = new Size(80, 23);
			cbPlayer3.TabIndex = 10;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(55, 137);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(45, 19);
			checkBox1.TabIndex = 9;
			checkBox1.Text = "2V2";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += checkBox1_CheckedChanged;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.BackColor = Color.Transparent;
			label5.Location = new Point(26, 117);
			label5.Name = "label5";
			label5.Size = new Size(66, 15);
			label5.TabIndex = 8;
			label5.Text = "Hráč druhý";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.BackColor = Color.Transparent;
			label4.Location = new Point(26, 88);
			label4.Name = "label4";
			label4.Size = new Size(62, 15);
			label4.TabIndex = 7;
			label4.Text = "Hráč první";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.BackColor = Color.Transparent;
			label3.Location = new Point(26, 55);
			label3.Name = "label3";
			label3.Size = new Size(63, 15);
			label3.TabIndex = 6;
			label3.Text = "Počet legů";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = Color.Transparent;
			label2.Location = new Point(26, 24);
			label2.Name = "label2";
			label2.Size = new Size(36, 15);
			label2.TabIndex = 5;
			label2.Text = "Skore";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.BackColor = Color.Transparent;
			label1.Font = new Font("Showcard Gothic", 32.25F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(94, 9);
			label1.Name = "label1";
			label1.Size = new Size(130, 53);
			label1.TabIndex = 6;
			label1.Text = "Duel";
			// 
			// DuelGameDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLight;
			BackgroundImage = Properties.Resources.duel;
			ClientSize = new Size(301, 302);
			Controls.Add(label1);
			Controls.Add(panel1);
			Controls.Add(startGame);
			DoubleBuffered = true;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "DuelGameDialog";
			Text = "Příprava duelu";
			((System.ComponentModel.ISupportInitialize)DuelScore).EndInit();
			((System.ComponentModel.ISupportInitialize)numberofLegs).EndInit();
			((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private NumericUpDown DuelScore;
		private ComboBox cbPlayer1;
		private Button startGame;
		private NumericUpDown numberofLegs;
		private ComboBox cbPlayer2;
		private ErrorProvider errorProvider1;
		private Label label1;
		private Panel panel1;
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label2;
		private CheckBox checkBox1;
		private Label label6;
		private Label label7;
		private ComboBox cbPlayer4;
		private ComboBox cbPlayer3;
		private Label l_team2;
		private Label l_team1;
		private CheckBox ch_sets;
	}
}