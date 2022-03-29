using System;
using System.IO;
using System.Text;

namespace GPrinterHttp
{
				public static class Logger
				{
								private static log4net.ILog Log { get; } = log4net.LogManager.GetLogger("log");

        public static void SetConfig()
								{
            log4net.Config.XmlConfigurator.Configure();
        }
        public static void SetConfig(FileInfo fileInfo)
        {
            log4net.Config.XmlConfigurator.Configure(fileInfo);
        }

        private static string NoWarp(string msg)
        {
            return msg?.Replace("\r\n", " ").Replace("\n", " ");
        }
        private static string WrapException(string msg, Exception e)
        {
            var builder = new StringBuilder(msg);
            builder.Append("\t[").Append(e.Message).Append("]");
            if (e.InnerException != null)
            {
                builder.Append(" --> [").Append(e.InnerException.Message).Append("]");
            }

            return builder.ToString();
        }

        public static void Debug(string msg)
								{
												if (Log.IsDebugEnabled)
            {
                Log.Debug(msg);
            }
								}
        public static void Debug(string msg, Exception e)
        {
            if (Log.IsDebugEnabled)
            {
                Log.Debug(WrapException(msg, e), e);
            }
        }

        public static void Info(string msg)
        {
            if (Log.IsInfoEnabled)
            {
                Log.Info(msg);
            }
        }
        public static void Info(string msg, Exception e)
        {
            if (Log.IsInfoEnabled)
            {
                Log.Info(WrapException(msg, e), e);
            }
        }

        public static void Warn(string msg)
        {
            if (Log.IsWarnEnabled)
            {
                Log.Warn(msg);
            }
        }
        public static void Warn(string msg, Exception e)
        {
            if (Log.IsWarnEnabled)
            {
                Log.Warn(WrapException(msg, e), e);
            }
        }

        public static void Error(string msg)
        {
            if (Log.IsErrorEnabled)
            {
                Log.Error(msg);
            }
        }
        public static void Error(string msg, Exception e)
        {
            if (Log.IsErrorEnabled)
            {
                Log.Error(WrapException(msg, e), e);
            }
        }

        public static void Fatal(string msg)
        {
            if (Log.IsFatalEnabled)
            {
                Log.Fatal(msg);
            }
        }
        public static void Fatal(string msg, Exception e)
        {
            if(Log.IsFatalEnabled)
            {
                Log.Fatal(WrapException(msg, e), e);
            }
        }
    }
}
