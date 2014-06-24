using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MonitorApp.Models
{
    public class Website
    {
        public int WebsiteId { get; set; }
        [Required]
        public string Url { get; set; }
    }
}