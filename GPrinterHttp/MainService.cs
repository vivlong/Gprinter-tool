using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;

namespace GPrinterHttp
{
				public partial class GPrinterHttpService : ServiceBase
				{
								private HttpListener httpListener;
								private Printer printer = new Printer();

								public GPrinterHttpService()
								{
												InitializeComponent();
								}

								protected override void OnStart(string[] args)
								{
												try
												{
																httpListener = new HttpListener();
																httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
																httpListener.Prefixes.Add("http://127.0.0.1:8848/");
																httpListener.Start();
																Logger.Debug("服务端已启动:" + DateTime.Now.ToString());
																httpListener.BeginGetContext(ListenerHandle, httpListener);
												}
												catch (Exception ex)
												{
																Logger.Error(ex.Message);
												}
								}

								protected override void OnStop()
								{
												if (httpListener != null)
												{
																httpListener.Close();
																Logger.Debug("服务端已停止:" + DateTime.Now.ToString());
												}
								}

								private void ListenerHandle(IAsyncResult result)
								{
												httpListener = (HttpListener)result.AsyncState;
												if (httpListener == null) return;
												try
												{
																if (httpListener.IsListening)
																{
																				httpListener.BeginGetContext(ListenerHandle, httpListener);
																				HttpListenerContext context = httpListener.EndGetContext(result);
																				HttpListenerRequest request = context.Request;
																				Dictionary<string, string> rst = new Dictionary<string, string>();
																				rst.Add("ret", "200");
																				rst.Add("msg", "done");
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
																																Logger.Debug("接收数据:" + content);
																																handlePostAction(content);
																												}
																												break;
																								case "GET":
																												{
																																var data = request.QueryString;
																																if (data.Count > 0)
																																{
																																				var ds = data.AllKeys.ToDictionary(k => k, k => data.Get(k));
																																				var content = JsonConvert.SerializeObject(ds);
																																				rst.Add("data", content);
																																				Logger.Debug("接收数据:" + content);
																																				handleGetAction(ds);
																																}
																												}
																												break;
																				}
																				HttpListenerResponse response = context.Response;
																				response.StatusCode = 200;
																				response.ContentType = "application/json;charset=UTF-8";
																				response.ContentEncoding = Encoding.UTF8;
																				response.AppendHeader("Content-Type", "application/json;charset=UTF-8");
																				using (StreamWriter writer = new StreamWriter(response.OutputStream, Encoding.UTF8))
																				{
																								writer.Write(rst);
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

								private void handlePostAction(string content)
								{
												// Call Printer
												if (printer.CheckPrinter())
												{
																printer.StartPrint(content);
												}
								}


								private void handleGetAction(Dictionary<string, string> ds)
								{
												// Call Printer
												if (printer.CheckPrinter())
												{
																string outType;
																ds.TryGetValue("type", out outType);
																if (outType == "sn")
																{
																				Logger.Debug("outType:" + outType);
																				string outModel;
																				string outSn;
																				ds.TryGetValue("model", out outModel);
																				ds.TryGetValue("sn", out outSn);
																				printer.PrintSnBySkd(outModel, outSn);
																				Logger.Debug("outModel:" + outModel);
																				Logger.Debug("outSn:" + outSn);
																}
												}
								}
				}
}
