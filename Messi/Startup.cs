using System.Net;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Messi
{
    internal class Startup
    {
        private HttpListener? httpListener;
        private readonly Printer printer = new();

        public void Start()
        {
            try
            {
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

        public void Stop()
        {
            if (httpListener != null)
            {
                httpListener.Close();
                Logger.Debug("WebHost Stoped:" + DateTime.Now.ToString());
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
                    Dictionary<string, string> rst = new()
                    {
                        { "ret", "200" },
                        { "msg", "done" }
                    };
                    switch (request.HttpMethod)
                    {
                        case "POST":
                            {
                                Stream stream = context.Request.InputStream;
                                StreamReader reader = new(stream, Encoding.UTF8);
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
                                    if(ds is not null)
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
                    using StreamWriter writer = new(response.OutputStream, Encoding.UTF8);
                    writer.Write(JsonConvert.SerializeObject(rst));
                    writer.Close();
                    response.Close();
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

        private Boolean HandleGetAction(Dictionary<string, string> ds)
        {
            // Call Printer
            if (printer.CheckPrinter() && ds is not null)
            {
                ds.TryGetValue("type", out string? modType);
                if (modType is not null)
                {
                    if (modType == "sn")
                    {
                        ds.TryGetValue("code", out string? modCode);
                        if (modCode is not null) printer.PrintByType(modType, modCode);
                    }
                    else if (modType == "custom")
                    {
                        ds.TryGetValue("data", out string? modData);
                        if (modData is not null) printer.PrintByType(modType, modData);
                    }
                    else if (modType == "raw")
                    {
                        ds.TryGetValue("data", out string? modData);
                        if (modData is not null) printer.PrintByType(modType, modData);
                    }
                    else if (modType == "logo")
                    {
                        ds.TryGetValue("data", out string? modData);
                        if (modData is not null) printer.PrintByType(modType, modData);
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public Boolean CheckPrinter()
        {
            return printer.CheckPrinter();
        }

        public string ReadDataFmUSB()
        {
            return printer.ReadDataFmUSB();
        }

    }
}
