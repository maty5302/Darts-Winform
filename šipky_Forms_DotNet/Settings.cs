using šipky_Forms.Database;
using šipky_Forms_DotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace šipky_Forms
{
	public delegate void OnClose();

	public partial class Settings : Form
	{
		public string path = "";
		public Image BackroundImage1;
		Panel[] panels;
		Panel[] showColorPanel = new Panel[10];
		Color[] colorsPanels = new Color[10];
		string[] names = new string[10];
		public event OnClose OnCloseEvent;

		private void GenerateTextBoxs()
		{
			for (int i = 0; i < 10; i++)
			{
				TextBox t = new TextBox();
				t.Size = new Size(100, 20);
				t.Location = new Point(46, 28 + i * 28);
				t.Parent = changeNamesGroup;
				t.Tag = i;
				t.KeyDown += T_KeyDown;
				t.KeyUp += T_KeyUp;

				Panel p = new Panel();
				p.Size = new Size(25, 25);
				p.Location = new Point(237, 28 + i * 28);
				p.Parent = changeNamesGroup;
				p.BackColor = panels[i].BackColor;
				p.Tag = i;
				showColorPanel[i] = p;

				Button b = new Button();
				b.Size = new Size(80, 25);
				b.Location = new Point(152, 28 + i * 28);
				b.Parent = changeNamesGroup;
				b.Text = "Barva hráče";
				b.Tag = i;
				b.Click += B_Click;

				Label l = new Label();
				l.Text = "Hráč " + i + ":";
				l.Location = new Point(2, 28 + i * 28);
				l.Parent = changeNamesGroup;

			}
		}

		private void T_KeyUp(object? sender, KeyEventArgs e)
		{
			if (sender != null)
				names[(int)((TextBox)sender).Tag] = ((TextBox)sender).Text;
		}


		private void B_Click(object? sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				if (sender != null)
					showColorPanel[(int)((Button)sender).Tag].BackColor = colorsPanels[(int)((Button)sender).Tag] = colorDialog1.Color;
			}
		}

		private void T_KeyDown(object? sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (sender != null)
					saveButton_Click(sender, e);
			}
		}

		public Settings(Panel[] p, Image background, string path)
		{
			this.path = path;
			BackroundImage1 = background;
			panels = p;
			InitializeComponent();
			GenerateTextBoxs();
			PictureOfBackround.Image = BackroundImage1;
		}

		private void Settings_Load(object sender, EventArgs e)
		{
			int transparency = trackTransparency.Value;
			for (int i = 0; i < 10; i++)
			{
				colorsPanels[i] = Color.FromArgb(transparency, showColorPanel[i].BackColor);
				if (String.IsNullOrEmpty(names[i]))
					names[i] = panels[i].Controls[2].Text;
			}
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			int transparency = trackTransparency.Value;
			for (int i = 0; i < 10; i++)
			{
				if (!colorsPanels[i].IsEmpty)
					panels[i].BackColor = colorsPanels[i];
				if (!String.IsNullOrEmpty(names[i]))
					panels[i].Controls[2].Text = names[i];
				if (check_transparency.Checked)
					panels[i].BackColor = Color.FromArgb(transparency, panels[i].BackColor);
				else
					panels[i].BackColor = Color.FromArgb(255, panels[i].BackColor);
			}
			OnCloseEvent?.Invoke();
			GC.Collect();
			this.Close();
		}

		private void CustomWallpaper_Click(object sender, EventArgs e)
		{
			openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				path = openFileDialog1.FileName;
				BackroundImage1 = PictureOfBackround.Image = new Bitmap(openFileDialog1.FileName);
			}
		}

		private void SetDefault_Click(object sender, EventArgs e)
		{
			BackroundImage1 = PictureOfBackround.Image = Properties.Resources.darts_3;
		}

		private void Settings_FormClosing(object sender, FormClosingEventArgs e)
		{
			openFileDialog1.Dispose();
		}

		private void trackTransparency_ValueChanged(object sender, EventArgs e)
		{
			check_transparency.Checked = true;
		}

		private void b_default_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 10; i++)
			{
				names[i] = "Hráč " + i;
				showColorPanel[i].BackColor = colorsPanels[i] = Color.FromArgb(255, Color.ForestGreen);
			}
			BackroundImage1 = PictureOfBackround.Image = Properties.Resources.darts_3;
			check_transparency.Checked = false;
		}

		private void b_save_Click(object sender, EventArgs e)
		{
			Settings_Load(sender, e);
			var db = new DbSipky.MyDatabase();
			Load_Settings save = new Load_Settings(false);
			save.OnClose += () =>
			{
				UserSettings user = new UserSettings();
				user.Name = save.name;
				user.PicturePath = path;
				user.muteSounds = false; // dodelat
				user.panels = new List<Domain.Settings.PlayerPanels>();
				for (int i = 0; i < 10; i++)
					user.panels.Add(new Domain.Settings.PlayerPanels() { Name = names[i], BackColor = colorsPanels[i] });
				db.UserSettings.Add(user);
				db.SaveChanges();
			};
			save.ShowDialog();
		}

		private void b_load_Click(object sender, EventArgs e)
		{
			Load_Settings load = new Load_Settings(true);
			load.OnClose+=() =>
			{
				path = load.s.PicturePath;
				if (!String.IsNullOrEmpty(path))
					BackroundImage1 = PictureOfBackround.Image = new Bitmap(path);
				for (int i = 0; i < load.s.panels.Count; i++)
				{
					names[i] = load.s.panels[i].Name;
					showColorPanel[i].BackColor = colorsPanels[i] = load.s.panels[i].BackColor;
					if (colorsPanels[i].A != 255)
					{
						check_transparency.Checked = true;
						trackTransparency.Value = colorsPanels[i].A;
					}
					else
						check_transparency.Checked = false;
				}
			};
			load.ShowDialog();
		}
	}
}
