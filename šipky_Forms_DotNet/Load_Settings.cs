using Domain.Settings;
using šipky_Forms.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace šipky_Forms
{
    public partial class Load_Settings : Form
    {
        private List<UserSettings> users = new List<UserSettings>();       
        public UserSettings s = new UserSettings();
        private bool LoadSave = true;
        private int index = -1;
        public string name = "test";

        public event OnClose OnClose;

        public Load_Settings(bool isLoad)
        {
            LoadSave = isLoad;
            InitializeComponent();
        }

        private void Load_Chb()
        {
            chb_profiles.Items.Clear();
            var db = new DbSipky.MyDatabase();
            foreach (var item in db.UserSettings)
            {
                chb_profiles.Items.Add(item.Name);
                users.Add(item);
            }
        }

        private void Load_Settings_Load(object sender, EventArgs e)
        {
            if (LoadSave)
            {
                Load_Chb();
                this.Size = new Size(430, 90);
                this.Text = label1.Text = "Vyber profil:";
                chb_profiles.Enabled = true;
                b_load.Enabled = true;
                b_delete.Enabled = true;
                b_save.Visible = false;
                tb_nameofsave.Enabled = false;
            }
            else
            {
                this.Size = new Size(365, 90);
                chb_profiles.Visible = false;
                b_load.Visible = false;
                this.Text = "Uložit profil:";
                label1.Text = "Název profilu:";
                b_delete.Visible = false;
                b_save.Visible = true;
                tb_nameofsave.Enabled = true;
            }

        }

        private void b_load_Click(object sender, EventArgs e)
        {
            var db = new DbSipky.MyDatabase();
            if (index != -1)
            {
                s = users[index];
                s.panels = db.PlayerPanels.Where(x => x.UserSettingsId == s.Id).ToList();
                OnClose?.Invoke();
                this.Close();
            }
        }

        private void chb_profiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = chb_profiles.SelectedIndex;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                var db = new DbSipky.MyDatabase();
                s = users[index];
                s.panels = db.PlayerPanels.Where(x => x.UserSettingsId == s.Id).ToList();
                foreach (var item in s.panels)
                {
                    db.PlayerPanels.Remove(item);
                }
                chb_profiles.Text = "";
                db.UserSettings.Remove(s);
                db.SaveChanges();
                Load_Chb();
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            name = tb_nameofsave.Text;
            OnClose?.Invoke();
            this.Close();
        }
    }
}
