using Data.DataSeeder;
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data.Data
{
    public class CarsDbContext : IdentityDbContext<User>
    {
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }


        public CarsDbContext() { }
        public CarsDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("workstation id=CarsSalonDB.mssql.somee.com;packet size=4096;user id=ruzhe43_SQLLogin_1;pwd=daz9l85hd2;data source=CarsSalonDB.mssql.somee.com;persist security info=False;initial catalog=CarsSalonDB;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //DataSeederExtensions.SeedCategories(modelBuilder);
            //DataSeederExtensions.SeedProducts(modelBuilder);
            modelBuilder.SeedCategories();
            modelBuilder.SeedProducts();

            // Fluent API
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
