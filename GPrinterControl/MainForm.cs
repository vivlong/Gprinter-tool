using System;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPrinterControl
{
				public partial class MainForm : Form
    {
        private GPrinterHttp.Printer printer = new GPrinterHttp.Printer();
        private Service service = new Service();

        public MainForm()
								{
												InitializeComponent();
            btnServiceStart.Enabled = true;
            btnServiceStop.Enabled = false;
            StatusChangeHandle();
        }

        private void StatusChangeHandle()
        {
            if (service.IsServiceExisted())
            {
                ServiceControllerStatus status = service.GetServiceStatus();
                if (status == ServiceControllerStatus.Running)
                {
                    pictureBox1.Image = Properties.Resources.icon_success;
                }
                else if (status == ServiceControllerStatus.Stopped)
                {
                    pictureBox1.Image = Properties.Resources.icon_warn;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.icon_info;
                }
            }
        }

        private async void btnServiceStart_Click(object sender, EventArgs e)
        {
            btnServiceStart.Enabled = false;
            btnServiceStop.Enabled = true;
            await Task.Run(() => { service.StartService(); });
            Thread.Sleep(1000);
            StatusChangeHandle();
        }

        private async void btnServiceStop_Click(object sender, EventArgs e)
        {
            btnServiceStart.Enabled = true;
            btnServiceStop.Enabled = false;
            await Task.Run(() => { service.StopService(); });
												Thread.Sleep(1000);
												StatusChangeHandle();
        }

        private void btnTestUSB_Click(object sender, EventArgs e)
        {
												if (printer.CheckPrinter())
            {
                printer.StartPrint("YS22RDA9R03K0001");
												}
												else
												{
                MessageBox.Show("未检测到打印机", "连接打印机");
            }
        }

								private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
								{
												if (e.Button == MouseButtons.Left)
												{
																Visible = true;
																WindowState = FormWindowState.Normal;
																Activate();
												}
								}

								private void Form1_FormClosing(object sender, FormClosingEventArgs e)
								{
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                notifyIcon1.ShowBalloonTip(3000, "GP条码打印服务", "程序已最小化到系统托盘运行", ToolTipIcon.Info);
                Hide();
                notifyIcon1.Visible = true;
            }
        }

								private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
								{
            DialogResult result = MessageBox.Show("是否退出", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

								private void PrinterStatusToolStripMenuItem_Click(object sender, EventArgs e)
								{
            if (printer.CheckPrinter())
            {
                string status = printer.ReadDataFmUSB();
                MessageBox.Show(status, "打印机状态");
            }
        }
				}
}
