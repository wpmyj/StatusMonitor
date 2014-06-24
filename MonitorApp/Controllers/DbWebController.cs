using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonitorApp.Models;
using MonitorApp.ViewModels;

namespace MonitorApp.Controllers
{
    public class DbWebController : Controller
    {
        private MonitorAppEntities db = new MonitorAppEntities();

        //
        // GET: /DbWeb/

        public ActionResult Index()
        {
            var ip = (from i in db.Databases select i.ServerIp).ToList();
            var dbName = (from i in db.Databases select i.DatabaseName).ToList();
            var url = (from i in db.Websites select i.Url).ToList();
            var DbId = (from i in db.Databases select i.DatabaseId).ToList();
            var WebId = (from i in db.Websites select i.WebsiteId).ToList();

            var viewModel = new DbWebViewModel
            {
                DatabaseServerIps = ip,
                DatabaseNames=dbName,
                WebsiteUrls=url,
                DatabaseId=DbId,
                WebsiteId=WebId
            };
            return View(viewModel);
        }

    }
}
