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
            this.btnServiceUninstall = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnServiceStop = new System.Windows.Forms.Button();
            this.btnServiceStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSetPageHome = new System.Windows.Forms.Button();
            this.btnTestUSB = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PrinterStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnServiceUninstall);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnServiceStop);
            this.groupBox1.Controls.Add(this.btnServiceStart);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnServiceUninstall
            // 
            this.btnServiceUninstall.Image = global::GPrinterControl.Properties.Resources.icon_warn;
            resources.ApplyResources(this.btnServiceUninstall, "btnServiceUninstall");
            this.btnServiceUninstall.Name = "btnServiceUninstall";
            this.btnServiceUninstall.UseVisualStyleBackColor = true;
            this.btnServiceUninstall.Click += new System.EventHandler(this.btnServiceUninstall_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnServiceStop
            // 
            this.btnServiceStop.Image = global::GPrinterControl.Properties.Resources.full_stop_hover;
            resources.ApplyResources(this.btnServiceStop, "btnServiceStop");
            this.btnServiceStop.Name = "btnServiceStop";
            this.btnServiceStop.UseVisualStyleBackColor = true;
            this.btnServiceStop.Click += new System.EventHandler(this.btnServiceStop_Click);
            // 
            // btnServiceStart
            // 
            this.btnServiceStart.Image = global::GPrinterControl.Properties.Resources.full_play_hover;
            resources.ApplyResources(this.btnServiceStart, "btnServiceStart");
            this.btnServiceStart.Name = "btnServiceStart";
            this.btnServiceStart.UseVisualStyleBackColor = true;
            this.btnServiceStart.Click += new System.EventHandler(this.btnServiceStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSetPageHome);
            this.groupBox2.Controls.Add(this.btnTestUSB);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnSetPageHome
            // 
            resources.ApplyResources(this.btnSetPageHome, "btnSetPageHome");
            this.btnSetPageHome.Name = "btnSetPageHome";
            this.btnSetPageHome.UseVisualStyleBackColor = true;
            this.btnSetPageHome.Click += new System.EventHandler(this.btnSetPageHome_Click);
            // 
            // btnTestUSB
            // 
            resources.ApplyResources(this.btnTestUSB, "btnTestUSB");
            this.btnTestUSB.Name = "btnTestUSB";
            this.btnTestUSB.UseVisualStyleBackColor = true;
            this.btnTestUSB.Click += new System.EventHandler(this.btnTestUSB_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyMenu;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrinterStatusToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.notifyMenu.Name = "notifyMenu";
            resources.ApplyResources(this.notifyMenu, "notifyMenu");
            // 
            // PrinterStatusToolStripMenuItem
            // 
            this.PrinterStatusToolStripMenuItem.Name = "PrinterStatusToolStripMenuItem";
            resources.ApplyResources(this.PrinterStatusToolStripMenuItem, "PrinterStatusToolStripMenuItem");
            this.PrinterStatusToolStripMenuItem.Click += new System.EventHandler(this.PrinterStatusToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            resources.ApplyResources(this.ExitToolStripMenuItem, "ExitToolStripMenuItem");
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
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
								private System.Windows.Forms.Label label4;
								private System.Windows.Forms.Button btnServiceUninstall;
								private System.Windows.Forms.Button btnSetPageHome;
				}
}

