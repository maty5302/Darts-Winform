namespace šipky_Forms
{
    partial class Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Update));
            progressBarDownload = new ProgressBar();
            label1 = new Label();
            ldownload = new Label();
            label2 = new Label();
            changelog = new RichTextBox();
            b_later = new Button();
            b_download = new Button();
            onmyown = new Button();
            SuspendLayout();
            // 
            // progressBarDownload
            // 
            progressBarDownload.Location = new Point(32, 37);
            progressBarDownload.Name = "progressBarDownload";
            progressBarDownload.Size = new Size(196, 42);
            progressBarDownload.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 19);
            label1.Name = "label1";
            label1.Size = new Size(152, 15);
            label1.TabIndex = 1;
            label1.Text = "Stahuje se aktualizace Šipek";
            // 
            // ldownload
            // 
            ldownload.AutoSize = true;
            ldownload.Location = new Point(243, 51);
            ldownload.Name = "ldownload";
            ldownload.Size = new Size(66, 15);
            ldownload.TabIndex = 2;
            ldownload.Text = "0MB / 0MB";
            // 
            // label2
            // 
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(326, 25);
            label2.TabIndex = 3;
            label2.Text = "Je k dispozici aktualizace";
            // 
            // changelog
            // 
            changelog.Location = new Point(12, 27);
            changelog.Name = "changelog";
            changelog.ReadOnly = true;
            changelog.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            changelog.Size = new Size(326, 66);
            changelog.TabIndex = 4;
            changelog.Text = "";
            // 
            // b_later
            // 
            b_later.Location = new Point(63, 99);
            b_later.Name = "b_later";
            b_later.Size = new Size(75, 23);
            b_later.TabIndex = 5;
            b_later.Text = "Později";
            b_later.UseVisualStyleBackColor = true;
            b_later.Click += b_later_Click;
            // 
            // b_download
            // 
            b_download.Location = new Point(225, 99);
            b_download.Name = "b_download";
            b_download.Size = new Size(75, 23);
            b_download.TabIndex = 6;
            b_download.Text = "Stáhnout";
            b_download.UseVisualStyleBackColor = true;
            b_download.Click += b_download_Click;
            // 
            // onmyown
            // 
            onmyown.Location = new Point(144, 99);
            onmyown.Name = "onmyown";
            onmyown.Size = new Size(75, 23);
            onmyown.TabIndex = 7;
            onmyown.Text = "Ručně";
            onmyown.UseVisualStyleBackColor = true;
            onmyown.Click += onmyown_Click;
            // 
            // Update
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 132);
            Controls.Add(onmyown);
            Controls.Add(b_download);
            Controls.Add(b_later);
            Controls.Add(changelog);
            Controls.Add(label2);
            Controls.Add(ldownload);
            Controls.Add(label1);
            Controls.Add(progressBarDownload);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Update";
            Text = "Aktualizace..";
            Load += Update_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBarDownload;
        private Label label1;
        private Label ldownload;
        private Label label2;
        private RichTextBox changelog;
        private Button b_later;
        private Button b_download;
        private Button onmyown;
    }
}