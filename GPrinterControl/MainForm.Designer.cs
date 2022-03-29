namespace GPrinterControl
{
				partial class MainForm
				{
								/// <summary>
								/// 必需的设计器变量。
								/// </summary>
								private System.ComponentModel.IContainer components = null;

								/// <summary>
								/// 清理所有正在使用的资源。
								/// </summary>
								/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
								protected override void Dispose(bool disposing)
								{
												if (disposing && (components != null))
												{
																components.Dispose();
												}
												base.Dispose(disposing);
								}

								#region Windows 窗体设计器生成的代码

								/// <summary>
								/// 设计器支持所需的方法 - 不要修改
								/// 使用代码编辑器修改此方法的内容。
								/// </summary>
								private void InitializeComponent()
								{
												this.components = new System.ComponentModel.Container();
												System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
												this.groupBox1 = new System.Windows.Forms.GroupBox();
												this.pictureBox1 = new System.Windows.Forms.PictureBox();
												this.label3 = new System.Windows.Forms.Label();
												this.label2 = new System.Windows.Forms.Label();
												this.label1 = new System.Windows.Forms.Label();
												this.btnServiceStop = new System.Windows.Forms.Button();
												this.btnServiceStart = new System.Windows.Forms.Button();
												this.groupBox2 = new System.Windows.Forms.GroupBox();
												this.btnTestUSB = new System.Windows.Forms.Button();
												this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
												this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
												this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
												this.PrinterStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
												this.groupBox1.SuspendLayout();
												((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
												this.groupBox2.SuspendLayout();
												this.notifyMenu.SuspendLayout();
												this.SuspendLayout();
												// 
												// groupBox1
												// 
												this.groupBox1.Controls.Add(this.pictureBox1);
												this.groupBox1.Controls.Add(this.label3);
												this.groupBox1.Controls.Add(this.label2);
												this.groupBox1.Controls.Add(this.label1);
												this.groupBox1.Controls.Add(this.btnServiceStop);
												this.groupBox1.Controls.Add(this.btnServiceStart);
												this.groupBox1.Location = new System.Drawing.Point(12, 12);
												this.groupBox1.Name = "groupBox1";
												this.groupBox1.Size = new System.Drawing.Size(460, 78);
												this.groupBox1.TabIndex = 0;
												this.groupBox1.TabStop = false;
												this.groupBox1.Text = "服务";
												// 
												// pictureBox1
												// 
												this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
												this.pictureBox1.Location = new System.Drawing.Point(65, 20);
												this.pictureBox1.Name = "pictureBox1";
												this.pictureBox1.Size = new System.Drawing.Size(50, 50);
												this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
												this.pictureBox1.TabIndex = 5;
												this.pictureBox1.TabStop = false;
												// 
												// label3
												// 
												this.label3.AutoSize = true;
												this.label3.Location = new System.Drawing.Point(6, 39);
												this.label3.Name = "label3";
												this.label3.Size = new System.Drawing.Size(53, 12);
												this.label3.TabIndex = 4;
												this.label3.Text = "服务状态";
												// 
												// label2
												// 
												this.label2.AutoSize = true;
												this.label2.Location = new System.Drawing.Point(345, 39);
												this.label2.Name = "label2";
												this.label2.Size = new System.Drawing.Size(53, 12);
												this.label2.TabIndex = 3;
												this.label2.Text = "停止服务";
												// 
												// label1
												// 
												this.label1.AutoSize = true;
												this.label1.Location = new System.Drawing.Point(204, 39);
												this.label1.Name = "label1";
												this.label1.Size = new System.Drawing.Size(53, 12);
												this.label1.TabIndex = 2;
												this.label1.Text = "启动服务";
												// 
												// btnServiceStop
												// 
												this.btnServiceStop.Image = global::GPrinterControl.Properties.Resources.full_stop_hover;
												this.btnServiceStop.Location = new System.Drawing.Point(404, 20);
												this.btnServiceStop.Name = "btnServiceStop";
												this.btnServiceStop.Size = new System.Drawing.Size(50, 50);
												this.btnServiceStop.TabIndex = 1;
												this.btnServiceStop.UseVisualStyleBackColor = true;
												this.btnServiceStop.Click += new System.EventHandler(this.btnServiceStop_Click);
												// 
												// btnServiceStart
												// 
												this.btnServiceStart.Image = global::GPrinterControl.Properties.Resources.full_play_hover;
												this.btnServiceStart.Location = new System.Drawing.Point(263, 20);
												this.btnServiceStart.Name = "btnServiceStart";
												this.btnServiceStart.Size = new System.Drawing.Size(50, 50);
												this.btnServiceStart.TabIndex = 0;
												this.btnServiceStart.UseVisualStyleBackColor = true;
												this.btnServiceStart.Click += new System.EventHandler(this.btnServiceStart_Click);
												// 
												// groupBox2
												// 
												this.groupBox2.Controls.Add(this.btnTestUSB);
												this.groupBox2.Location = new System.Drawing.Point(12, 96);
												this.groupBox2.Name = "groupBox2";
												this.groupBox2.Size = new System.Drawing.Size(460, 53);
												this.groupBox2.TabIndex = 1;
												this.groupBox2.TabStop = false;
												this.groupBox2.Text = "标签打印测试";
												// 
												// btnTestUSB
												// 
												this.btnTestUSB.Location = new System.Drawing.Point(87, 20);
												this.btnTestUSB.Name = "btnTestUSB";
												this.btnTestUSB.Size = new System.Drawing.Size(106, 23);
												this.btnTestUSB.TabIndex = 0;
												this.btnTestUSB.Text = "USB条码测试";
												this.btnTestUSB.UseVisualStyleBackColor = true;
												this.btnTestUSB.Click += new System.EventHandler(this.btnTestUSB_Click);
												// 
												// notifyIcon1
												// 
												this.notifyIcon1.ContextMenuStrip = this.notifyMenu;
												this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
												this.notifyIcon1.Text = "GP条码打印服务";
												this.notifyIcon1.Visible = true;
												this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
												// 
												// notifyMenu
												// 
												this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrinterStatusToolStripMenuItem,
            this.ExitToolStripMenuItem});
												this.notifyMenu.Name = "notifyMenu";
												this.notifyMenu.Size = new System.Drawing.Size(181, 70);
												// 
												// ExitToolStripMenuItem
												// 
												this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
												this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
												this.ExitToolStripMenuItem.Text = "退出";
												this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
												// 
												// PrinterStatusToolStripMenuItem
												// 
												this.PrinterStatusToolStripMenuItem.Name = "PrinterStatusToolStripMenuItem";
												this.PrinterStatusToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
												this.PrinterStatusToolStripMenuItem.Text = "打印机状态";
												this.PrinterStatusToolStripMenuItem.Click += new System.EventHandler(this.PrinterStatusToolStripMenuItem_Click);
												// 
												// MainForm
												// 
												this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
												this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
												this.ClientSize = new System.Drawing.Size(484, 161);
												this.Controls.Add(this.groupBox2);
												this.Controls.Add(this.groupBox1);
												this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
												this.MaximizeBox = false;
												this.Name = "MainForm";
												this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
												this.Text = "条码打印服务";
												this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
												this.groupBox1.ResumeLayout(false);
												this.groupBox1.PerformLayout();
												((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
												this.groupBox2.ResumeLayout(false);
												this.notifyMenu.ResumeLayout(false);
												this.ResumeLayout(false);

								}

								#endregion

								private System.Windows.Forms.GroupBox groupBox1;
								private System.Windows.Forms.Button btnServiceStart;
								private System.Windows.Forms.GroupBox groupBox2;
								private System.Windows.Forms.Button btnTestUSB;
								private System.Windows.Forms.Button btnServiceStop;
								private System.Windows.Forms.Label label1;
								private System.Windows.Forms.Label label3;
								private System.Windows.Forms.Label label2;
								private System.Windows.Forms.PictureBox pictureBox1;
								private System.Windows.Forms.NotifyIcon notifyIcon1;
								private System.Windows.Forms.ContextMenuStrip notifyMenu;
								private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
								private System.Windows.Forms.ToolStripMenuItem PrinterStatusToolStripMenuItem;
				}
}

