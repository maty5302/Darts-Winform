namespace šipky_Forms
{
	partial class StatisticsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
			label1 = new Label();
			gb_createplayer = new GroupBox();
			createplayer = new Button();
			tb_namenewplayer = new TextBox();
			errorProvider1 = new ErrorProvider(components);
			groupBox1 = new GroupBox();
			tabControl1 = new TabControl();
			tabPage1 = new TabPage();
			label9 = new Label();
			highestOut = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			Label180 = new Label();
			label5 = new Label();
			Label120 = new Label();
			label6 = new Label();
			Label100 = new Label();
			label7 = new Label();
			Label60 = new Label();
			label8 = new Label();
			LabelAverage = new Label();
			LabelName = new Label();
			LabelWins = new Label();
			tabPage2 = new TabPage();
			label10 = new Label();
			Loldhighestout = new Label();
			label12 = new Label();
			label13 = new Label();
			L180 = new Label();
			label16 = new Label();
			L120 = new Label();
			label18 = new Label();
			L100 = new Label();
			label20 = new Label();
			L60 = new Label();
			label22 = new Label();
			Lname = new Label();
			LoldWin = new Label();
			b_rename = new Button();
			rename_tb = new TextBox();
			DeletePlayer = new Button();
			cb_players = new ComboBox();
			groupBox2 = new GroupBox();
			Profesional = new PictureBox();
			First180 = new PictureBox();
			Wins100 = new PictureBox();
			Wins20 = new PictureBox();
			firstWin = new PictureBox();
			errorProvider2 = new ErrorProvider(components);
			toolTip1 = new ToolTip(components);
			menuStrip1 = new MenuStrip();
			importHráčůToolStripMenuItem = new ToolStripMenuItem();
			openFileDialog1 = new OpenFileDialog();
			gb_createplayer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
			groupBox1.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)Profesional).BeginInit();
			((System.ComponentModel.ISupportInitialize)First180).BeginInit();
			((System.ComponentModel.ISupportInitialize)Wins100).BeginInit();
			((System.ComponentModel.ISupportInitialize)Wins20).BeginInit();
			((System.ComponentModel.ISupportInitialize)firstWin).BeginInit();
			((System.ComponentModel.ISupportInitialize)errorProvider2).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(7, 24);
			label1.Name = "label1";
			label1.Size = new Size(253, 47);
			label1.TabIndex = 0;
			label1.Text = "Statistiky hráčů";
			// 
			// gb_createplayer
			// 
			gb_createplayer.Controls.Add(createplayer);
			gb_createplayer.Controls.Add(tb_namenewplayer);
			gb_createplayer.Location = new Point(7, 82);
			gb_createplayer.Name = "gb_createplayer";
			gb_createplayer.Size = new Size(253, 56);
			gb_createplayer.TabIndex = 1;
			gb_createplayer.TabStop = false;
			gb_createplayer.Text = "Vytvoření hráče";
			// 
			// createplayer
			// 
			createplayer.Location = new Point(146, 22);
			createplayer.Name = "createplayer";
			createplayer.Size = new Size(88, 23);
			createplayer.TabIndex = 1;
			createplayer.Text = "Vytvořit";
			createplayer.UseVisualStyleBackColor = true;
			createplayer.Click += createplayer_Click;
			// 
			// tb_namenewplayer
			// 
			tb_namenewplayer.Location = new Point(40, 22);
			tb_namenewplayer.Name = "tb_namenewplayer";
			tb_namenewplayer.Size = new Size(100, 23);
			tb_namenewplayer.TabIndex = 0;
			tb_namenewplayer.Enter += tb_namenewplayer_Enter;
			tb_namenewplayer.KeyDown += T_KeyDown;
			// 
			// errorProvider1
			// 
			errorProvider1.ContainerControl = this;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(tabControl1);
			groupBox1.Controls.Add(b_rename);
			groupBox1.Controls.Add(rename_tb);
			groupBox1.Controls.Add(DeletePlayer);
			groupBox1.Controls.Add(cb_players);
			groupBox1.Location = new Point(7, 144);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(253, 343);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			groupBox1.Text = "Statistiky";
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Location = new Point(6, 80);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(241, 257);
			tabControl1.TabIndex = 17;
			// 
			// tabPage1
			// 
			tabPage1.BackColor = SystemColors.Control;
			tabPage1.Controls.Add(label9);
			tabPage1.Controls.Add(highestOut);
			tabPage1.Controls.Add(label2);
			tabPage1.Controls.Add(label3);
			tabPage1.Controls.Add(label4);
			tabPage1.Controls.Add(Label180);
			tabPage1.Controls.Add(label5);
			tabPage1.Controls.Add(Label120);
			tabPage1.Controls.Add(label6);
			tabPage1.Controls.Add(Label100);
			tabPage1.Controls.Add(label7);
			tabPage1.Controls.Add(Label60);
			tabPage1.Controls.Add(label8);
			tabPage1.Controls.Add(LabelAverage);
			tabPage1.Controls.Add(LabelName);
			tabPage1.Controls.Add(LabelWins);
			tabPage1.Location = new Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(233, 229);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Tento rok";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(30, 74);
			label9.Name = "label9";
			label9.Size = new Size(92, 15);
			label9.TabIndex = 15;
			label9.Text = "Největší zavření:";
			label9.TextAlign = ContentAlignment.TopRight;
			// 
			// highestOut
			// 
			highestOut.Location = new Point(128, 74);
			highestOut.Name = "highestOut";
			highestOut.Size = new Size(68, 15);
			highestOut.TabIndex = 16;
			highestOut.Text = "NaN";
			highestOut.TextAlign = ContentAlignment.TopCenter;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(44, 21);
			label2.Name = "label2";
			label2.Size = new Size(77, 15);
			label2.TabIndex = 2;
			label2.Text = "Jméno hráče:";
			label2.TextAlign = ContentAlignment.TopRight;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(37, 47);
			label3.Name = "label3";
			label3.Size = new Size(85, 15);
			label3.TabIndex = 3;
			label3.Text = "Počet vítězství:";
			label3.TextAlign = ContentAlignment.TopRight;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(24, 100);
			label4.Name = "label4";
			label4.Size = new Size(97, 15);
			label4.TabIndex = 4;
			label4.Text = "Poslední průměr:";
			label4.TextAlign = ContentAlignment.TopRight;
			// 
			// Label180
			// 
			Label180.Location = new Point(128, 197);
			Label180.Name = "Label180";
			Label180.Size = new Size(68, 15);
			Label180.TabIndex = 14;
			Label180.Text = "NaN";
			Label180.TextAlign = ContentAlignment.TopCenter;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(91, 124);
			label5.Name = "label5";
			label5.Size = new Size(30, 15);
			label5.TabIndex = 5;
			label5.Text = "60+:";
			label5.TextAlign = ContentAlignment.TopRight;
			// 
			// Label120
			// 
			Label120.Location = new Point(128, 173);
			Label120.Name = "Label120";
			Label120.Size = new Size(68, 15);
			Label120.TabIndex = 13;
			Label120.Text = "NaN";
			Label120.TextAlign = ContentAlignment.TopCenter;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(85, 149);
			label6.Name = "label6";
			label6.Size = new Size(36, 15);
			label6.TabIndex = 6;
			label6.Text = "100+:";
			label6.TextAlign = ContentAlignment.TopRight;
			// 
			// Label100
			// 
			Label100.Location = new Point(128, 149);
			Label100.Name = "Label100";
			Label100.Size = new Size(68, 15);
			Label100.TabIndex = 12;
			Label100.Text = "NaN";
			Label100.TextAlign = ContentAlignment.TopCenter;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(85, 173);
			label7.Name = "label7";
			label7.Size = new Size(36, 15);
			label7.TabIndex = 7;
			label7.Text = "120+:";
			label7.TextAlign = ContentAlignment.TopRight;
			// 
			// Label60
			// 
			Label60.Location = new Point(128, 124);
			Label60.Name = "Label60";
			Label60.Size = new Size(68, 15);
			Label60.TabIndex = 11;
			Label60.Text = "NaN";
			Label60.TextAlign = ContentAlignment.TopCenter;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(93, 197);
			label8.Name = "label8";
			label8.Size = new Size(28, 15);
			label8.TabIndex = 7;
			label8.Text = "180:";
			label8.TextAlign = ContentAlignment.TopRight;
			// 
			// LabelAverage
			// 
			LabelAverage.Location = new Point(128, 100);
			LabelAverage.Name = "LabelAverage";
			LabelAverage.Size = new Size(68, 15);
			LabelAverage.TabIndex = 10;
			LabelAverage.Text = "NaN";
			LabelAverage.TextAlign = ContentAlignment.TopCenter;
			// 
			// LabelName
			// 
			LabelName.Location = new Point(128, 21);
			LabelName.Name = "LabelName";
			LabelName.Size = new Size(68, 15);
			LabelName.TabIndex = 8;
			LabelName.Text = "NaN";
			LabelName.TextAlign = ContentAlignment.TopCenter;
			// 
			// LabelWins
			// 
			LabelWins.Location = new Point(128, 47);
			LabelWins.Name = "LabelWins";
			LabelWins.Size = new Size(68, 15);
			LabelWins.TabIndex = 9;
			LabelWins.Text = "NaN";
			LabelWins.TextAlign = ContentAlignment.TopCenter;
			// 
			// tabPage2
			// 
			tabPage2.BackColor = SystemColors.Control;
			tabPage2.Controls.Add(label10);
			tabPage2.Controls.Add(Loldhighestout);
			tabPage2.Controls.Add(label12);
			tabPage2.Controls.Add(label13);
			tabPage2.Controls.Add(L180);
			tabPage2.Controls.Add(label16);
			tabPage2.Controls.Add(L120);
			tabPage2.Controls.Add(label18);
			tabPage2.Controls.Add(L100);
			tabPage2.Controls.Add(label20);
			tabPage2.Controls.Add(L60);
			tabPage2.Controls.Add(label22);
			tabPage2.Controls.Add(Lname);
			tabPage2.Controls.Add(LoldWin);
			tabPage2.Location = new Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(233, 229);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Předchozí roky";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(30, 76);
			label10.Name = "label10";
			label10.Size = new Size(92, 15);
			label10.TabIndex = 31;
			label10.Text = "Největší zavření:";
			label10.TextAlign = ContentAlignment.TopRight;
			// 
			// Loldhighestout
			// 
			Loldhighestout.Location = new Point(128, 76);
			Loldhighestout.Name = "Loldhighestout";
			Loldhighestout.Size = new Size(68, 15);
			Loldhighestout.TabIndex = 32;
			Loldhighestout.Text = "NaN";
			Loldhighestout.TextAlign = ContentAlignment.TopCenter;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(44, 23);
			label12.Name = "label12";
			label12.Size = new Size(77, 15);
			label12.TabIndex = 17;
			label12.Text = "Jméno hráče:";
			label12.TextAlign = ContentAlignment.TopRight;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new Point(37, 49);
			label13.Name = "label13";
			label13.Size = new Size(85, 15);
			label13.TabIndex = 18;
			label13.Text = "Počet vítězství:";
			label13.TextAlign = ContentAlignment.TopRight;
			// 
			// L180
			// 
			L180.Location = new Point(128, 174);
			L180.Name = "L180";
			L180.Size = new Size(68, 15);
			L180.TabIndex = 30;
			L180.Text = "NaN";
			L180.TextAlign = ContentAlignment.TopCenter;
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Location = new Point(91, 101);
			label16.Name = "label16";
			label16.Size = new Size(30, 15);
			label16.TabIndex = 20;
			label16.Text = "60+:";
			label16.TextAlign = ContentAlignment.TopRight;
			// 
			// L120
			// 
			L120.Location = new Point(128, 150);
			L120.Name = "L120";
			L120.Size = new Size(68, 15);
			L120.TabIndex = 29;
			L120.Text = "NaN";
			L120.TextAlign = ContentAlignment.TopCenter;
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Location = new Point(85, 126);
			label18.Name = "label18";
			label18.Size = new Size(36, 15);
			label18.TabIndex = 21;
			label18.Text = "100+:";
			label18.TextAlign = ContentAlignment.TopRight;
			// 
			// L100
			// 
			L100.Location = new Point(128, 126);
			L100.Name = "L100";
			L100.Size = new Size(68, 15);
			L100.TabIndex = 28;
			L100.Text = "NaN";
			L100.TextAlign = ContentAlignment.TopCenter;
			// 
			// label20
			// 
			label20.AutoSize = true;
			label20.Location = new Point(85, 150);
			label20.Name = "label20";
			label20.Size = new Size(36, 15);
			label20.TabIndex = 22;
			label20.Text = "120+:";
			label20.TextAlign = ContentAlignment.TopRight;
			// 
			// L60
			// 
			L60.Location = new Point(128, 101);
			L60.Name = "L60";
			L60.Size = new Size(68, 15);
			L60.TabIndex = 27;
			L60.Text = "NaN";
			L60.TextAlign = ContentAlignment.TopCenter;
			// 
			// label22
			// 
			label22.AutoSize = true;
			label22.Location = new Point(93, 174);
			label22.Name = "label22";
			label22.Size = new Size(28, 15);
			label22.TabIndex = 23;
			label22.Text = "180:";
			label22.TextAlign = ContentAlignment.TopRight;
			// 
			// Lname
			// 
			Lname.Location = new Point(128, 23);
			Lname.Name = "Lname";
			Lname.Size = new Size(68, 15);
			Lname.TabIndex = 24;
			Lname.Text = "NaN";
			Lname.TextAlign = ContentAlignment.TopCenter;
			// 
			// LoldWin
			// 
			LoldWin.Location = new Point(128, 49);
			LoldWin.Name = "LoldWin";
			LoldWin.Size = new Size(68, 15);
			LoldWin.TabIndex = 25;
			LoldWin.Text = "NaN";
			LoldWin.TextAlign = ContentAlignment.TopCenter;
			// 
			// b_rename
			// 
			b_rename.Location = new Point(146, 51);
			b_rename.Name = "b_rename";
			b_rename.Size = new Size(88, 23);
			b_rename.TabIndex = 16;
			b_rename.Text = "Přejmenovat";
			b_rename.UseVisualStyleBackColor = true;
			b_rename.Click += b_rename_Click;
			// 
			// rename_tb
			// 
			rename_tb.Location = new Point(40, 51);
			rename_tb.Name = "rename_tb";
			rename_tb.Size = new Size(100, 23);
			rename_tb.TabIndex = 15;
			rename_tb.Enter += rename_tb_Enter;
			// 
			// DeletePlayer
			// 
			DeletePlayer.Location = new Point(146, 22);
			DeletePlayer.Name = "DeletePlayer";
			DeletePlayer.Size = new Size(88, 23);
			DeletePlayer.TabIndex = 1;
			DeletePlayer.Text = "Smazat";
			DeletePlayer.UseVisualStyleBackColor = true;
			DeletePlayer.Click += DeletePlayer_Click;
			// 
			// cb_players
			// 
			cb_players.DropDownStyle = ComboBoxStyle.DropDownList;
			cb_players.FormattingEnabled = true;
			cb_players.Location = new Point(40, 22);
			cb_players.Name = "cb_players";
			cb_players.Size = new Size(100, 23);
			cb_players.TabIndex = 0;
			cb_players.SelectedIndexChanged += cb_players_SelectedIndexChanged;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(Profesional);
			groupBox2.Controls.Add(First180);
			groupBox2.Controls.Add(Wins100);
			groupBox2.Controls.Add(Wins20);
			groupBox2.Controls.Add(firstWin);
			groupBox2.Location = new Point(7, 493);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(253, 81);
			groupBox2.TabIndex = 3;
			groupBox2.TabStop = false;
			groupBox2.Text = "Úspěchy";
			// 
			// Profesional
			// 
			Profesional.Image = Properties.Resources.a_more100_no;
			Profesional.Location = new Point(191, 28);
			Profesional.Name = "Profesional";
			Profesional.Size = new Size(35, 35);
			Profesional.SizeMode = PictureBoxSizeMode.StretchImage;
			Profesional.TabIndex = 4;
			Profesional.TabStop = false;
			Profesional.MouseHover += Profesional_MouseHover;
			// 
			// First180
			// 
			First180.Image = Properties.Resources.a_180_no;
			First180.Location = new Point(150, 28);
			First180.Name = "First180";
			First180.Size = new Size(35, 35);
			First180.SizeMode = PictureBoxSizeMode.StretchImage;
			First180.TabIndex = 3;
			First180.TabStop = false;
			First180.MouseHover += First180_MouseHover;
			// 
			// Wins100
			// 
			Wins100.Image = Properties.Resources.a_cup_100_no;
			Wins100.Location = new Point(109, 28);
			Wins100.Name = "Wins100";
			Wins100.Size = new Size(35, 35);
			Wins100.SizeMode = PictureBoxSizeMode.StretchImage;
			Wins100.TabIndex = 2;
			Wins100.TabStop = false;
			Wins100.MouseHover += Wins100_MouseHover;
			// 
			// Wins20
			// 
			Wins20.Image = Properties.Resources.a_cup_20_no;
			Wins20.Location = new Point(68, 28);
			Wins20.Name = "Wins20";
			Wins20.Size = new Size(35, 35);
			Wins20.SizeMode = PictureBoxSizeMode.StretchImage;
			Wins20.TabIndex = 1;
			Wins20.TabStop = false;
			Wins20.MouseHover += Wins20_MouseHover;
			// 
			// firstWin
			// 
			firstWin.Image = Properties.Resources.a_cup_no;
			firstWin.Location = new Point(27, 28);
			firstWin.Name = "firstWin";
			firstWin.Size = new Size(35, 35);
			firstWin.SizeMode = PictureBoxSizeMode.StretchImage;
			firstWin.TabIndex = 0;
			firstWin.TabStop = false;
			firstWin.MouseHover += firstWin_MouseHover;
			// 
			// errorProvider2
			// 
			errorProvider2.ContainerControl = this;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { importHráčůToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(267, 24);
			menuStrip1.TabIndex = 4;
			menuStrip1.Text = "menuStrip1";
			// 
			// importHráčůToolStripMenuItem
			// 
			importHráčůToolStripMenuItem.Image = Properties.Resources.import21;
			importHráčůToolStripMenuItem.Name = "importHráčůToolStripMenuItem";
			importHráčůToolStripMenuItem.Size = new Size(107, 20);
			importHráčůToolStripMenuItem.Text = "Import hráčů ";
			importHráčůToolStripMenuItem.Click += importHráčůToolStripMenuItem_Click;
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			// 
			// StatisticsForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(267, 586);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(gb_createplayer);
			Controls.Add(label1);
			Controls.Add(menuStrip1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "StatisticsForm";
			Text = "Statistiky";
			gb_createplayer.ResumeLayout(false);
			gb_createplayer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)Profesional).EndInit();
			((System.ComponentModel.ISupportInitialize)First180).EndInit();
			((System.ComponentModel.ISupportInitialize)Wins100).EndInit();
			((System.ComponentModel.ISupportInitialize)Wins20).EndInit();
			((System.ComponentModel.ISupportInitialize)firstWin).EndInit();
			((System.ComponentModel.ISupportInitialize)errorProvider2).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private GroupBox gb_createplayer;
		private Button createplayer;
		private TextBox tb_namenewplayer;
		private ErrorProvider errorProvider1;
		private GroupBox groupBox1;
		private ComboBox cb_players;
		private Button DeletePlayer;
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label Label180;
		private Label Label120;
		private Label Label100;
		private Label Label60;
		private Label LabelAverage;
		private Label LabelWins;
		private Label LabelName;
		private Label label8;
		private Label label7;
		private Label label6;
		private GroupBox groupBox2;
		private PictureBox firstWin;
		private PictureBox Profesional;
		private PictureBox First180;
		private PictureBox Wins100;
		private PictureBox Wins20;
		private ErrorProvider errorProvider2;
		private ToolTip toolTip1;
		private Button b_rename;
		private TextBox rename_tb;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private Label label9;
		private Label highestOut;
		private TabPage tabPage2;
		private Label label10;
		private Label Loldhighestout;
		private Label label12;
		private Label label13;
		private Label L180;
		private Label label16;
		private Label L120;
		private Label label18;
		private Label L100;
		private Label label20;
		private Label L60;
		private Label label22;
		private Label Lname;
		private Label LoldWin;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem importHráčůToolStripMenuItem;
		private OpenFileDialog openFileDialog1;
	}
}