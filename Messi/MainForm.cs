using Sunny.UI;
using System.Reflection;
using System.Windows.Forms;

namespace Messi
{
    public partial class MainForm : UIForm
    {
        private readonly Startup serve = new();
        public MainForm()
        {
            InitializeComponent();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            serve.Start();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            serve.Stop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                notifyIcon1.ShowBalloonTip(3000, "Barcode Printing Service", "The program is minimized to run in the system tray", ToolTipIcon.Info);
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void PrinterStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serve.CheckPrinter())
            {
                string status = serve.ReadDataFmUSB();
                MessageBox.Show(status, "Printer Status");
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to stop and quit?", "Notice", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}