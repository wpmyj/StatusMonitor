using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace MonitorApp.Controllers
{
    public class LogAction : ExceptionHandlerAction
    {
        //
        // GET: /LogAction/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public override void Handler(Exception ex, string content)
        {
            ILog log = log4net.LogManager.GetLogger("monitorlog");
            if (log.IsDebugEnabled)
                log.Debug(ex + content);
            if (log.IsErrorEnabled)
                log.Error(ex + content);
            if (log.IsFatalEnabled)
                log.Fatal(ex + content);
            if (log.IsInfoEnabled)
                log.Info(ex + content);
            if (log.IsWarnEnabled)
                log.Warn(ex + content);
        }
    }
}
