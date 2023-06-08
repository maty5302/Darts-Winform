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
            var fileUrl = "https://onedrive.live.com/download?cid=033D38AA67032599&resid=33D38AA67032599%21247250&authkey=ADAE3PTz1OGlq4I";
            var cloudVersion = await OnedriveDownload.GetTextFromOneDriveFile(fileUrl);
            if (cloudVersion != null)
            {
                changelog.Text = cloudVersion;
            }
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
            this.Icon = Properties.Resources.update_progress;

            var c = new WebClient();
            c.DownloadProgressChanged += C_DownloadProgressChanged;

            var filePath = Path.Combine(Path.GetTempPath(), "šipky.msi");
            try
            {
                await c.DownloadFileTaskAsync("https://onedrive.live.com/download?cid=033D38AA67032599&resid=33D38AA67032599%21247232&authkey=APULObFCyMQ-1hY", filePath);

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
            var psi = new ProcessStartInfo
            {
                FileName = "https://1drv.ms/u/s!ApklA2eqOD0Dj4s-WMQVrBPwqkSrAQ",
                UseShellExecute = true
            };
            Process.Start(psi);
        }
    }
}
