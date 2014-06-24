using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MonitorApp.Models
{
    public class Data : DropCreateDatabaseIfModelChanges<MonitorAppEntities>
    {
        protected override void Seed(MonitorAppEntities context)
        {
            new List<Account>
            {
                new Account{UserName="wuyao",Password="123"},
                new Account{UserName="fanfei",Password="456"},
                new Account{UserName="yufa",Password="789"}
            }.ForEach(a => context.Accounts.Add(a));
            
            new List<Database> 
            {
                new Database{ServerIp="42.96.132.184",DatabaseName="Evoque",User="sa",Password="q9s4f1b2k566"}
            }.ForEach(b=>context.Databases.Add(b));

            new List<Website>
            {
                new Website{Url="http://www.chexingke.com"},
            }.ForEach(c => context.Websites.Add(c));
        }
    }
}