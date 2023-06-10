using Domain;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace šipky_Forms
{
    public partial class Update : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        public event OnClose OnClose;
        private bool _isDownloading = false;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CP_NOCLOSE_BUTTON;
                return cp;
            }
        }

        public Update()
        {
            InitializeComponent();
        }

        private async void Update_Load(object sender, EventArgs e)
        {
            var desc = await GithubIntegration.GetLatestRelease();
            if (desc != null)
                changelog.Text = desc;
        }

        private void C_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarDownload.Value = e.ProgressPercentage;
            ldownload.Text = $"{e.BytesReceived / 1024 / 1024}MB / {e.TotalBytesToReceive / 1024 / 1024}MB";
        }

        private async void b_download_Click(object sender, EventArgs e)
        {
            changelog.Visible = false;
            b_download.Enabled = false;
            b_later.Enabled = false;
            _isDownloading = true;
            this.Icon = Properties.Resources.update_progress;

            var c = new WebClient();
            c.DownloadProgressChanged += C_DownloadProgressChanged;

            var filePath = Path.Combine(Path.GetTempPath(), "šipky.msi");
            try
            {
                await c.DownloadFileTaskAsync("https://github.com/maty5302/Darts-Winform/releases/latest/download/sipky.msi",filePath);

                var processInfo = new ProcessStartInfo()
                {
                    FileName = "msiexec.exe",
                    Arguments = $"/i \"{filePath}\"",
                    UseShellExecute = false,
                };

                Process.Start(processInfo);
                this.OnClose?.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void b_later_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void onmyown_Click(object sender, EventArgs e)
        {
            if (_isDownloading)
            {
				if (MessageBox.Show("Opravdu chcete aktualizaci stáhnout ručně? Zrušíte tímto již spuštěnou aktualizaci.", "Aktualizovat ručně?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
					return;
			}
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/maty5302/Darts-Winform/releases/",
                UseShellExecute = true
            };
            Process.Start(psi);
            this.Close();
        }
    }
}
