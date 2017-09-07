using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Infrastructure
{
    public class LogHelper
    {
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteLog(Type t, Exception ex)

        public static void WriteLog(Type t, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error("Error", ex);
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ex"></param>
         #region
        public static void WriteLog(string info, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("SiteLog");
            log.Error(info, ex);
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="info"></param>
        #region static void WriteLog(string info)
        public static void WriteLog(string info)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("SiteLog");
            log.Error(info);
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteLog(Type t, string msg)

        public static void WriteLog(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg);
        }

        #endregion
    }
}
