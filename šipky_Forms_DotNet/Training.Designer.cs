namespace šipky_Forms
{
    partial class Training
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkoutDarts = new System.Windows.Forms.RadioButton();
            this.resetTraining = new System.Windows.Forms.Button();
            this.startTraining = new System.Windows.Forms.Button();
            this.randomDarts = new System.Windows.Forms.RadioButton();
            this.tripleDarts = new System.Windows.Forms.RadioButton();
            this.doubleDarts = new System.Windows.Forms.RadioButton();
            this.singleDarts = new System.Windows.Forms.RadioButton();
            this.showScore = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.totalFailed = new System.Windows.Forms.Label();
            this.totalDone = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 50);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(43, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trénink";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkoutDarts);
            this.groupBox1.Controls.Add(this.resetTraining);
            this.groupBox1.Controls.Add(this.startTraining);
            this.groupBox1.Controls.Add(this.randomDarts);
            this.groupBox1.Controls.Add(this.tripleDarts);
            this.groupBox1.Controls.Add(this.doubleDarts);
            this.groupBox1.Controls.Add(this.singleDarts);
            this.groupBox1.Location = new System.Drawing.Point(3, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 216);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Výběr obtížnosti a úrovně";
            // 
            // checkoutDarts
            // 
            this.checkoutDarts.AutoSize = true;
            this.checkoutDarts.Location = new System.Drawing.Point(25, 133);
            this.checkoutDarts.Name = "checkoutDarts";
            this.checkoutDarts.Size = new System.Drawing.Size(96, 19);
            this.checkoutDarts.TabIndex = 6;
            this.checkoutDarts.TabStop = true;
            this.checkoutDarts.Text = "Uzavření legu";
            this.checkoutDarts.UseVisualStyleBackColor = true;
            // 
            // resetTraining
            // 
            this.resetTraining.Enabled = false;
            this.resetTraining.Location = new System.Drawing.Point(37, 187);
            this.resetTraining.Name = "resetTraining";
            this.resetTraining.Size = new System.Drawing.Size(75, 23);
            this.resetTraining.TabIndex = 5;
            this.resetTraining.Text = "Reset";
            this.resetTraining.UseVisualStyleBackColor = true;
            this.resetTraining.Click += new System.EventHandler(this.resetTraining_Click);
            // 
            // startTraining
            // 
            this.startTraining.Location = new System.Drawing.Point(37, 158);
            this.startTraining.Name = "startTraining";
            this.startTraining.Size = new System.Drawing.Size(75, 23);
            this.startTraining.TabIndex = 4;
            this.startTraining.Text = "Start";
            this.startTraining.UseVisualStyleBackColor = true;
            this.startTraining.Click += new System.EventHandler(this.startTraining_Click);
            // 
            // randomDarts
            // 
            this.randomDarts.AutoSize = true;
            this.randomDarts.Location = new System.Drawing.Point(25, 108);
            this.randomDarts.Name = "randomDarts";
            this.randomDarts.Size = new System.Drawing.Size(120, 19);
            this.randomDarts.TabIndex = 3;
            this.randomDarts.TabStop = true;
            this.randomDarts.Text = "Náhodně všechny";
            this.randomDarts.UseVisualStyleBackColor = true;
            // 
            // tripleDarts
            // 
            this.tripleDarts.AutoSize = true;
            this.tripleDarts.Location = new System.Drawing.Point(25, 83);
            this.tripleDarts.Name = "tripleDarts";
            this.tripleDarts.Size = new System.Drawing.Size(83, 19);
            this.tripleDarts.TabIndex = 2;
            this.tripleDarts.TabStop = true;
            this.tripleDarts.Text = "Triple hody";
            this.tripleDarts.UseVisualStyleBackColor = true;
            // 
            // doubleDarts
            // 
            this.doubleDarts.AutoSize = true;
            this.doubleDarts.Location = new System.Drawing.Point(25, 58);
            this.doubleDarts.Name = "doubleDarts";
            this.doubleDarts.Size = new System.Drawing.Size(93, 19);
            this.doubleDarts.TabIndex = 1;
            this.doubleDarts.TabStop = true;
            this.doubleDarts.Text = "Double hody";
            this.doubleDarts.UseVisualStyleBackColor = true;
            // 
            // singleDarts
            // 
            this.singleDarts.AutoSize = true;
            this.singleDarts.Location = new System.Drawing.Point(25, 33);
            this.singleDarts.Name = "singleDarts";
            this.singleDarts.Size = new System.Drawing.Size(87, 19);
            this.singleDarts.TabIndex = 0;
            this.singleDarts.TabStop = true;
            this.singleDarts.Text = "Single hody";
            this.singleDarts.UseVisualStyleBackColor = true;
            // 
            // showScore
            // 
            this.showScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.showScore.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.showScore.Location = new System.Drawing.Point(195, 101);
            this.showScore.Name = "showScore";
            this.showScore.Size = new System.Drawing.Size(310, 82);
            this.showScore.TabIndex = 3;
            this.showScore.Text = "0";
            this.showScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(360, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Hozeno (další)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(242, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Nehozeno (další)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.totalFailed);
            this.groupBox2.Controls.Add(this.totalDone);
            this.groupBox2.Controls.Add(this.total);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(543, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 216);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistiky";
            // 
            // totalFailed
            // 
            this.totalFailed.AutoSize = true;
            this.totalFailed.Location = new System.Drawing.Point(97, 110);
            this.totalFailed.Name = "totalFailed";
            this.totalFailed.Size = new System.Drawing.Size(13, 15);
            this.totalFailed.TabIndex = 6;
            this.totalFailed.Text = "0";
            // 
            // totalDone
            // 
            this.totalDone.AutoSize = true;
            this.totalDone.Location = new System.Drawing.Point(97, 85);
            this.totalDone.Name = "totalDone";
            this.totalDone.Size = new System.Drawing.Size(13, 15);
            this.totalDone.TabIndex = 5;
            this.totalDone.Text = "0";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(97, 60);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(13, 15);
            this.total.TabIndex = 4;
            this.total.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nehozeno:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Hozeno:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Celkem: ";
            // 
            // Training
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.showScore);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Training";
            this.Size = new System.Drawing.Size(720, 275);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton randomDarts;
        private RadioButton tripleDarts;
        private RadioButton doubleDarts;
        private RadioButton singleDarts;
        private Button resetTraining;
        private Button startTraining;
        private Label showScore;
        private RadioButton checkoutDarts;
        private Button button1;
        private Button button2;
        private GroupBox groupBox2;
        private Label total;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label totalDone;
        private Label totalFailed;
    }
}
