using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorApp.ViewModels
{
    public class DbWebViewModel
    {
        public List<int> DatabaseId { get; set; }
        public List<int> WebsiteId { get; set; }
        public List<string> DatabaseServerIps { get; set; }
        public List<string> DatabaseNames { get; set; }
        public List<string> WebsiteUrls { get; set; }
    }
}