using System.Collections;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Windows.Forms;

namespace GPrinterControl
{
				public class Service
				{
								private string serviceName = "GPrinterHttpService";
								private string serviceFilePath = $"{Application.StartupPath}\\GPrinterHttp.exe";
								public bool IsServiceExisted()
								{
												ServiceController[] services = ServiceController.GetServices();
												foreach (ServiceController sc in services)
												{
																if (sc.ServiceName.ToLower() == serviceName.ToLower())
																{
																				return true;
																}
												}
												return false;
								}

								public ServiceControllerStatus GetServiceStatus()
								{
												ServiceControllerStatus status = new ServiceControllerStatus();
												using (ServiceController control = new ServiceController(serviceName))
												{
																status = control.Status;
												}
												return status;
								}

								public void StartService()
								{
												if (!IsServiceExisted())
												{
																InstallService(serviceFilePath);
												}
												using (ServiceController control = new ServiceController(serviceName))
												{
																if (control.Status == ServiceControllerStatus.Stopped)
																{
																				control.Start();
																}
												}
								}

								public void StopService()
								{
												if (IsServiceExisted())
												{
																using (ServiceController control = new ServiceController(serviceName))
																{
																				if (control.Status == ServiceControllerStatus.Running)
																				{
																								control.Stop();
																				}
																}
												}
								}

								private void InstallService(string serviceFilePath)
								{
												using (AssemblyInstaller installer = new AssemblyInstaller())
												{
																installer.UseNewContext = true;
																installer.Path = serviceFilePath;
																IDictionary savedState = new Hashtable();
																savedState.Clear();
																installer.Install(savedState);
																installer.Commit(savedState);
												}
								}

								private void UninstallService(string serviceFilePath)
								{
												using (AssemblyInstaller installer = new AssemblyInstaller())
												{
																installer.UseNewContext = true;
																installer.Path = serviceFilePath;
																installer.Uninstall(null);
												}
								}
				}
}
