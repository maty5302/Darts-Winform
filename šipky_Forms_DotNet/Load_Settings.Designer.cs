namespace šipky_Forms
{
    partial class Load_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Load_Settings));
            b_load = new Button();
            chb_profiles = new ComboBox();
            label1 = new Label();
            b_delete = new Button();
            b_save = new Button();
            tb_nameofsave = new TextBox();
            SuspendLayout();
            // 
            // b_load
            // 
            b_load.Location = new Point(234, 13);
            b_load.Name = "b_load";
            b_load.Size = new Size(75, 23);
            b_load.TabIndex = 0;
            b_load.Text = "Vybrat";
            b_load.UseVisualStyleBackColor = true;
            b_load.Click += b_load_Click;
            // 
            // chb_profiles
            // 
            chb_profiles.DropDownStyle = ComboBoxStyle.DropDownList;
            chb_profiles.FormattingEnabled = true;
            chb_profiles.Location = new Point(107, 13);
            chb_profiles.Name = "chb_profiles";
            chb_profiles.Size = new Size(121, 23);
            chb_profiles.TabIndex = 1;
            chb_profiles.SelectedIndexChanged += chb_profiles_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Location = new Point(27, 16);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // b_delete
            // 
            b_delete.Location = new Point(315, 13);
            b_delete.Name = "b_delete";
            b_delete.Size = new Size(75, 23);
            b_delete.TabIndex = 3;
            b_delete.Text = "Smazat";
            b_delete.UseVisualStyleBackColor = true;
            b_delete.Click += b_delete_Click;
            // 
            // b_save
            // 
            b_save.Location = new Point(234, 13);
            b_save.Name = "b_save";
            b_save.Size = new Size(75, 23);
            b_save.TabIndex = 4;
            b_save.Text = "Uložit";
            b_save.UseVisualStyleBackColor = true;
            b_save.Click += b_save_Click;
            // 
            // tb_nameofsave
            // 
            tb_nameofsave.Location = new Point(107, 13);
            tb_nameofsave.Name = "tb_nameofsave";
            tb_nameofsave.Size = new Size(121, 23);
            tb_nameofsave.TabIndex = 5;
            // 
            // Load_Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 51);
            Controls.Add(b_delete);
            Controls.Add(label1);
            Controls.Add(chb_profiles);
            Controls.Add(b_load);
            Controls.Add(tb_nameofsave);
            Controls.Add(b_save);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Load_Settings";
            Text = "Load_Settings";
            Load += Load_Settings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button b_load;
        private ComboBox chb_profiles;
        private Label label1;
        private Button b_delete;
        private Button b_save;
        private TextBox tb_nameofsave;
    }
}