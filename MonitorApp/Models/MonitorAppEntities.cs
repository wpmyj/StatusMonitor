using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MonitorApp.Models
{
    public class MonitorAppEntities : DbContext
    {

        //public MonitorAppEntities()
        //    : base("name=ddd")
        //{ 
            
        //}

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Database> Databases { get; set; }
        public DbSet<Website> Websites { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Password> Passwords { get; set; }
    }
}