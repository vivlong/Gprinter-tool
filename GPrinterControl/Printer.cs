using System;
using System.Text;

namespace GPrinterControl
{
    public class Printer
				{
								private libUsbContorl.UsbOperation NewUsb = new libUsbContorl.UsbOperation();

        public bool CheckPrinter()
								{
            try
            {
                NewUsb.FindUSBPrinter();
                if (NewUsb.USBPortCount < 1)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public void StartPrint(string msg)
								{
            try
            {
                NewUsb.FindUSBPrinter();
                if (NewUsb.USBPortCount < 1)
                {
                    return;
                }
                for (int i = 0; i < NewUsb.USBPortCount; i++)
                {
                    if (NewUsb.LinkUSB(i))
                    {
                        SendData2USB("SIZE 100 mm,100 mm\r\n");//标签尺寸
                        SendData2USB("GAP 0 mm,0 mm\r\n");//间距为0
                        SendData2USB("CLS\r\n");//清空缓冲区
                        SendData2USB("DENSITY 7\r\n");//打印浓度
                        SendData2USB("REFERENCE 0,0\r\n");
                        SendData2USB("TEXT 15,10,\"1\",0,1,1,\"" + msg + "\"\r\n");
                        //SendData2USB("TEXT 15,60,\"TSS24.BF2\",0,1,1,\"简体字\"\r\n");
                        SendData2USB("QRCODE 15,60,\"M\",1,\"A\",0,\"" + msg + "\"\r\n");
                        //SendData2USB("BARCODE 15,60,\"128M\",48,1,0,2,2,\"YS22RDA9R03K0001\"\r\n");
                        //StreamReader strReadFile = new StreamReader(@"./10.bmp");
                        //byte[] byteReadData = new byte[strReadFile.BaseStream.Length];
                        //strReadFile.BaseStream.Read(byteReadData, 0, byteReadData.Length);
                        //strReadFile.Close();
                        //SendData2USB("DOWNLOAD \"10.bmp\",4094,");
                        //SendData2USB(byteReadData);//bmp数据
                        //SendData2USB("PUTBMP 14,110,\"10.bmp\"\r\n");
                        SendData2USB("PRINT 1\r\n");
                        SendData2USB("EOP\r\n");
                        NewUsb.CloseUSBPort();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void SendData2USB(byte[] str)
        {
            NewUsb.SendData2USB(str, str.Length);
        }

        private void SendData2USB(string str)
        {
            byte[] by_SendData = Encoding.UTF8.GetBytes(str);
            SendData2USB(by_SendData);
        }
    }
}
