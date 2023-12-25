namespace šipky_Forms
{
	partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            applyButton = new Button();
            colorDialog1 = new ColorDialog();
            changeNamesGroup = new GroupBox();
            label1 = new Label();
            check_transparency = new CheckBox();
            trackTransparency = new TrackBar();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            SetDefault = new Button();
            CustomWallpaper = new Button();
            PictureOfBackround = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            b_save = new Button();
            b_default = new Button();
            b_load = new Button();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackTransparency).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureOfBackround).BeginInit();
            SuspendLayout();
            // 
            // applyButton
            // 
            applyButton.Location = new Point(474, 366);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(75, 23);
            applyButton.TabIndex = 0;
            applyButton.Text = "Použít";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += saveButton_Click;
            // 
            // changeNamesGroup
            // 
            changeNamesGroup.Location = new Point(12, 41);
            changeNamesGroup.Name = "changeNamesGroup";
            changeNamesGroup.Size = new Size(268, 324);
            changeNamesGroup.TabIndex = 1;
            changeNamesGroup.TabStop = false;
            changeNamesGroup.Text = "Změna jmen a barev";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(174, 9);
            label1.Name = "label1";
            label1.Size = new Size(210, 30);
            label1.TabIndex = 2;
            label1.Text = "Nastavení šipek";
            // 
            // check_transparency
            // 
            check_transparency.AutoSize = true;
            check_transparency.Location = new Point(151, 38);
            check_transparency.Name = "check_transparency";
            check_transparency.RightToLeft = RightToLeft.Yes;
            check_transparency.Size = new Size(106, 19);
            check_transparency.TabIndex = 3;
            check_transparency.Text = "Povolit/zakázat";
            check_transparency.UseVisualStyleBackColor = true;
            // 
            // trackTransparency
            // 
            trackTransparency.LargeChange = 50;
            trackTransparency.Location = new Point(6, 33);
            trackTransparency.Maximum = 204;
            trackTransparency.Minimum = 102;
            trackTransparency.Name = "trackTransparency";
            trackTransparency.Size = new Size(135, 45);
            trackTransparency.SmallChange = 20;
            trackTransparency.TabIndex = 4;
            trackTransparency.TabStop = false;
            trackTransparency.Value = 150;
            trackTransparency.ValueChanged += trackTransparency_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(trackTransparency);
            groupBox1.Controls.Add(check_transparency);
            groupBox1.Location = new Point(286, 287);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(264, 78);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Průhlednost dlaždic";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(SetDefault);
            groupBox2.Controls.Add(CustomWallpaper);
            groupBox2.Controls.Add(PictureOfBackround);
            groupBox2.Location = new Point(286, 41);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(264, 240);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tapeta";
            // 
            // SetDefault
            // 
            SetDefault.Location = new Point(44, 181);
            SetDefault.Name = "SetDefault";
            SetDefault.Size = new Size(75, 23);
            SetDefault.TabIndex = 2;
            SetDefault.Text = "Výchozí";
            SetDefault.UseVisualStyleBackColor = true;
            SetDefault.Click += SetDefault_Click;
            // 
            // CustomWallpaper
            // 
            CustomWallpaper.Location = new Point(141, 181);
            CustomWallpaper.Name = "CustomWallpaper";
            CustomWallpaper.Size = new Size(75, 23);
            CustomWallpaper.TabIndex = 1;
            CustomWallpaper.Text = "Vlastní";
            CustomWallpaper.UseVisualStyleBackColor = true;
            CustomWallpaper.Click += CustomWallpaper_Click;
            // 
            // PictureOfBackround
            // 
            PictureOfBackround.Image = (Image)resources.GetObject("PictureOfBackround.Image");
            PictureOfBackround.Location = new Point(29, 29);
            PictureOfBackround.Name = "PictureOfBackround";
            PictureOfBackround.Size = new Size(206, 137);
            PictureOfBackround.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureOfBackround.TabIndex = 0;
            PictureOfBackround.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            // 
            // b_save
            // 
            b_save.Location = new Point(396, 366);
            b_save.Name = "b_save";
            b_save.Size = new Size(75, 23);
            b_save.TabIndex = 7;
            b_save.Text = "Uložit";
            b_save.UseVisualStyleBackColor = true;
            b_save.Click += b_save_Click;
            // 
            // b_default
            // 
            b_default.Location = new Point(239, 366);
            b_default.Name = "b_default";
            b_default.Size = new Size(75, 23);
            b_default.TabIndex = 8;
            b_default.Text = "Výchozí";
            b_default.UseVisualStyleBackColor = true;
            b_default.Click += b_default_Click;
            // 
            // b_load
            // 
            b_load.Location = new Point(318, 366);
            b_load.Name = "b_load";
            b_load.Size = new Size(75, 23);
            b_load.TabIndex = 9;
            b_load.Text = "Načíst";
            b_load.UseVisualStyleBackColor = true;
            b_load.Click += b_load_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(5, 25);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 10;
            label2.Text = "40%";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(116, 25);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 11;
            label3.Text = "80%";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(555, 392);
            Controls.Add(b_load);
            Controls.Add(b_default);
            Controls.Add(b_save);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(changeNamesGroup);
            Controls.Add(applyButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Settings";
            Text = "Nastavení";
            FormClosing += Settings_FormClosing;
            ((System.ComponentModel.ISupportInitialize)trackTransparency).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureOfBackround).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button applyButton;
		private ColorDialog colorDialog1;
		private GroupBox changeNamesGroup;
		private Label label1;
		private CheckBox check_transparency;
		private TrackBar trackTransparency;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private OpenFileDialog openFileDialog1;
		private Button CustomWallpaper;
		private PictureBox PictureOfBackround;
		private Button SetDefault;
		private Button b_save;
		private Button b_default;
		private Button b_load;
        private Label label3;
        private Label label2;
    }
}