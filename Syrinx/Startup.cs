using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sunny.UI;
using Sunny.UI.Win32;

namespace Syrinx
{
    public class Startup
    {
        private HttpListener httpListener;
        private readonly Printer printer;
        private Socket socketClient;
        public delegate void UpdateUI(bool bln);
        public UpdateUI UpdateUIDelegate;
        public Startup(Printer p)
        {
            printer = p;
        }

        public void Start()
        {
            try
            {
                // local
                httpListener = new HttpListener
                {
                    AuthenticationSchemes = AuthenticationSchemes.Anonymous
                };
                httpListener.Prefixes.Add("http://*:8848/");
                httpListener.Start();
                Logger.Debug("WebHost Started:" + DateTime.Now.ToString());
                httpListener.BeginGetContext(ListenerHandle, httpListener);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        public void Reg()
        {
            try
            {
                // cloud
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress IP = IPAddress.Parse("39.108.192.17");
                int Port = Convert.ToInt32("8847");
                IPEndPoint ipe = new IPEndPoint(IP, Port);
                try
                {
                    socketClient.Connect(ipe);
                    if (socketClient.Connected == true)
                    {
                        Logger.Debug("Cloud Connected:" + DateTime.Now.ToString());
                        try
                        {
                            JObject dt = new JObject
                            {
                                ["act"] = "reg",
                                ["src"] = "ysprint",
                                ["id"] = ""
                            };
                            List<string> DevicePathList = printer.GetPrinterList();
                            int rowIndex = printer.GetPrinter();
                            foreach (string dp in DevicePathList)
                            {
                                int index = DevicePathList.IndexOf(dp);
                                if (rowIndex == index)
                                {
                                    string[] dps = dp.Split('#');
                                    dt["id"] = dps[1];
                                }
                            }
                            string content = JsonConvert.SerializeObject(dt);
                            SocketSend(content);
                            Thread Thread_Receive = new Thread(new ThreadStart(SocketReceive));
                            Thread_Receive.Start();
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex.Message);
                        }
                    }
                }
                catch (SocketException ex)
                {
                    Logger.Error(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }  
        }

        public void Stop()
        {
            try
            {
                if (httpListener != null)
                {
                    httpListener.Close();
                    Logger.Debug("WebHost Stoped:" + DateTime.Now.ToString());
                }
                if (socketClient != null)
                {
                    socketClient.Shutdown(SocketShutdown.Both);
                    socketClient.Close();
                    Logger.Debug("Cloud Disconnected:" + DateTime.Now.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void SocketSend(string content)
        {            
            byte[] Send = Encoding.UTF8.GetBytes(content);
            try
            {
                socketClient.Send(Send);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void SocketReceive()
        {
            while (socketClient.Connected == true)
            {
                try
                {
                    if(socketClient.Poll(-1,SelectMode.SelectRead))
                    {
                        byte[] buffer = new byte[1024 * 1024 * 20];
                        int Length = socketClient.Receive(buffer);
                        if (Length > 0)
                        {
                            string msg = Encoding.UTF8.GetString(buffer, 0, Length);
                            Logger.Debug("Receive Cloud Msg:" + msg);
                            try
                            {
                                Dictionary<string, string> rst = JsonConvert.DeserializeObject<Dictionary<string, string>>(msg);
                                if (rst.TryGetValue("act", out string act))
                                {
                                    if (act == "reg")
                                    {
                                        if(rst.TryGetValue("data", out string rs))
                                        {
                                            if(rs == "success") UpdateUIDelegate(true);
                                        }
                                    }
                                    else if (act == "prt")
                                    {
                                        // Call Printer
                                        HandleGetAction(rst);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Logger.Error(e.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }
        }

        private void ListenerHandle(IAsyncResult result)
        {
            httpListener = result.AsyncState as HttpListener;
            if (httpListener == null) return;
            try
            {
                if (httpListener.IsListening)
                {
                    httpListener.BeginGetContext(ListenerHandle, httpListener);
                    HttpListenerContext context = httpListener.EndGetContext(result);
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;
                    Dictionary<string, string> rst = new Dictionary<string, string>()
                    {
                        { "ret", "200" },
                        { "msg", "done" }
                    };
                    switch (request.HttpMethod)
                    {
                        case "POST":
                            {
                                Stream stream = context.Request.InputStream;
                                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                                string rd = reader.ReadToEnd();
                                var ds = JsonConvert.DeserializeObject(rd);
                                var content = JsonConvert.SerializeObject(ds);
                                rst.Add("data", content);
                                Logger.Debug("recevie data:" + content);
                                HandlePostAction(content);
                            }
                            break;
                        case "GET":
                            {
                                var data = request.QueryString;
                                if (data.Count > 0)
                                {
                                    var ds = data.AllKeys.ToDictionary(k => k, k => data.Get(k));
                                    if (ds != null)
                                    {
                                        var rs = HandleGetAction(ds);
                                        if (rs)
                                        {
                                            var content = JsonConvert.SerializeObject(ds);
                                            rst.Add("data", content);
                                            Logger.Debug("recevie data:" + content);
                                        }
                                        else
                                        {
                                            rst.Add("data", "");
                                        }
                                    }
                                }
                            }
                            break;
                        case "OPTIONS":
                            response.AddHeader("Access-Control-Allow-Headers", "*");
                            response.AddHeader("Access-Control-Allow-Methods", "*");
                            break;
                    }
                    response.StatusCode = 200;
                    response.ContentType = "application/json;charset=UTF-8";
                    response.ContentEncoding = Encoding.UTF8;
                    response.AppendHeader("Content-Type", "application/json;charset=UTF-8");
                    response.AppendHeader("Access-Control-Allow-Origin", "*");
                    response.AppendHeader("Access-Control-Allow-Credentials", "true");
                    using (StreamWriter writer = new StreamWriter(response.OutputStream, Encoding.UTF8))
                    {
                        writer.Write(JsonConvert.SerializeObject(rst));
                        writer.Close();
                        response.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void HandlePostAction(string content)
        {
            // Call Printer
            if (printer.CheckPrinter())
            {
                printer.StartPrint(content);
            }
        }

        private bool HandleGetAction(Dictionary<string, string> ds)
        {
            // Call Printer
            if (printer.CheckPrinter() && ds != null)
            {
                ds.TryGetValue("type", out string modType);
                if (modType != null)
                {
                    if (modType == "sn")
                    {
                        ds.TryGetValue("code", out string modCode);
                        if (modCode != null) printer.PrintByType(modType, modCode);
                    }
                    else if (modType == "custom")
                    {
                        ds.TryGetValue("data", out string modData);
                        if (modData != null) printer.PrintByType(modType, modData);
                    }
                    else if (modType == "raw")
                    {
                        ds.TryGetValue("data", out string modData);
                        if (modData != null) printer.PrintByType(modType, modData);
                    }
                    else if (modType == "logo")
                    {
                        ds.TryGetValue("data", out string modData);
                        if (modData != null) printer.PrintByType(modType, modData);
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

    }
}
