using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infrastructure
{
    public class ShowLog4Net
    {
        public static void showLog4Net(Exception e, Type type)
        {
            ILog log = log4net.LogManager.GetLogger(type);
            //记录错误日志
            //log.Error("error", e);
            ////记录严重错误
            //log.Fatal("fatal", new Exception("发生了一个致命错误"));
            //记录一般信息
            log.Info(e.Message);
            ////记录调试信息
            //log.Debug("debug");
            //记录警告
            //log.Warn("warn");
        }

    }
}
