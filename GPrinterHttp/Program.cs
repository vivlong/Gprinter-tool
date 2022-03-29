using System.ServiceProcess;

namespace GPrinterHttp
{
				internal static class Program
				{
								/// <summary>
								/// 应用程序的主入口点。
								/// </summary>
								static void Main()
								{
												Logger.SetConfig();
												ServiceBase[] ServicesToRun;
												ServicesToRun = new ServiceBase[]
												{
																new GPrinterHttpService()
												};
												ServiceBase.Run(ServicesToRun);
								}
				}
}
