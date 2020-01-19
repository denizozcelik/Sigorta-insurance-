using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.MAP.Options;
using web.MODEL.Entities;
using web.Tools.Tools;

namespace web.DAL.Context
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("SigortaDB")
        {
            Configuration.ValidateOnSaveEnabled = true;
            Database.SetInitializer(new MyInitializer<MyDBContext>());
            Database.SetInitializer<MyDBContext>(new CreateDatabaseIfNotExists<MyDBContext>());
            Database.SetInitializer<MyDBContext>(new DropCreateDatabaseIfModelChanges<MyDBContext>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MyDBContext>(null);
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new OfferMap());
            modelBuilder.Configurations.Add(new CompanyMap());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
    }
}
