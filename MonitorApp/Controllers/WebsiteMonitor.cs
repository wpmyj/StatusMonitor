using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MonitorApp.Models;
using System.Net;

namespace MonitorApp.Controllers
{
    public class WebsiteMonitor : CommonMoniotrPartion
    {
        private MonitorAppEntities db = new MonitorAppEntities();
        private string url;
        
        public WebsiteMonitor(int i)
            : base()
        {
            var webNames = (from g in db.Websites where g.WebsiteId == i select g.Url).ToList();
            var urls = (from g in db.Websites where g.WebsiteId == i select g.Url).ToList();
            this.message = "网站监控异常---"+webNames[0];
            this.url = urls[0];
        }


        public void LetMonitor()
        {
            try
            {
                int httpStateCode = HttpTest(url);
                if (httpStateCode == 200)
                {
                }
                else
                {
                    throw new Exception();
                }
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

        public static int HttpTest(string url)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 10 * 1000;//超时时间10秒，默认100秒
                request.Method = "GET";
                //如果请允许跳转，请求的地址跳转到最后一个页面的地址状态
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                return (int)response.StatusCode;
            }
            catch (WebException webex)//404，500等getresponse时会异常
            {
                response = (HttpWebResponse)webex.Response;
                if (response != null)
                    return (int)response.StatusCode;
                return -1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
        }

    }
}
