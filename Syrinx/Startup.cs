using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Syrinx
{
    public class Startup
    {
        private HttpListener httpListener;
        private Printer printer;
        public Startup(Printer p)
        {
            printer = p;
        }

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

        private Boolean HandleGetAction(Dictionary<string, string> ds)
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
