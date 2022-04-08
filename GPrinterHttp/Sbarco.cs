using System.Runtime.InteropServices;

namespace GPrinterHttp
{
				public static class Sbarco
				{
								[DllImport("SBSDK_API.dll", CallingConvention = CallingConvention.StdCall)]
								public static extern bool PortOpen(string pPortName);

								[DllImport("SBSDK_API.dll", CallingConvention = CallingConvention.StdCall)]
								public static extern int PortEnumCount(int nPortType);

								[DllImport("SBSDK_API.dll", CallingConvention = CallingConvention.StdCall)]
								public static extern bool PortEnumGet(int nPortType, int nItem, string pBuffer);
				}
}
