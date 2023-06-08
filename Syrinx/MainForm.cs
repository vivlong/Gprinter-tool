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
        delegate void AsynUpdateUI(bool bln);

        public MainForm()
        {
            InitializeComponent();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            uiLedBulbLocal.Color = Color.Gray;
            uiDataGridView1.Rows.Clear();
            serve = new Startup(printer);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            BtnGetPrinter_Click(null, null);
            if (printer.CheckPrinter())
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                serve.Start();
                uiLedBulbLocal.Color = Color.PaleGreen;
                //
                serve.UpdateUIDelegate += UpdataUIStatus;
                Thread thread = new Thread(new ThreadStart(serve.Reg));
                thread.Start();
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            serve.Stop();
            uiLedBulbLocal.Color = Color.LightCoral;
        }

        private void UpdataUIStatus(bool bln)
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsynUpdateUI(delegate (bool b)
                {
                    // TODO
                    // uiLedBulbLocal.Color = Color.PaleGreen;
                }), bln);
            }
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
                    DataGridViewTextBoxCell cellPort = new DataGridViewTextBoxCell()
                    {
                        Value = dps[1]
                    };
                    row.Cells.Add(cellPort);
                    DataGridViewTextBoxCell cellSize = new DataGridViewTextBoxCell()
                    {
                        Value = "65mm x 15mm"
                    };
                    row.Cells.Add(cellSize);
                    DataGridViewButtonCell cellOp= new DataGridViewButtonCell()
                    {
                        Value = (rowIndex == index ? "current" : "...")
                    };
                    row.Cells.Add(cellOp);
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

        private void BtnResetPrinter1565_Click(object sender, EventArgs e)
        {
            if (printer.CheckPrinter())
            {
                printer.ResetPrinter(65, 15);
                int rowIndex = printer.GetPrinter();
                uiDataGridView1.Rows[rowIndex].Cells[1].Value = "60mm x 15mm";
                MessageBox.Show("Switch to 65mm x 15mm", "Printer");
            }
        }

        private void BtnResetPrinter8060_Click(object sender, EventArgs e)
        {
            if (printer.CheckPrinter())
            {
                printer.ResetPrinter(60, 80);
                int rowIndex = printer.GetPrinter();
                uiDataGridView1.Rows[rowIndex].Cells[1].Value = "60mm x 80mm";
                MessageBox.Show("Switch to 60mm x 80mm", "Printer");
            }
        }

        private void BtnResetPrinter100120_Click(object sender, EventArgs e)
        {
            if (printer.CheckPrinter())
            {
                printer.ResetPrinter(120, 100);
                int rowIndex = printer.GetPrinter();
                uiDataGridView1.Rows[rowIndex].Cells[1].Value = "120mm x 100mm";
                MessageBox.Show("Switch to 120mm x 100mm", "Printer");
            }
        }

        private void BtnResetPrinter100100_Click(object sender, EventArgs e)
        {
            if (printer.CheckPrinter())
            {
                printer.ResetPrinter(100, 100);
                int rowIndex = printer.GetPrinter();
                uiDataGridView1.Rows[rowIndex].Cells[1].Value = "100mm x 100mm";
                MessageBox.Show("Switch to 100mm x 100mm", "Printer");
            }
        }
    }
}
