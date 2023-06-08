using System.Windows.Forms;

namespace Syrinx
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiLedBulbLocal = new Sunny.UI.UILedBulb();
            this.btnStop = new Sunny.UI.UISymbolButton();
            this.btnStart = new Sunny.UI.UISymbolButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printerStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.BtnResetPrinter100100 = new Sunny.UI.UIButton();
            this.BtnResetPrinter100120 = new Sunny.UI.UIButton();
            this.BtnResetPrinter8060 = new Sunny.UI.UIButton();
            this.BtnResetPrinter1565 = new Sunny.UI.UIButton();
            this.btnPrintTestBarcode = new Sunny.UI.UIButton();
            this.btnGetPrinter = new Sunny.UI.UIButton();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.portNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operation = new System.Windows.Forms.DataGridViewButtonColumn();
            this.uiGroupBox1.SuspendLayout();
            this.notifyMenu.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiLedBulbLocal);
            this.uiGroupBox1.Controls.Add(this.btnStop);
            this.uiGroupBox1.Controls.Add(this.btnStart);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 40);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(454, 79);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Service";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLedBulbLocal
            // 
            this.uiLedBulbLocal.Color = System.Drawing.Color.Gray;
            this.uiLedBulbLocal.Location = new System.Drawing.Point(23, 31);
            this.uiLedBulbLocal.Name = "uiLedBulbLocal";
            this.uiLedBulbLocal.Size = new System.Drawing.Size(32, 32);
            this.uiLedBulbLocal.TabIndex = 8;
            this.uiLedBulbLocal.Text = "uiLedBulb1";
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnStop.Location = new System.Drawing.Point(350, 31);
            this.btnStop.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(92, 36);
            this.btnStop.Symbol = 61517;
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnStart.Location = new System.Drawing.Point(128, 31);
            this.btnStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(92, 36);
            this.btnStart.Symbol = 61515;
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Barcode Printer Service";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printerStatusToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(154, 48);
            // 
            // printerStatusToolStripMenuItem
            // 
            this.printerStatusToolStripMenuItem.Name = "printerStatusToolStripMenuItem";
            this.printerStatusToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.printerStatusToolStripMenuItem.Text = "Printer Status";
            this.printerStatusToolStripMenuItem.Click += new System.EventHandler(this.PrinterStatusToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.BtnResetPrinter100100);
            this.uiGroupBox2.Controls.Add(this.BtnResetPrinter100120);
            this.uiGroupBox2.Controls.Add(this.BtnResetPrinter8060);
            this.uiGroupBox2.Controls.Add(this.BtnResetPrinter1565);
            this.uiGroupBox2.Controls.Add(this.btnPrintTestBarcode);
            this.uiGroupBox2.Controls.Add(this.btnGetPrinter);
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox2.Location = new System.Drawing.Point(5, 129);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(453, 147);
            this.uiGroupBox2.TabIndex = 1;
            this.uiGroupBox2.Text = "Printer";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnResetPrinter100100
            // 
            this.BtnResetPrinter100100.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnResetPrinter100100.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.BtnResetPrinter100100.Location = new System.Drawing.Point(238, 68);
            this.BtnResetPrinter100100.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnResetPrinter100100.Name = "BtnResetPrinter100100";
            this.BtnResetPrinter100100.Size = new System.Drawing.Size(203, 31);
            this.BtnResetPrinter100100.TabIndex = 6;
            this.BtnResetPrinter100100.Text = "Reset 100x100  Label";
            this.BtnResetPrinter100100.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnResetPrinter100100.Click += new System.EventHandler(this.BtnResetPrinter100100_Click);
            // 
            // BtnResetPrinter100120
            // 
            this.BtnResetPrinter100120.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnResetPrinter100120.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.BtnResetPrinter100120.Location = new System.Drawing.Point(238, 105);
            this.BtnResetPrinter100120.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnResetPrinter100120.Name = "BtnResetPrinter100120";
            this.BtnResetPrinter100120.Size = new System.Drawing.Size(203, 31);
            this.BtnResetPrinter100120.TabIndex = 5;
            this.BtnResetPrinter100120.Text = "Reset 100x120  Label";
            this.BtnResetPrinter100120.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnResetPrinter100120.Click += new System.EventHandler(this.BtnResetPrinter100120_Click);
            // 
            // BtnResetPrinter8060
            // 
            this.BtnResetPrinter8060.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnResetPrinter8060.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.BtnResetPrinter8060.Location = new System.Drawing.Point(11, 105);
            this.BtnResetPrinter8060.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnResetPrinter8060.Name = "BtnResetPrinter8060";
            this.BtnResetPrinter8060.Size = new System.Drawing.Size(208, 31);
            this.BtnResetPrinter8060.TabIndex = 4;
            this.BtnResetPrinter8060.Text = "Reset 80x60  Label";
            this.BtnResetPrinter8060.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnResetPrinter8060.Click += new System.EventHandler(this.BtnResetPrinter8060_Click);
            // 
            // BtnResetPrinter1565
            // 
            this.BtnResetPrinter1565.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnResetPrinter1565.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.BtnResetPrinter1565.Location = new System.Drawing.Point(11, 68);
            this.BtnResetPrinter1565.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnResetPrinter1565.Name = "BtnResetPrinter1565";
            this.BtnResetPrinter1565.Size = new System.Drawing.Size(208, 31);
            this.BtnResetPrinter1565.TabIndex = 3;
            this.BtnResetPrinter1565.Text = "Reset 15x65  Barcode";
            this.BtnResetPrinter1565.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnResetPrinter1565.Click += new System.EventHandler(this.BtnResetPrinter1565_Click);
            // 
            // btnPrintTestBarcode
            // 
            this.btnPrintTestBarcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintTestBarcode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnPrintTestBarcode.Location = new System.Drawing.Point(238, 31);
            this.btnPrintTestBarcode.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPrintTestBarcode.Name = "btnPrintTestBarcode";
            this.btnPrintTestBarcode.Size = new System.Drawing.Size(203, 31);
            this.btnPrintTestBarcode.TabIndex = 1;
            this.btnPrintTestBarcode.Text = "Print Test Barcode";
            this.btnPrintTestBarcode.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrintTestBarcode.Click += new System.EventHandler(this.BtnPrintTestBarcode_Click);
            // 
            // btnGetPrinter
            // 
            this.btnGetPrinter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetPrinter.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnGetPrinter.Location = new System.Drawing.Point(11, 31);
            this.btnGetPrinter.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnGetPrinter.Name = "btnGetPrinter";
            this.btnGetPrinter.Size = new System.Drawing.Size(208, 31);
            this.btnGetPrinter.TabIndex = 0;
            this.btnGetPrinter.Text = "Get Printers";
            this.btnGetPrinter.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetPrinter.Click += new System.EventHandler(this.BtnGetPrinter_Click);
            // 
            // uiDataGridView1
            // 
            this.uiDataGridView1.AllowUserToAddRows = false;
            this.uiDataGridView1.AllowUserToDeleteRows = false;
            this.uiDataGridView1.AllowUserToResizeColumns = false;
            this.uiDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.uiDataGridView1.ColumnHeadersHeight = 32;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.portNo,
            this.size,
            this.operation});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle13;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(5, 284);
            this.uiDataGridView1.Name = "uiDataGridView1";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.uiDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.uiDataGridView1.RowTemplate.Height = 25;
            this.uiDataGridView1.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.Size = new System.Drawing.Size(453, 83);
            this.uiDataGridView1.TabIndex = 2;
            this.uiDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UiDataGridView1_CellClick);
            // 
            // portNo
            // 
            this.portNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.portNo.HeaderText = "PortNo";
            this.portNo.Name = "portNo";
            // 
            // size
            // 
            this.size.HeaderText = "Size";
            this.size.Name = "size";
            this.size.Width = 160;
            // 
            // operation
            // 
            this.operation.HeaderText = "Operation";
            this.operation.Name = "operation";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(462, 370);
            this.Controls.Add(this.uiDataGridView1);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowTitleIcon = true;
            this.Text = "Barcode Printer Service";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 484, 273);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.uiGroupBox1.ResumeLayout(false);
            this.notifyMenu.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox1;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip notifyMenu;
        private ToolStripMenuItem printerStatusToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Sunny.UI.UISymbolButton btnStop;
        private Sunny.UI.UISymbolButton btnStart;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UILedBulb uiLedBulbLocal;
        private Sunny.UI.UIButton btnGetPrinter;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private Sunny.UI.UIButton btnPrintTestBarcode;
        private Sunny.UI.UIButton BtnResetPrinter1565;
        private Sunny.UI.UIButton BtnResetPrinter100120;
        private Sunny.UI.UIButton BtnResetPrinter8060;
        private Sunny.UI.UIButton BtnResetPrinter100100;
        private DataGridViewTextBoxColumn portNo;
        private DataGridViewTextBoxColumn size;
        private DataGridViewButtonColumn operation;
    }
}
