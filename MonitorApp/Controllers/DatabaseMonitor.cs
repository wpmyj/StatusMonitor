using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MonitorApp.Models;

namespace MonitorApp.Controllers
{
    public class DatabaseMonitor : CommonMoniotrPartion
    {
        private MonitorAppEntities db = new MonitorAppEntities();
        private string strcon;

        public DatabaseMonitor(int i)
            : base()
        {
            var dbNames = (from g in db.Databases where g.DatabaseId == i select g.DatabaseName).ToList();
            var serverIps = (from g in db.Databases where g.DatabaseId == i select g.ServerIp).ToList();
            var userNames = (from g in db.Databases where g.DatabaseId == i select g.User).ToList();
            var passwords = (from g in db.Databases where g.DatabaseId == i select g.Password).ToList();
            this.message = "数据库监控异常---"+dbNames[0];
            this.strcon = "server='" + serverIps[0] + "';database='" + dbNames[0] + "';uid='" + userNames[0] + "';pwd='" + passwords[0] + "';";
        }

        public void LetMonitor()
        {
            try
            {
                //string strcon = ConfigManagerController.Strcon;
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                con.Close();
            }
            catch (Exception ex)
            {
                ExceptionProcessWatch(ex, MonitorDbService.ssa, this.smsConfirmTimeSpan, this.smsIgnoreTimeSpan);
                ExceptionProcessWatch(ex, MonitorDbService.sea, this.sEmailConfirmTimeSpan, this.sEmailIgnoreTimeSpan);
                ExceptionProcessWatch(ex, MonitorDbService.la, this.sBlogConfirmTimeSpan, this.sBlogIgnoreTimeSpan);
            }
        }

        public void SetSmsTime(TimeSpan confirmTimeSpan, TimeSpan ignoreTimeSpan)
        {
            this.smsConfirmTimeSpan = confirmTimeSpan;
            this.smsIgnoreTimeSpan = ignoreTimeSpan;
        }

        public void SetEmailTime(TimeSpan confirmTimeSpan, TimeSpan ignoreTimeSpan)
        {
            this.sEmailConfirmTimeSpan = confirmTimeSpan;
            this.sEmailIgnoreTimeSpan = ignoreTimeSpan;
        }

        public void SetBlogTime(TimeSpan confirmTimeSpan, TimeSpan ignoreTimeSpan)
        {
            this.sBlogConfirmTimeSpan = confirmTimeSpan;
            this.sBlogIgnoreTimeSpan = ignoreTimeSpan;
        }
    }
}
