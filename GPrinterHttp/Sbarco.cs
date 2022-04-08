using System.Runtime.InteropServices;

namespace GPrinterHttp
{
				public static class Sbarco
				{
								// Port Functions
								[DllImport("SBSDK_API.dll", CallingConvention = CallingConvention.StdCall)]
								public static extern bool PortOpen(string pPortName);

								[DllImport("SBSDK_API.dll")]
								public static extern void PortClose();

								[DllImport("SBSDK_API.dll")]
								public static extern int PortEnumCount(int nPortType);

								[DllImport("SBSDK_API.dll")]
								public static extern bool PortEnumGet(int nPortType, int nItem, string pBuffer);

								// Setting Functions
								[DllImport("SBSDK_API.dll")]
								public static extern bool SetMeasurement(int nMeasurement, int nResolution);

								// Print Functions
								[DllImport("SBSDK_API.dll")]
								public static extern bool PrintText(float fX, float fY, int nRotation, int nFontID, int nFontHor, int nFontVer, bool bReverse, int nDataLen, string pData);
								
								[DllImport("SBSDK_API.dll")]
								public static extern bool PrintBarcode(float fX, float fY, float fBarHeight, int nRotation, int nBarType, int nNarrowBar, int nWideBar, bool bHuman, int nDataLen, string pData);

								[DllImport("SBSDK_API.dll")]
								public static extern bool PrintLabel(int nSet, int nCopy, bool bReverse);
				}
}
