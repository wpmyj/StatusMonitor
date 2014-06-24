using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MonitorApp.Models
{
    public class Database
    {
        [ScaffoldColumn(false)]
        public int DatabaseId { get; set; }
        [Required(ErrorMessage = "A ServerIp is required")]
        public string ServerIp { get; set; }
        [Required(ErrorMessage = "A DatabaseName is required")]
        public string DatabaseName { get; set; }
        [Required(ErrorMessage = "A User is required")]
        public string User { get; set; }
        [Required(ErrorMessage = "A Password is required")]
        public string Password { get; set; }
    }
}