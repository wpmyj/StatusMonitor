using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonitorApp.Models;

namespace MonitorApp.Controllers
{
    public class WebsiteController : Controller
    {
        private MonitorAppEntities db = new MonitorAppEntities();

        //
        // GET: /AddWebsite/

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Website website)
        {
            if (ModelState.IsValid)
            {
                db.Websites.Add(website);
                db.SaveChanges();
                return Redirect("/DbWeb/index");
            }

            return View(website);
        }

        public ActionResult Delete(int id)
        {
            Website website = db.Websites.Find(id);
            return View(website);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Website website = db.Websites.Find(id);
            db.Websites.Remove(website);
            db.SaveChanges();
            return Redirect("/DbWeb");
        }

    }
}
