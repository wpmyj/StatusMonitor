using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonitorApp.Controllers
{
    public class SmsAction : ExceptionHandlerAction
    {
        //
        // GET: /SendSmsAction/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public override void Handler(Exception ex, string content)
        {
            
        }

    }
}
