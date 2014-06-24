using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MonitorApp.Models;
using System.Data.Entity;

namespace MonitorApp.Controllers
{
    public class PasswordController : Controller
    {
        private MonitorAppEntities db = new MonitorAppEntities();
        
        //
        // GET: /ModifyPassword/

        public ActionResult ModifyPassword(string str)
        {
            var temp = (from i in db.Accounts where i.UserName == str select i).ToList();
            Password password = new Password();
            password.Name = temp[0].UserName;
            db.Passwords.Add(password);
            db.SaveChanges();
            return View(password);
        }

        [HttpPost]

        public ActionResult ModifyPassword(Password password)
        {
            if (ModelState.IsValid)
            {
                var tempPassword = (from i in db.Passwords where i.Name == password.Name select i).ToList();
                tempPassword[0].Name = password.Name;
                tempPassword[0].NewPassword = password.NewPassword;
                tempPassword[0].ConfirmNewPassword = password.ConfirmNewPassword;

                Account account = new Account();
                var tempAccount = (from i in db.Accounts where i.UserName == password.Name select i).ToList();
                tempAccount[0].Password = tempPassword[0].ConfirmNewPassword;
                var keyId = (from i in db.Accounts where i.UserName == password.Name select i.AccountId).ToList();
                db.Accounts.Find(keyId[0]).Password = tempAccount[0].Password;
                db.SaveChanges();
                
                return Redirect("/DbWeb/index");
            }
            return View(password);
        }

    }
}
