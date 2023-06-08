namespace šipky_Forms
{
    partial class DuelGame
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            l_sets = new Label();
            label3 = new Label();
            firstTo = new Label();
            panel2 = new Panel();
            WinnerLabel = new Label();
            label1 = new Label();
            panel3 = new Panel();
            SetPlayer2 = new Label();
            SetPlayer1 = new Label();
            thrownPlayer2 = new TextBox();
            thrownPlayer1 = new TextBox();
            ScorePlayer2 = new Label();
            ScorePlayer1 = new Label();
            LegPlayer2 = new Label();
            LegPlayer1 = new Label();
            PlayerOne = new Label();
            PlayerTwo = new Label();
            bPlayerTwo = new Button();
            bPlayerOne = new Button();
            label2 = new Label();
            label4 = new Label();
            AvgPlayer1 = new Label();
            AvgPlayer2 = new Label();
            CheckoutPlayer1 = new Label();
            CheckoutPlayer2 = new Label();
            PlayerThree = new Label();
            PlayerFour = new Label();
            p2 = new Label();
            p1 = new Label();
            panel4 = new Panel();
            pointer = new Panel();
            label5 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            pointer.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Desktop;
            panel1.Controls.Add(l_sets);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(firstTo);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(720, 50);
            panel1.TabIndex = 0;
            // 
            // l_sets
            // 
            l_sets.AutoSize = true;
            l_sets.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            l_sets.ForeColor = SystemColors.ControlLightLight;
            l_sets.Location = new Point(325, 0);
            l_sets.Name = "l_sets";
            l_sets.Size = new Size(69, 47);
            l_sets.TabIndex = 2;
            l_sets.Text = "Set";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(415, 0);
            label3.Name = "label3";
            label3.Size = new Size(75, 47);
            label3.TabIndex = 1;
            label3.Text = "Leg";
            // 
            // firstTo
            // 
            firstTo.AutoSize = true;
            firstTo.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            firstTo.ForeColor = SystemColors.ControlLightLight;
            firstTo.Location = new Point(40, 0);
            firstTo.Name = "firstTo";
            firstTo.Size = new Size(149, 47);
            firstTo.TabIndex = 0;
            firstTo.Text = "První do";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Desktop;
            panel2.Controls.Add(WinnerLabel);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, 225);
            panel2.Name = "panel2";
            panel2.Size = new Size(720, 50);
            panel2.TabIndex = 1;
            // 
            // WinnerLabel
            // 
            WinnerLabel.AutoSize = true;
            WinnerLabel.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            WinnerLabel.ForeColor = SystemColors.ControlLightLight;
            WinnerLabel.Location = new Point(214, 0);
            WinnerLabel.Name = "WinnerLabel";
            WinnerLabel.Size = new Size(0, 47);
            WinnerLabel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(40, 0);
            label1.Name = "label1";
            label1.Size = new Size(91, 47);
            label1.TabIndex = 0;
            label1.Text = "Duel";
            // 
            // panel3
            // 
            panel3.BackColor = Color.ForestGreen;
            panel3.Controls.Add(SetPlayer2);
            panel3.Controls.Add(SetPlayer1);
            panel3.Controls.Add(thrownPlayer2);
            panel3.Controls.Add(thrownPlayer1);
            panel3.Controls.Add(ScorePlayer2);
            panel3.Controls.Add(ScorePlayer1);
            panel3.Controls.Add(LegPlayer2);
            panel3.Controls.Add(LegPlayer1);
            panel3.Location = new Point(408, 49);
            panel3.Name = "panel3";
            panel3.Size = new Size(311, 178);
            panel3.TabIndex = 2;
            // 
            // SetPlayer2
            // 
            SetPlayer2.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            SetPlayer2.ForeColor = SystemColors.ControlLightLight;
            SetPlayer2.Location = new Point(-83, 87);
            SetPlayer2.Name = "SetPlayer2";
            SetPlayer2.Size = new Size(80, 60);
            SetPlayer2.TabIndex = 7;
            SetPlayer2.Text = "0";
            SetPlayer2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SetPlayer1
            // 
            SetPlayer1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            SetPlayer1.ForeColor = SystemColors.ControlLightLight;
            SetPlayer1.Location = new Point(-83, 15);
            SetPlayer1.Name = "SetPlayer1";
            SetPlayer1.Size = new Size(80, 60);
            SetPlayer1.TabIndex = 6;
            SetPlayer1.Text = "0";
            SetPlayer1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // thrownPlayer2
            // 
            thrownPlayer2.BackColor = Color.ForestGreen;
            thrownPlayer2.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            thrownPlayer2.ForeColor = SystemColors.Window;
            thrownPlayer2.Location = new Point(197, 87);
            thrownPlayer2.Name = "thrownPlayer2";
            thrownPlayer2.Size = new Size(100, 71);
            thrownPlayer2.TabIndex = 5;
            thrownPlayer2.Tag = "2";
            thrownPlayer2.Enter += T_Enter;
            thrownPlayer2.KeyDown += T_KeyDown;
            // 
            // thrownPlayer1
            // 
            thrownPlayer1.BackColor = Color.ForestGreen;
            thrownPlayer1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            thrownPlayer1.ForeColor = SystemColors.Window;
            thrownPlayer1.Location = new Point(197, 12);
            thrownPlayer1.Name = "thrownPlayer1";
            thrownPlayer1.Size = new Size(100, 71);
            thrownPlayer1.TabIndex = 4;
            thrownPlayer1.Tag = "1";
            thrownPlayer1.Enter += T_Enter;
            thrownPlayer1.KeyDown += T_KeyDown;
            // 
            // ScorePlayer2
            // 
            ScorePlayer2.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            ScorePlayer2.ForeColor = SystemColors.ControlLightLight;
            ScorePlayer2.Location = new Point(92, 87);
            ScorePlayer2.Name = "ScorePlayer2";
            ScorePlayer2.Size = new Size(115, 60);
            ScorePlayer2.TabIndex = 3;
            ScorePlayer2.Text = "501";
            ScorePlayer2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ScorePlayer1
            // 
            ScorePlayer1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            ScorePlayer1.ForeColor = SystemColors.ControlLightLight;
            ScorePlayer1.Location = new Point(92, 15);
            ScorePlayer1.Name = "ScorePlayer1";
            ScorePlayer1.Size = new Size(115, 60);
            ScorePlayer1.TabIndex = 2;
            ScorePlayer1.Text = "501";
            ScorePlayer1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LegPlayer2
            // 
            LegPlayer2.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            LegPlayer2.ForeColor = SystemColors.ControlLightLight;
            LegPlayer2.Location = new Point(6, 87);
            LegPlayer2.Name = "LegPlayer2";
            LegPlayer2.Size = new Size(80, 60);
            LegPlayer2.TabIndex = 1;
            LegPlayer2.Text = "0";
            LegPlayer2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LegPlayer1
            // 
            LegPlayer1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            LegPlayer1.ForeColor = SystemColors.ControlLightLight;
            LegPlayer1.Location = new Point(6, 15);
            LegPlayer1.Name = "LegPlayer1";
            LegPlayer1.Size = new Size(80, 60);
            LegPlayer1.TabIndex = 0;
            LegPlayer1.Text = "0";
            LegPlayer1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PlayerOne
            // 
            PlayerOne.BackColor = Color.Transparent;
            PlayerOne.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            PlayerOne.Location = new Point(36, 11);
            PlayerOne.Name = "PlayerOne";
            PlayerOne.Size = new Size(358, 65);
            PlayerOne.TabIndex = 3;
            PlayerOne.Text = "První";
            // 
            // PlayerTwo
            // 
            PlayerTwo.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            PlayerTwo.Location = new Point(36, 86);
            PlayerTwo.Name = "PlayerTwo";
            PlayerTwo.Size = new Size(358, 65);
            PlayerTwo.TabIndex = 4;
            PlayerTwo.Text = "Druhý";
            // 
            // bPlayerTwo
            // 
            bPlayerTwo.Location = new Point(-11, 147);
            bPlayerTwo.Name = "bPlayerTwo";
            bPlayerTwo.Size = new Size(27, 50);
            bPlayerTwo.TabIndex = 6;
            bPlayerTwo.Tag = "2";
            bPlayerTwo.Text = "=";
            bPlayerTwo.UseVisualStyleBackColor = true;
            bPlayerTwo.Visible = false;
            bPlayerTwo.Click += B_Click;
            // 
            // bPlayerOne
            // 
            bPlayerOne.Location = new Point(-11, 75);
            bPlayerOne.Name = "bPlayerOne";
            bPlayerOne.Size = new Size(27, 50);
            bPlayerOne.TabIndex = 5;
            bPlayerOne.Tag = "1";
            bPlayerOne.Text = "=";
            bPlayerOne.UseVisualStyleBackColor = true;
            bPlayerOne.Visible = false;
            bPlayerOne.Click += B_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 76);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 7;
            label2.Text = "Ø:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 150);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 8;
            label4.Text = "Ø:";
            // 
            // AvgPlayer1
            // 
            AvgPlayer1.AutoSize = true;
            AvgPlayer1.Location = new Point(67, 76);
            AvgPlayer1.Name = "AvgPlayer1";
            AvgPlayer1.Size = new Size(28, 15);
            AvgPlayer1.TabIndex = 9;
            AvgPlayer1.Text = "0,00";
            // 
            // AvgPlayer2
            // 
            AvgPlayer2.AutoSize = true;
            AvgPlayer2.Location = new Point(67, 150);
            AvgPlayer2.Name = "AvgPlayer2";
            AvgPlayer2.Size = new Size(28, 15);
            AvgPlayer2.TabIndex = 10;
            AvgPlayer2.Text = "0,00";
            // 
            // CheckoutPlayer1
            // 
            CheckoutPlayer1.AutoSize = true;
            CheckoutPlayer1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            CheckoutPlayer1.Location = new Point(132, 76);
            CheckoutPlayer1.Name = "CheckoutPlayer1";
            CheckoutPlayer1.Size = new Size(10, 15);
            CheckoutPlayer1.TabIndex = 11;
            CheckoutPlayer1.Text = ".";
            // 
            // CheckoutPlayer2
            // 
            CheckoutPlayer2.AutoSize = true;
            CheckoutPlayer2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            CheckoutPlayer2.Location = new Point(132, 150);
            CheckoutPlayer2.Name = "CheckoutPlayer2";
            CheckoutPlayer2.Size = new Size(10, 15);
            CheckoutPlayer2.TabIndex = 12;
            CheckoutPlayer2.Text = ".";
            // 
            // PlayerThree
            // 
            PlayerThree.BackColor = Color.Transparent;
            PlayerThree.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            PlayerThree.Location = new Point(216, 11);
            PlayerThree.Name = "PlayerThree";
            PlayerThree.Size = new Size(182, 65);
            PlayerThree.TabIndex = 14;
            PlayerThree.Text = "Třetí";
            PlayerThree.Visible = false;
            // 
            // PlayerFour
            // 
            PlayerFour.BackColor = SystemColors.Control;
            PlayerFour.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            PlayerFour.Location = new Point(218, 86);
            PlayerFour.Name = "PlayerFour";
            PlayerFour.Size = new Size(182, 65);
            PlayerFour.TabIndex = 15;
            PlayerFour.Text = "Čtvrtý";
            PlayerFour.Visible = false;
            // 
            // p2
            // 
            p2.BackColor = Color.Transparent;
            p2.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            p2.Location = new Point(190, 11);
            p2.Name = "p2";
            p2.Size = new Size(38, 63);
            p2.TabIndex = 16;
            p2.Text = "+";
            p2.TextAlign = ContentAlignment.TopCenter;
            // 
            // p1
            // 
            p1.BackColor = Color.Transparent;
            p1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            p1.Location = new Point(190, 85);
            p1.Name = "p1";
            p1.Size = new Size(38, 63);
            p1.TabIndex = 17;
            p1.Text = "+";
            p1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Control;
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(CheckoutPlayer1);
            panel4.Controls.Add(AvgPlayer1);
            panel4.Controls.Add(p1);
            panel4.Controls.Add(AvgPlayer2);
            panel4.Controls.Add(p2);
            panel4.Controls.Add(CheckoutPlayer2);
            panel4.Controls.Add(PlayerFour);
            panel4.Controls.Add(PlayerThree);
            panel4.Controls.Add(PlayerOne);
            panel4.Controls.Add(PlayerTwo);
            panel4.Location = new Point(0, 49);
            panel4.Name = "panel4";
            panel4.Size = new Size(515, 224);
            panel4.TabIndex = 18;
            // 
            // pointer
            // 
            pointer.BackColor = Color.DarkRed;
            pointer.Controls.Add(label5);
            pointer.Location = new Point(711, 61);
            pointer.Name = "pointer";
            pointer.Size = new Size(61, 72);
            pointer.TabIndex = 19;
            pointer.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlLight;
            label5.Location = new Point(0, -1);
            label5.Name = "label5";
            label5.Size = new Size(62, 65);
            label5.TabIndex = 0;
            label5.Text = "<";
            // 
            // DuelGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pointer);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(bPlayerTwo);
            Controls.Add(bPlayerOne);
            Controls.Add(panel4);
            Name = "DuelGame";
            Size = new Size(772, 275);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            pointer.ResumeLayout(false);
            pointer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label firstTo;
        private Label label3;
        private Label PlayerOne;
        private Label PlayerTwo;
        private Label LegPlayer2;
        private Label LegPlayer1;
        private Label ScorePlayer2;
        private TextBox thrownPlayer1;
        private TextBox thrownPlayer2;
        private Button bPlayerTwo;
        private Button bPlayerOne;
        private Label label2;
        private Label label4;
        private Label AvgPlayer1;
        private Label AvgPlayer2;
        private Label CheckoutPlayer1;
        private Label CheckoutPlayer2;
        private Panel panel3;
        private Label ScorePlayer1;
        private Label WinnerLabel;
        private Label PlayerThree;
        private Label PlayerFour;
        private Label p2;
        private Label p1;
        private Label l_sets;
        private Label SetPlayer2;
        private Label SetPlayer1;
        private Panel panel4;
        private Panel pointer;
        private Label label5;
    }
}
