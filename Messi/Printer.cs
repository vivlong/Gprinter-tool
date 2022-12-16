using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Messi
{
    public class Printer
    {
        private readonly libUsbContorl.UsbOperation NewUsb = new();

        public List<string> GetPrinterList()
        {
            try
            {
                NewUsb.FindUSBPrinter();
                if (NewUsb.USBPortCount >= 1)
                {
                    return NewUsb.mCurrentDevicePath;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return new List<string>();
        }

        public bool CheckPrinter()
        {
            try
            {
                NewUsb.FindUSBPrinter();
                if (NewUsb.USBPortCount < 1)
                {
                    return false;
                }
                else
                {

                    for (int i = 0; i < NewUsb.USBPortCount; i++)
                    {
                        NewUsb.LinkUSB(i);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public string ReadDataFmUSB()
        {
            try
            {
                if (NewUsb.USBState)
                {
                    SendData2USB(new byte[] { 0x1B, 0x21, 0x3F }); //查询状态
                    byte[] readData = Array.Empty<byte>();
                    NewUsb.ReadDataFmUSB(ref readData);
                    NewUsb.CloseUSBPort();
                    //打印机状态返回值（16 进制）
                    var count = readData.Length;
                    StringBuilder strBuider = new();
                    for (int index = 0; index < count; index++)
                    {
                        strBuider.Append(((int)readData[index]).ToString("X2"));
                    }
                    //00 正常
                    //01 开盖
                    //02 卡纸
                    //03 卡纸、开盖
                    //04 缺纸
                    //05 缺纸、开盖
                    //08 无碳带
                    //09 无碳带、开盖
                    //0A 无碳带、卡纸
                    //0B 无碳带、卡纸、开盖
                    //0C 无碳带、缺纸
                    //0D 无碳带、缺纸、开盖
                    //10 暂停打印
                    //20 正在打印
                    //80 其他错误
                    string str = strBuider.ToString();
                    return str;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return "";
        }

        public void StartPrint(string msg)
        {
            try
            {
                if (NewUsb.USBState)
                {
                    SendData2USB("SIZE 100 mm,100 mm\r\n"); //标签尺寸(宽度,长度) 使用公制单位，在单位与数字之间必须添加一个空格
                    SendData2USB("GAP 2 mm,0 mm\r\n"); //两张卷标纸间的垂直间距距离(两标签纸中间的垂直距离, 垂直间距偏移)
                    SendData2USB("CLS\r\n"); //清除图像缓冲区（image buffer)的数据
                                             //SendData2USB("HOME\r\n"); //Size>=30mm 在使用含有间隙或黑标的标签纸时，若不能确定第一张标签纸是否在正确打印位置时，此指令可将标签纸向前推送至下一张标签纸的起点开始打印
                    SendData2USB("DENSITY 7\r\n"); //打印浓度(0~15)
                    SendData2USB("DIRECTION 0\r\n"); //定义打印时出纸和打印字体的方向
                    SendData2USB("REFERENCE 0,0\r\n"); //定义卷标的参考坐标原点(水平方向的坐标位置dot, 垂直方向的坐标位置dot)
                    SendData2USB($"TEXT 400,15,2,0,1,1,\"{msg}\"\r\n"); //字符串
                                                                        //SendData2USB("TEXT 15,60,\"TSS24.BF2\",0,1,1,\"简体字\"\r\n"); //字符串
                    SendData2USB($"QRCODE 400,40,H,4,A,0,\"{msg}\"\r\n"); //二维码
                                                                          //SendData2USB($"BARCODE 20,80,\"128M\",48,1,0,2,2,\"{msg}\"\r\n"); //一维条码
                                                                          //如果需要图片
                                                                          //StreamReader strReadFile = new StreamReader(@"./10.bmp");
                                                                          //byte[] byteReadData = new byte[strReadFile.BaseStream.Length];
                                                                          //strReadFile.BaseStream.Read(byteReadData, 0, byteReadData.Length);
                                                                          //strReadFile.Close();
                                                                          //SendData2USB("DOWNLOAD \"10.bmp\",4094,");
                                                                          //SendData2USB(byteReadData);//bmp数据
                                                                          //SendData2USB("PUTBMP 14,110,\"10.bmp\"\r\n");
                    SendData2USB("PRINT 1\r\n"); // 打印出存储于影像缓冲区内的数据(指定打印的份数, 每张标签需重复打印的张数) 1~65535
                    SendData2USB("EOP\r\n");
                    NewUsb.CloseUSBPort();
                    //
                    //"^XA ^MMT ^PW839 ^LL0118 ^LS0 ^FT18,108^BQN,2,4 ^FH\^FDMA,$SN1^FS ^FT104,92^A0N,27,40^FH\^FD$LABEL_PART^FS ^FT118,51^A0N,37,45^FH\^FD$SN1^FS ^FT443,108^BQN,2,4 ^FH\^FDMA,$SN1^FS ^FT529,92^A0N,27,40^FH\^FD$LABEL_PART^FS ^FT543,51^A0N,37,45^FH\^FD$SN1^FS ^FO529,82^GB250,4,4^FS ^FO543,34^GB250,4,4^FS ^PQ1,0,1,Y^XZ"
                    //SendData2USB("^XA\r\n"); //标签开始
                    //SendData2USB("^MMT\r\n"); //打印模式 T(撕纸模式)
                    //SendData2USB("^PW839\r\n"); //打印宽度
                    //SendData2USB("^LL0118\r\n"); //标签长度
                    //SendData2USB("^LS0\r\n"); //标签左右偏移
                    //SendData2USB("^FT18,108\r\n"); //字段排版(x,y)
                    //SendData2USB("^BQN,2,4\r\n"); //QR 条码
                    //SendData2USB("^FH\\r\n"); //十六进制转义字符
                    //SendData2USB("^FDMA,$SN1^FS\r\n"); //字段数据 ^FS字段分隔
                    //SendData2USB("^FT104,92\r\n"); //字段排版(x,y)
                    //SendData2USB("^A0N,27,40^FH\r\n"); //使用字体编号调用字体 ^FH 十六进制转义字符
                    //SendData2USB("^FD$LABEL_PART^FS\r\n"); //字段数据 ^FS字段分隔
                    //SendData2USB("^FT118,51\r\n"); //字段排版(x,y)
                    //SendData2USB("^A0N,37,45^FH\r\n"); //使用字体编号调用字体 ^FH 十六进制转义字符
                    //SendData2USB("^FD$SN1^FS\r\n"); //字段数据 ^FS字段分隔
                    //SendData2USB("^FT443,108\r\n"); //字段排版(x,y)
                    //SendData2USB("^BQN,2,4\r\n"); //QR 条码
                    //SendData2USB("^FH\\r\n"); //十六进制转义字符
                    //SendData2USB("^FDMA,$SN1^FS\r\n"); //字段数据 ^FS字段分隔
                    //SendData2USB("^FT529,92\r\n"); //字段排版(x,y)
                    //SendData2USB("^A0N,27,40^FH\\r\n"); //使用字体编号调用字体 ^FH 十六进制转义字符
                    //SendData2USB("^FD$LABEL_PART^FS\r\n"); //字段数据 ^FS字段分隔
                    //SendData2USB("^FT543,51\r\n"); //字段排版(x,y)
                    //SendData2USB("^A0N,37,45^FH\r\n"); //使用字体编号调用字体 ^FH 十六进制转义字符
                    //SendData2USB("^FD$SN1^FS\r\n"); //字段数据 ^FS字段分隔
                    //SendData2USB("^FO529,82\r\n"); //字段位置(x,y)
                    //SendData2USB("^GB250,4,4^FS\r\n"); //画框(框宽度, 框高度, 边框厚度, 框颜色, 边框圆角值)
                    //SendData2USB("^FO543,34\r\n"); //字段位置(x,y)
                    //SendData2USB("^GB250,4,4^FS\r\n"); //画框(框宽度, 框高度, 边框厚度, 框颜色, 边框圆角值)
                    //SendData2USB("^PQ1,0,1,Y\r\n");
                    //SendData2USB("^XZ\r\n"); // 标签结束
                    //NewUsb.CloseUSBPort();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        public void ResetPrinter()
        {
            try
            {
                if (NewUsb.USBState)
                {
                    SetBaseConfig();
                    SendData2USB("HOME\r\n"); //Size>=30mm 在使用含有间隙或黑标的标签纸时，若不能确定第一张标签纸是否在正确打印位置时，此指令可将标签纸向前推送至下一张标签纸的起点开始打印
                    SendData2USB("EOP\r\n");
                    NewUsb.CloseUSBPort();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        public void PrintByType(string type, string? data)
        {
            try
            {
                if (data is null) return;
                if (NewUsb.USBState)
                {
                    if (type == "sn")
                    {
                        SetBaseConfig();
                        SendData2USB($"BARCODE 105,25,\"128\",60,1,0,2,2,\"{data}\"\r\n"); //一维条码
                    }
                    else if (type == "custom")
                    {
                        SetBaseConfig();
                        SendData2USB($"{data}\r\n"); //字符串
                    }
                    else if (type == "raw")
                    {
                        SendData2USB($"{data}\r\n"); //字符串
                    }
                    SendData2USB("PRINT 1\r\n"); // 打印出存储于影像缓冲区内的数据(指定打印的份数, 每张标签需重复打印的张数) 1~65535
                    SendData2USB("EOP\r\n");
                    NewUsb.CloseUSBPort();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        public void PrintWithBmp(string type, uint sendWidth, uint sendHeight, byte[] data)
        {
            try
            {
                if (NewUsb.USBState)
                {
                    if (type == "logo")
                    {
                        SendData2USB("SIZE 60 mm,80 mm\r\n"); //标签尺寸(宽度,长度) 使用公制单位，在单位与数字之间必须添加一个空格
                        SendData2USB("GAP 2 mm,0 mm\r\n"); //两张卷标纸间的垂直间距距离(两标签纸中间的垂直距离, 垂直间距偏移
                        SendData2USB("CLS\r\n"); //清除图像缓冲区（image buffer)的数据
                        SendData2USB("DENSITY 8\r\n"); //打印浓度(0~15)
                        SendData2USB("DIRECTION 0\r\n"); //定义打印时出纸和打印字体的方向
                        SendData2USB("REFERENCE 0,0\r\n"); //定义卷标的参考坐标原点(水平方向的坐标位置dot, 垂直方向的坐标位置dot))                       
                        //SendData2USB($"DOWNLOAD \"logos.bmp\",{data.Length},");
                        //SendData2USB(data);
                        //SendData2USB("PUTBMP 320,40,\"logos.bmp\"\r\n");
                        SendData2USB("BITMAP 320,40," + (sendWidth / 8).ToString() + "," + sendHeight.ToString() + ",0,");
                        //SendData2USB("BITMAP 320,40,100,100,0,");
                        SendData2USB(data);
                        SendData2USB("TEXT 300,40,\"4\",90,1,1,\"model: epoche 700C\"\r\n");
                        SendData2USB("TEXT 240,40,\"3\",90,1,1,\"freehub: xdr\"\r\n");
                        SendData2USB("BARCODE 120,5,\"128\",80,1,90,2,2,\"WS700C24H24I30D1001214212XDR\"\r\n");
                    }
                    SendData2USB("PRINT 1\r\n"); // 打印出存储于影像缓冲区内的数据(指定打印的份数, 每张标签需重复打印的张数) 1~65535
                    SendData2USB("KILL \"logos.bmp\"\r\n");
                    SendData2USB("EOP\r\n");
                    NewUsb.CloseUSBPort();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }
        private void SetBaseConfig()
        {
            //SendData2USB("SIZE 100 mm,80 mm\r\n"); //标签尺寸(宽度,长度) 使用公制单位，在单位与数字之间必须添加一个空格
            //SendData2USB("SIZE 65 mm,15 mm\r\n"); //标签尺寸(宽度,长度) 使用公制单位，在单位与数字之间必须添加一个空格
            SendData2USB("SIZE 60 mm,80 mm\r\n"); //标签尺寸(宽度,长度) 使用公制单位，在单位与数字之间必须添加一个空格
            SendData2USB("GAP 2 mm,0 mm\r\n"); //两张卷标纸间的垂直间距距离(两标签纸中间的垂直距离, 垂直间距偏移)
            SendData2USB("CLS\r\n"); //清除图像缓冲区（image buffer)的数据
            SendData2USB("DENSITY 12\r\n"); //打印浓度(0~15)
            SendData2USB("DIRECTION 0\r\n"); //定义打印时出纸和打印字体的方向
            SendData2USB("REFERENCE 0,0\r\n"); //定义卷标的参考坐标原点(水平方向的坐标位置dot, 垂直方向的坐标位置dot)
        }

        private void SendData2USB(byte[] str)
        {
            NewUsb.SendData2USB(str, str.Length);
        }

        private void SendData2USB(string str)
        {
            byte[] by_SendData = Encoding.UTF8.GetBytes(str);
            //byte[] by_SendData = Encoding.GetEncoding("gb18030").GetBytes(str);
            //byte[] by_SendData = Encoding.GetEncoding(54936).GetBytes(str);
            SendData2USB(by_SendData);
        }
    }
}
