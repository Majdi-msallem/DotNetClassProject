using Microsoft.EntityFrameworkCore;
using PS.Data.Configurations;
using PS.Domain;
using System;
using System.Linq;

namespace PS.Data
{
    public class PSContext:DbContext
    {


      
        public DbSet<Product> Products { get; set; }
       
        public DbSet<Chemical> Chemicals{ get; set; }
        public DbSet<Biological> Biologicals { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Catgegories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Client> Clients { get; set; }
        public PSContext()
        { //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                       Initial Catalog=ProductStoreDb;
                       Integrated Security=true");
        
            optionsBuilder.UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ChemicalConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
         //   modelBuilder.Entity<Biological>().ToTable("Biologicals");
        
           foreach(var prop in modelBuilder.Model.GetEntityTypes()
                .SelectMany(entity=>entity.GetProperties())
                .Where(p=>p.Name.StartsWith("Name") && p.ClrType== typeof(string))
                )
            {
                prop.SetColumnName("MyName");
            }
        }
        
    }
}
