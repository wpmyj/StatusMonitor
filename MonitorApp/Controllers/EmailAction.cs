using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace MonitorApp.Controllers
{
    public class EmailAction : ExceptionHandlerAction
    {
        public override void Handler(Exception ex, string content)
        {
            MailMessage myMail = new MailMessage();
            myMail.From = new MailAddress("185286956@qq.com");
            myMail.To.Add(new MailAddress("447406730@qq.com"));
            myMail.Subject = "Test";
            myMail.SubjectEncoding = Encoding.UTF8;
            myMail.Body = content;
            myMail.BodyEncoding = Encoding.UTF8;
            myMail.IsBodyHtml = false;
            myMail.Priority = MailPriority.High;
            SmtpClient sender = new SmtpClient();
            sender.Host = "smtp.qq.com";
            sender.Credentials = new NetworkCredential("185286956@qq.com", "WY626489");
            sender.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                sender.Send(myMail);
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
