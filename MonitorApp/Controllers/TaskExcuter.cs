using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Timers;

namespace MonitorApp.Controllers
{
    public class TaskExcuter
    {
        private Action task;
        private Timer timer = new Timer();

        public void  SetTask(Action action, int excuteSecondsTime)
        {
            if (action == null || excuteSecondsTime <= 0)
                throw new ArgumentException();

            this.task = action;
            timer.Interval = excuteSecondsTime * 1000;
            timer.AutoReset = true;
            timer.Elapsed += timer_Elapsed;
        }
         
        public void StartTask()
        {
            if (this.timer != null)
            {
                this.timer.Start();
            }
        }

        public void StopTask()
        {
            if (this.timer != null)
            {
                this.timer.Stop();
            }
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.task();
        }
    }
}
