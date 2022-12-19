using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.ServiceProcess;
using System.Text;
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
            //
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");
            //
            InitializeComponent();
            btnServiceStart.Enabled = true;
            btnServiceStop.Enabled = false;
            StatusChangeHandle();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(DataGridView1_CellClick);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dataGridView1.Columns["operation"].Index) return;

            // Retrieve the task ID.
            Int32 taskID = (Int32)dataGridView1[0, e.RowIndex].Value;
        }

        private void StatusChangeHandle()
        {
            if (service.IsServiceExisted())
            {
                ServiceControllerStatus status = service.GetServiceStatus();
                if (status == ServiceControllerStatus.Running)
                {
                    pictureBox1.Image = Properties.Resources.icon_success;
                    btnServiceStart.Enabled = false;
                    btnServiceStop.Enabled = true;
                }
                else if (status == ServiceControllerStatus.Stopped)
                {
                    pictureBox1.Image = Properties.Resources.icon_warn;
                    btnServiceStart.Enabled = true;
                    btnServiceStop.Enabled = false;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.icon_info;
                }
                btnServiceUninstall.Enabled = true;
            }
            else
            {
                btnServiceUninstall.Enabled = false;
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

        private async void btnServiceUninstall_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { service.UninstallService(); });
            Thread.Sleep(1000);
            StatusChangeHandle();
        }

        private void btnTestUSB_Click(object sender, EventArgs e)
        {
            //try
            //{
            //				int nPortCount = GPrinterHttp.Sbarco.PortEnumCount(0);
            //				if(nPortCount > 0)
            //				{
            //								string acPortBuffer = "";
            //								GPrinterHttp.Sbarco.PortEnumGet(0, 0, acPortBuffer);
            //								if (!GPrinterHttp.Sbarco.PortOpen(acPortBuffer))
            //								{
            //												MessageBox.Show("未检测到打印机", "连接打印机");
            //								} else
            //								{
            //												GPrinterHttp.Sbarco.SetMeasurement(1, 0); // inchs
            //												GPrinterHttp.Sbarco.PrintText(1.1f, 0.2f, 0, 1, 1, 1, false, 14, "Print from USB");
            //												GPrinterHttp.Sbarco.PrintLabel(1, 1, false);
            //												GPrinterHttp.Sbarco.PortClose();
            //								}
            //				}
            //				else
            //				{
            //								MessageBox.Show("未检测到打印机", "连接打印机");
            //				}																
            //}
            //catch (Exception ex)
            //{
            //				MessageBox.Show(ex.Message, "打印机状态");
            //}
            if (printer.CheckPrinter())
            {
                printer.StartPrint("DEMO");
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

        private void btnSetPageHome_Click(object sender, EventArgs e)
        {
            if (printer.CheckPrinter())
            {
                printer.ResetPrinter();
            }
            else
            {
                MessageBox.Show("未检测到打印机", "连接打印机");
            }
        }

        private void btnGetPrinterList_Click(object sender, EventArgs e)
        {
            List<string> DevicePathList = printer.GetPrinterList();

            foreach (string dp in DevicePathList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell textboxcell = new();
                textboxcell.Value = dp;
                row.Cells.Add(textboxcell);
                DataGridViewButtonCell buttoncell = new ();
                buttoncell.Value = "config";
                row.Cells.Add(buttoncell);
                dataGridView1.Rows.Add(row);
            }
        }

        private static string ByteToHex(byte[] Bytes)
        {
            string str = string.Empty;
            foreach (byte Byte in Bytes)
            {
                str += String.Format("{0:X2}", Byte) + " ";
            }
            return str.Trim();
        }

        private void btnTestLabel_Click(object sender, EventArgs e)
        {
            if (printer.CheckPrinter())
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "位图文件(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|ALL files(*.*)|*.*";
                //             fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
                fd.ShowReadOnly = true;
                fd.Multiselect = false;//单选
                DialogResult r1 = fd.ShowDialog();
                fd.Dispose();
                if (r1 == DialogResult.OK)
                {
                    string strReadFilePath = fd.FileName;
                    string filename = Path.GetFileName(strReadFilePath);
                    StreamReader srReadFile = new StreamReader(strReadFilePath);
                    byte[] b_bmpdata = StreamToBytes(srReadFile.BaseStream);//获取读取文件的byte[]数据
                    srReadFile.Close();
                    byte bmpBitCount = b_bmpdata[0x1c]; //获取位图 位深度
                    if (b_bmpdata[0] != 'B' || b_bmpdata[1] != 'M')
                    {
                        MessageBox.Show("文件不支持");
                        return;
                    }
                    uint byteLeght = (uint)b_bmpdata.Length;
                    if (byteLeght > 1024000)
                    {
                        MessageBox.Show("所选文件过大");
                        return;
                    }
                    byte[] SendBmpData;
                    uint sendWidth = 0;     //实际发送的宽
                    uint sendHeight = 0;    //实际发送的高
                    byte[] setHBit = { 0x80, 0x40, 0x30, 0x10, 0x08, 0x04, 0x02, 0x01 };    //算法辅助 置1
                    byte[] clsLBit = { 0x7F, 0xBF, 0xDF, 0xEF, 0xF7, 0xFB, 0xFD, 0xFE };    //算法辅助 置0
                    {
                        Stream str1 = new MemoryStream();
                        Image getimage = Image.FromFile(strReadFilePath);
                        sendWidth = (uint)getimage.Width;      //实际发送的宽
                        sendHeight = (uint)getimage.Height;    //实际发送的高
                        if (getimage.Height % 8 != 0)
                            sendHeight = sendHeight + 8 - sendHeight % 8;
                        if (getimage.Width % 8 != 0)
                            sendWidth = sendWidth + 8 - sendWidth % 8;
                        Bitmap getbmp = new Bitmap(getimage);
                        //                     Bitmap BmpCopy = new Bitmap(getimage.Width, getimage.Height, PixelFormat.Format32bppArgb);
                        SendBmpData = new byte[sendWidth * sendHeight / 8];
                        memset(SendBmpData, 0xff, (int)(sendWidth * sendHeight / 8));//0XFF为全白
                        #region 求灰度平均值
                        Double redSum = 0, geedSum = 0, blueSum = 0;
                        Double total = sendWidth * sendHeight;
                        byte[] huiduData = new byte[sendWidth * sendHeight / 8];
                        for (int i = 0; i < getimage.Width; i++)
                        {
                            int ta = 0, tr = 0, tg = 0, tb = 0;
                            for (int j = 0; j < getimage.Height; j++)
                            {
                                Color getcolor = getbmp.GetPixel(i, j);//取每个点颜色
                                ta = getcolor.A;
                                tr = getcolor.R;
                                tg = getcolor.G;
                                tb = getcolor.B;
                                redSum += ta;
                                geedSum += tg;
                                blueSum += tb;
                            }
                        }
                        int meanr = (int)(redSum / total);
                        int meang = (int)(geedSum / total);
                        int meanb = (int)(blueSum / total);
                        #endregion 求灰度平均值
                        for (int j = 0; j < getimage.Height; j++)
                        {
                            for (int i = 0; i < getimage.Width; i++)
                            {
                                Color getcolor = getbmp.GetPixel(i, j);//取每个点颜色
                                if ((getcolor.R * 0.299) + (getcolor.G * 0.587) + (getcolor.B * 0.114) < ((meanr * 0.299) + (meang * 0.587) + (meanb * 0.114)))//颜色转灰度(可调 0-255)
                                    SendBmpData[j * sendWidth / 8 + i / 8] &= clsLBit[i % 8];
                            }
                        }
                    }
                    //StreamReader strReadFile = new StreamReader(@"C:\Users\Administrator\Desktop\logos3.bmp");
                    //byte[] byteReadData = new byte[strReadFile.BaseStream.Length];
                    //strReadFile.BaseStream.Read(byteReadData, 0, byteReadData.Length);
                    //strReadFile.Close();
                    //
                    printer.PrintWithBmp("logo", sendWidth, sendHeight, SendBmpData);
                }
            }
            else
            {
                MessageBox.Show("未检测到打印机", "连接打印机");
            }
        }

        /// <summary>
        /// 重写metset
        /// </summary>
        /// <param name="buf">设置的数组</param>
        /// <param name="val">设置的数据</param>
        /// <param name="size">数据长度</param>
        /// <returns>void</returns>
        public void memset(byte[] buf, byte val, int size)
        {
            int i;
            for (i = 0; i < size; i++)
                buf[i] = val;
        }

        /// <summary>
        /// 将 Stream 转成 byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}
