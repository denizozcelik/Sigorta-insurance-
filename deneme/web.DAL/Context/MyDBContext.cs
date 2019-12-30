using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.MAP.Options;
using web.MODEL.Entities;

namespace web.DAL.Context
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("SigortaDB")
        {
            Configuration.ValidateOnSaveEnabled = true;
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

        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
