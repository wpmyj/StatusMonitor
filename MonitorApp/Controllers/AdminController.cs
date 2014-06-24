using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonitorApp.Models;

namespace MonitorApp.Controllers
{
    public class AdminController : Controller
    {
        private MonitorAppEntities db = new MonitorAppEntities();
        
        //
        // GET: /AddAdmin/

        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                var tempName = (from i in db.Admins where i.UserName==admin.UserName select i.UserName).ToList();
                var tempPassword = (from i in db.Admins where i.UserName==admin.UserName select i.ConfirmNewPassword).ToList();
                Account account = new Account();
                account.UserName=tempName[0];
                account.Password = tempPassword[0];
                db.Accounts.Add(account);
                db.SaveChanges();
                db.Admins.Remove(admin);
                db.SaveChanges();
                return Redirect("/DbWeb/index");
            }

            return View(admin);
        }
    }
}
