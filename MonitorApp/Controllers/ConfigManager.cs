using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace MonitorApp.Controllers
{
    public class ConfigManager
    {
        //
        // GET: /ConfigManager/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public int DbSmsConfigTimeSpan { get; set; }//秒
        public int DbSemailConfigTimeSpan { get; set; }
        public int DbSblogConfigTimeSpan { get; set; }
        public int WebSmsConfigTimeSpan { get; set; }
        public int WebSemailConfigTimeSpan { get; set; }
        public int WebSblogConfigTimeSpan { get; set; }
        public int DbSmsIgnoreTimeSpan { get; set; }//秒
        public int DbSemailIgnoreTimeSpan { get; set; }
        public int DbSblogIgnoreTimeSpan { get; set; }
        public int WebSmsIgnoreTimeSpan { get; set; }
        public int WebSemailIgnoreTimeSpan { get; set; }
        public int WebSblogIgnoreTimeSpan { get; set; }

        public void Init()
        {
            DbSmsConfigTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["DbSmsConfigTimeSpan"]);
            DbSemailConfigTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["DbSemailConfigTimeSpan"]);
            DbSblogConfigTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["DbSblogConfigTimeSpan"]);
            WebSmsConfigTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["WebSmsConfigTimeSpan"]);
            WebSemailConfigTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["WebSemailConfigTimeSpan"]);
            WebSblogConfigTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["WebSblogConfigTimeSpan"]);
            DbSmsIgnoreTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["DbSmsIgnoreTimeSpan"]);
            DbSemailIgnoreTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["DbSemailIgnoreTimeSpan"]);
            DbSblogIgnoreTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["DbSblogIgnoreTimeSpan"]);
            WebSmsIgnoreTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["WebSmsIgnoreTimeSpan"]);
            WebSemailIgnoreTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["WebSemailIgnoreTimeSpan"]);
            WebSblogIgnoreTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["WebSblogIgnoreTimeSpan"]);
        }

    }
}
