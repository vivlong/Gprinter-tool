using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Collections.Generic;

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
																				string content = "";
																				switch (request.HttpMethod)
																				{
																								case "POST":
																												{
																																Stream stream = context.Request.InputStream;
																																StreamReader reader = new StreamReader(stream, Encoding.UTF8);
																																content = reader.ReadToEnd();
																																Logger.Debug("接收数据:" + content);
																															//	handleAction(content);
																												}
																												break;
																								case "GET":
																												{
																																var data = request.QueryString;
																																if (data.Count > 0)
																																{
																																				var ds = data.AllKeys.ToDictionary(k => k, k => data.GetValues(k));

																																				string[] outType;
																																			
																																				ds.TryGetValue("type", out outType);
																																			

																																				if (outType[0] == "bei")
																																				{
																																								string[] outModel;
																																								string[] outBno;
																																								ds.TryGetValue("model", out outModel);
																																								ds.TryGetValue("bno", out outBno);
																																								handleAction(outModel[0], outBno[0]);
																																				}
																																				if (outType[0] == "lunzu")
																																				{
																																								string[] outLetno;
																																								string[] outModel;
																																								string[] outQty;
																																								string[] outPairl;
																																								string[] outFrontsn;
																																								string[] outFrontn;
																																								string[] outRearn;
																																								string[] outRearsn;
																																								ds.TryGetValue("letno", out outLetno);
																																								ds.TryGetValue("model", out outModel);
																																								ds.TryGetValue("qty", out outQty);
																																								ds.TryGetValue("pair", out outPairl);
																																								ds.TryGetValue("frontsn", out outFrontsn);
																																								ds.TryGetValue("frontn", out outFrontn);
																																								ds.TryGetValue("rearn", out outRearn);
																																								ds.TryGetValue("rearsn", out outRearsn);

																																								printer.PrintLunZu( outLetno[0],  outModel[0],  outQty[0],  outPairl[0],  outFrontsn[0],  outFrontn[0],  outRearn[0],  outRearsn[0]);
																																				}
																																				Logger.Debug("outStr接收数据:" + outType[0]);
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
																								writer.Write(content);
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

								private void handleAction(string model, string bno)
								{
												// TODO
												// Call Printer
												printer.PrintBeiNo(model, bno);
											
								}
				}
}
