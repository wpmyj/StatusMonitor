using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonitorApp.Models;
using System.Configuration;

namespace MonitorApp.Controllers
{
    public static class MonitorWebService
    {
        private static MonitorAppEntities db = new MonitorAppEntities();
        public static EmailAction sea = new EmailAction();
        public static SmsAction ssa = new SmsAction();
        public static LogAction la = new LogAction();

        private static Dictionary<int, TaskExcuter> taskWebExcuters
            = new Dictionary<int, TaskExcuter>();

        private static Dictionary<int, WebsiteMonitor> wms
         = new Dictionary<int, WebsiteMonitor>();

        public static Dictionary<int, ConfigManager> cms
            = new Dictionary<int, ConfigManager>();

        public static void RegisterAndSetWebAction(int i)
        {
            wms[i].AddAction(sea);
            wms[i].AddAction(ssa);
            wms[i].AddAction(la);

            wms[i].SetSmsTime(new TimeSpan(0, cms[i].WebSmsConfigTimeSpan, 0), new TimeSpan(0, cms[i].WebSmsIgnoreTimeSpan, 0));
            wms[i].SetBlogTime(new TimeSpan(0, cms[i].WebSblogConfigTimeSpan, 0), new TimeSpan(0, cms[i].WebSblogIgnoreTimeSpan, 0));
            wms[i].SetEmailTime(new TimeSpan(0, cms[i].WebSemailConfigTimeSpan, 0), new TimeSpan(0, cms[i].WebSemailIgnoreTimeSpan, 0));
        }

        public static void StartMonitorWebsite(int i)
        {
            TaskExcuter websiteTaskExcuter = null;
            if (!taskWebExcuters.ContainsKey(i))
            {
                websiteTaskExcuter = new TaskExcuter();
                taskWebExcuters.Add(i, websiteTaskExcuter);
            }
            ConfigManager cm = null;
            if (!cms.ContainsKey(i))
            {
                cm = new ConfigManager();
                cms.Add(i, cm);
            }

            cms[i].Init();

            WebsiteMonitor wm = null;
            if (!wms.ContainsKey(i))
            {
                wm = new WebsiteMonitor(i);
                wms.Add(i, wm);
            }
            
            RegisterAndSetWebAction(i);
            taskWebExcuters[i].SetTask(wms[i].LetMonitor, 3);
            taskWebExcuters[i].StartTask();
        }

        public static void StopMonitorWebsite(int id)
        {
            if (taskWebExcuters.ContainsKey(id))
            {
                taskWebExcuters[id].StopTask();
            }
        }

    }
}