namespace šipky_Forms
{
	partial class TournamentDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentDialog));
			label1 = new Label();
			label2 = new Label();
			numericUpDown1 = new NumericUpDown();
			b_startTournament = new Button();
			label3 = new Label();
			cb_player1 = new ComboBox();
			cb_player2 = new ComboBox();
			label4 = new Label();
			cb_player3 = new ComboBox();
			label5 = new Label();
			cb_player4 = new ComboBox();
			l_player4 = new Label();
			errorProvider1 = new ErrorProvider(components);
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Showcard Gothic", 32.25F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(44, 9);
			label1.Name = "label1";
			label1.Size = new Size(180, 53);
			label1.TabIndex = 0;
			label1.Text = "Turnaj";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(56, 71);
			label2.Name = "label2";
			label2.Size = new Size(73, 15);
			label2.TabIndex = 1;
			label2.Text = "Počet hráčů:";
			// 
			// numericUpDown1
			// 
			numericUpDown1.Location = new Point(148, 69);
			numericUpDown1.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
			numericUpDown1.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.ReadOnly = true;
			numericUpDown1.Size = new Size(50, 23);
			numericUpDown1.TabIndex = 2;
			numericUpDown1.Value = new decimal(new int[] { 4, 0, 0, 0 });
			numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
			// 
			// b_startTournament
			// 
			b_startTournament.Location = new Point(96, 223);
			b_startTournament.Name = "b_startTournament";
			b_startTournament.Size = new Size(75, 23);
			b_startTournament.TabIndex = 3;
			b_startTournament.Text = "Hra";
			b_startTournament.UseVisualStyleBackColor = true;
			b_startTournament.Click += b_startTournament_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(56, 101);
			label3.Name = "label3";
			label3.Size = new Size(44, 15);
			label3.TabIndex = 4;
			label3.Text = "Hráč 1:";
			// 
			// cb_player1
			// 
			cb_player1.DropDownStyle = ComboBoxStyle.DropDownList;
			cb_player1.FormattingEnabled = true;
			cb_player1.Location = new Point(131, 98);
			cb_player1.Name = "cb_player1";
			cb_player1.Size = new Size(84, 23);
			cb_player1.TabIndex = 5;
			cb_player1.Tag = "1";
			// 
			// cb_player2
			// 
			cb_player2.DropDownStyle = ComboBoxStyle.DropDownList;
			cb_player2.FormattingEnabled = true;
			cb_player2.Location = new Point(131, 127);
			cb_player2.Name = "cb_player2";
			cb_player2.Size = new Size(84, 23);
			cb_player2.TabIndex = 7;
			cb_player2.Tag = "2";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(56, 130);
			label4.Name = "label4";
			label4.Size = new Size(44, 15);
			label4.TabIndex = 6;
			label4.Text = "Hráč 2:";
			// 
			// cb_player3
			// 
			cb_player3.DropDownStyle = ComboBoxStyle.DropDownList;
			cb_player3.FormattingEnabled = true;
			cb_player3.Location = new Point(131, 155);
			cb_player3.Name = "cb_player3";
			cb_player3.Size = new Size(84, 23);
			cb_player3.TabIndex = 9;
			cb_player3.Tag = "3";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(56, 158);
			label5.Name = "label5";
			label5.Size = new Size(44, 15);
			label5.TabIndex = 8;
			label5.Text = "Hráč 3:";
			// 
			// cb_player4
			// 
			cb_player4.DropDownStyle = ComboBoxStyle.DropDownList;
			cb_player4.FormattingEnabled = true;
			cb_player4.Location = new Point(131, 185);
			cb_player4.Name = "cb_player4";
			cb_player4.Size = new Size(84, 23);
			cb_player4.TabIndex = 11;
			cb_player4.Tag = "4";
			// 
			// l_player4
			// 
			l_player4.AutoSize = true;
			l_player4.Location = new Point(56, 188);
			l_player4.Name = "l_player4";
			l_player4.Size = new Size(44, 15);
			l_player4.TabIndex = 10;
			l_player4.Text = "Hráč 4:";
			// 
			// errorProvider1
			// 
			errorProvider1.ContainerControl = this;
			// 
			// TournamentDialog
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(275, 258);
			Controls.Add(cb_player4);
			Controls.Add(l_player4);
			Controls.Add(cb_player3);
			Controls.Add(label5);
			Controls.Add(cb_player2);
			Controls.Add(label4);
			Controls.Add(cb_player1);
			Controls.Add(label3);
			Controls.Add(b_startTournament);
			Controls.Add(numericUpDown1);
			Controls.Add(label2);
			Controls.Add(label1);
			DoubleBuffered = true;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "TournamentDialog";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Příprava turnaje";
			Deactivate += TournamentDialog_Deactivate;
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private NumericUpDown numericUpDown1;
		private Button b_startTournament;
		private Label label3;
		private ComboBox cb_player1;
		private ComboBox cb_player2;
		private Label label4;
		private ComboBox cb_player3;
		private Label label5;
		private ComboBox cb_player4;
		private Label l_player4;
		private ErrorProvider errorProvider1;
	}
}