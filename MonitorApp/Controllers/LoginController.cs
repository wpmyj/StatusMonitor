using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonitorApp.Models;

namespace MonitorApp.Controllers
{
    public class LoginController : Controller
    {
        private MonitorAppEntities db = new MonitorAppEntities();
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Account account)
        {
            if (ModelState.IsValid)
            {
                var t = (from o in db.Accounts
                         where o.UserName == account.UserName && o.Password == account.Password
                         select o.UserName).ToList();
                
                if (t.Count()!= 0)
                {
                    Session["admin"] = t[0];
                    return Redirect("/DbWeb/index");
                }
            }

            return View(account);
        }
      
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
