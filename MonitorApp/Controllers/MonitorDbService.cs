using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonitorApp.Models;
using System.Configuration;

namespace MonitorApp.Controllers
{
    public static class MonitorDbService
    {
        private static MonitorAppEntities db = new MonitorAppEntities();

        public static EmailAction sea=new EmailAction();
        public static SmsAction ssa=new SmsAction();
        public static LogAction la=new LogAction();

        private static Dictionary<int, TaskExcuter> taskDbExcuters
            = new Dictionary<int, TaskExcuter>();

        private static Dictionary<int, DatabaseMonitor> dms
            = new Dictionary<int, DatabaseMonitor>();

        public static Dictionary<int, ConfigManager> cms
            = new Dictionary<int, ConfigManager>();


        public static void RegisterAndSetDbAction(int i)
        {
            dms[i].AddAction(sea);
            dms[i].AddAction(ssa);
            dms[i].AddAction(la);

            dms[i].SetSmsTime(new TimeSpan(0, cms[i].DbSmsConfigTimeSpan, 0), new TimeSpan(0, cms[i].DbSmsIgnoreTimeSpan, 0));
            dms[i].SetBlogTime(new TimeSpan(0, cms[i].DbSblogConfigTimeSpan, 0), new TimeSpan(0, cms[i].DbSblogIgnoreTimeSpan, 0));
            dms[i].SetEmailTime(new TimeSpan(0, cms[i].DbSemailConfigTimeSpan, 0), new TimeSpan(0, cms[i].DbSemailIgnoreTimeSpan, 0));
        }

        public static void StartMonitorDatabase(int i)
        {
            TaskExcuter databaseTaskExcuter = null;
            if (!taskDbExcuters.ContainsKey(i))
            {
                databaseTaskExcuter = new TaskExcuter();
                taskDbExcuters.Add(i, databaseTaskExcuter);
            }

            ConfigManager cm = null;
            if (!cms.ContainsKey(i))
            {
                cm = new ConfigManager();
                cms.Add(i, cm);
            }

            cms[i].Init();

            DatabaseMonitor dm = null;
            if (!dms.ContainsKey(i))
            {
                dm = new DatabaseMonitor(i);
                dms.Add(i,dm);
            }

            RegisterAndSetDbAction(i);
            taskDbExcuters[i].SetTask(dms[i].LetMonitor, 3);
            taskDbExcuters[i].StartTask();
        }

        public static void StopMonitorDatabase(int id)
        {
            if (taskDbExcuters.ContainsKey(id))
            {
                taskDbExcuters[id].StopTask();
            }
        }
    }
}
