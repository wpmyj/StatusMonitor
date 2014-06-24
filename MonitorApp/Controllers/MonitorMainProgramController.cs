using System;
using System.Web.Mvc;
using MonitorApp.Models;

namespace MonitorApp.Controllers
{
    public class MonitorMainProgramController : Controller
    {
        private MonitorAppEntities db = new MonitorAppEntities();
        public JsonResult OpenDb(int id)
        {
            Database obj = db.Databases.Find(id);
            try
            {
                MonitorDbService.StartMonitorDatabase(id);
            }

            catch (Exception ex)
            {
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public string CloseDb(int id)
        {
            try
            {

                MonitorDbService.StopMonitorDatabase(id);
            }
            catch (Exception ex)
            {
                return "exception";
            }
            return "true";
        }

        public string OpenWeb(int id)
        {
            try
            {
                MonitorWebService.StartMonitorWebsite(id);
            }

            catch (Exception ex)
            {
                return "exception";
            }
            return "true";
        }

        public string CloseWeb(int id)
        {
            try
            {
                MonitorWebService.StopMonitorWebsite(id);
            }

            catch (Exception ex)
            {
                return "exception";
            }
            return "true";
        }
    }
}
