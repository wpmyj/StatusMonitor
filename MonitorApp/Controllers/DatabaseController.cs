using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonitorApp.Models;

namespace MonitorApp.Controllers
{
    public class DatabaseController : Controller
    {
        private MonitorAppEntities db = new MonitorAppEntities();

        //
        // GET: /AddDatabase/

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Database database)
        {
            if (ModelState.IsValid)
            {
                db.Databases.Add(database);
                db.SaveChanges();
                return Redirect("/DbWeb/index");
            }

            return View(database);
        }

        public ActionResult Delete(int id)
        {
            Database database = db.Databases.Find(id);
            return View(database);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Database database = db.Databases.Find(id);
            db.Databases.Remove(database);
            db.SaveChanges();
            return Redirect("/DbWeb");
        }

    }
}
