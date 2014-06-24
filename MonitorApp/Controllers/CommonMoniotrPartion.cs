using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonitorApp.Controllers
{
    public class CommonMoniotrPartion
    {
        //
        // GET: /CommonMoniotrPartion/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        protected DateTime? smsConfirmExceptionTime;
        protected DateTime? smsIgnoreTime;
        protected DateTime? sEmailConfirmExceptionTime;
        protected DateTime? sEmailIgnoreTime;
        protected DateTime? sBlogConfirmExceptionTime;
        protected DateTime? sBlogIgnoreTime;
        protected TimeSpan confirmTimeSpan;
        protected TimeSpan ignoreTimeSpan;
        protected TimeSpan smsConfirmTimeSpan;
        protected TimeSpan sEmailConfirmTimeSpan;
        protected TimeSpan sBlogConfirmTimeSpan;
        protected TimeSpan smsIgnoreTimeSpan;
        protected TimeSpan sEmailIgnoreTimeSpan;
        protected TimeSpan sBlogIgnoreTimeSpan;
        protected Exception ex;

        protected IList<ExceptionHandlerAction> actions;

        protected string message;

        public CommonMoniotrPartion()
        {
            this.message = "MonitorException";
            this.actions = new List<ExceptionHandlerAction>();
            //this.confirmTimeSpan = new TimeSpan(0, 1, 0);
            //this.ignoreTimeSpan = new TimeSpan(0, 3, 0);
        }

        public void AddAction(ExceptionHandlerAction action)
        {
            if (action != null)
            {
                this.actions.Add(action);
            }
        }

        public void RemoveAction(ExceptionHandlerAction action)
        {
            if (action != null && this.actions.Contains(action))
            {
                this.actions.Remove(action);
            }
        }

        protected void ExceptionProcessWatch(Exception ex,ExceptionHandlerAction obj, TimeSpan confirm, TimeSpan ignore)
        {
            this.ex = ex;
            if (obj is SmsAction)
            {
                if (this.smsConfirmExceptionTime == null)
                {
                    if (this.smsIgnoreTime != null)
                    {
                        if (DateTime.Now >= ((DateTime)this.smsIgnoreTime).Add(ignore))
                        {
                            this.smsIgnoreTime = null;
                            ExceptionProcessWatch(ex,obj, confirm, ignore);
                        }
                    }
                    else
                    {
                        this.smsConfirmExceptionTime = DateTime.Now;
                    }
                }
                else
                {
                    if (DateTime.Now >= ((DateTime)this.smsConfirmExceptionTime).Add(confirm))
                    {
                        this.smsConfirmExceptionTime = null;
                        this.smsIgnoreTime = DateTime.Now;
                        ExceptionHandler(obj);
                    }
                }
            }
            if (obj is EmailAction)
            {
                if (this.sEmailConfirmExceptionTime == null)
                {
                    if (this.sEmailIgnoreTime != null)
                    {
                        if (DateTime.Now >= ((DateTime)this.sEmailIgnoreTime).Add(ignore))
                        {
                            this.sEmailIgnoreTime = null;
                            ExceptionProcessWatch(ex,obj, confirm, ignore);
                        }
                    }
                    else
                    {
                        this.sEmailConfirmExceptionTime = DateTime.Now;
                    }
                }
                else
                {
                    if (DateTime.Now >= ((DateTime)this.sEmailConfirmExceptionTime).Add(confirm))
                    {
                        this.sEmailConfirmExceptionTime = null;
                        this.sEmailIgnoreTime = DateTime.Now;
                        ExceptionHandler(obj);
                    }
                }
            }
            if (obj is LogAction)
            {
                if (this.sBlogConfirmExceptionTime == null)
                {
                    if (this.sBlogIgnoreTime != null)
                    {
                        if (DateTime.Now >= ((DateTime)this.sBlogIgnoreTime).Add(ignore))
                        {
                            this.sBlogIgnoreTime = null;
                            ExceptionProcessWatch(ex,obj, confirm, ignore);
                        }
                    }
                    else
                    {
                        this.sBlogConfirmExceptionTime = DateTime.Now;
                    }
                }
                else
                {
                    if (DateTime.Now >= ((DateTime)this.sBlogConfirmExceptionTime).Add(confirm))
                    {
                        this.sBlogConfirmExceptionTime = null;
                        this.sBlogIgnoreTime = DateTime.Now;
                        ExceptionHandler(obj);
                    }
                }
            }
        }


        protected void ExceptionHandler(ExceptionHandlerAction obj)
        {
            obj.Handler(this.ex,this.message);
        }

    }
}
