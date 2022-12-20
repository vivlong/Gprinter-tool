using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Syrinx
{
    public partial class MainForm : UIForm
    {
        private readonly Printer printer = new Printer();
        private readonly Startup serve;

        public MainForm()
        {
            InitializeComponent();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            uiLedBulb1.Color = Color.Gray;
            serve = new Startup(printer);
            BtnGetPrinter_Click(null, null);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            serve.Start();
            uiLedBulb1.Color = Color.PaleGreen;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            serve.Stop();
            uiLedBulb1.Color = Color.LightCoral;
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
            if (printer.CheckPrinter())
            {
                string status = printer.ReadDataFmUSB();
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

        private void BtnGetPrinter_Click(object sender, EventArgs e)
        {
            if (printer.CheckPrinter())
            {
                List<string> DevicePathList = printer.GetPrinterList();
                int rowIndex = printer.GetPrinter();
                uiDataGridView1.Rows.Clear();
                foreach (string dp in DevicePathList)
                {
                    int index = DevicePathList.IndexOf(dp);
                    string[] dps = dp.Split('#');
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell()
                    {
                        Value = dps[1]
                    };
                    row.Cells.Add(textboxcell);
                    DataGridViewButtonCell buttoncell = new DataGridViewButtonCell()
                    {
                        Value = (rowIndex == index ? "current" : "...")
                    };
                    row.Cells.Add(buttoncell);
                    uiDataGridView1.Rows.Add(row);
                }
            }
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Visible = true;
                WindowState = FormWindowState.Normal;
                Activate();
            }
        }

        private void BtnPrintTestBarcode_Click(object sender, EventArgs e)
        {
            if (printer.CheckPrinter())
            {
                printer.StartPrint("DEMO");
            }
        }

        private void BtnResetPrinter_Click(object sender, EventArgs e)
        {
            if (printer.CheckPrinter())
            {
                printer.ResetPrinter();
            }
        }

        private void UiDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1)
            {
                if (this.uiDataGridView1.Columns[e.ColumnIndex].Name == "operation")
                {
                    printer.SetPrinter(e.RowIndex);
                    MessageBox.Show("Switch to selected printer", "Printer");
                }
            }
        }
    }
}
