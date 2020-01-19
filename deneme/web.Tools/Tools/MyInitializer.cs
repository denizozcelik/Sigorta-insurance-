using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.MODEL.Entities;

namespace web.Tools.Tools
{
    public class MyInitializer<T> : CreateDatabaseIfNotExists<T> where T : DbContext
    {
        protected override void Seed(T context)
        {
            Company cp = new Company();
            cp.ID = 1;
            cp.CompanyName = "Alex Sigorta";
            cp.CompanyLogo = "AlexLOGO";
            cp.CreatedBy = "MyInitializer";
            cp.CreatedDate = DateTime.Now;
            cp.Status = web.MODEL.Enums.DataStatus.Inserted;

            context.Set<Company>().Add(cp);
            context.SaveChanges();

            cp.ID = 2;
            cp.CompanyName = "SAO PAOLO Sigorta";
            cp.CompanyLogo = "SAO";
            cp.CreatedBy = "MyInitializer";
            cp.CreatedDate = DateTime.Now;
            cp.Status = web.MODEL.Enums.DataStatus.Inserted;

            context.Set<Company>().Add(cp);
            context.SaveChanges();

            cp.ID = 3;
            cp.CompanyName = "MARS Sigorta";
            cp.CompanyLogo = "SRAM";
            cp.CreatedBy = "MyInitializer";
            cp.CreatedDate = DateTime.Now;
            cp.Status = web.MODEL.Enums.DataStatus.Inserted;

            context.Set<Company>().Add(cp);
            context.SaveChanges();
        }

    }
}
