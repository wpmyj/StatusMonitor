using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonitorApp.Controllers
{
    public abstract class ExceptionHandlerAction
    {
        //
        // GET: /ExceptionHandlerAction/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public abstract void Handler(Exception ex, string content);
    }
}
