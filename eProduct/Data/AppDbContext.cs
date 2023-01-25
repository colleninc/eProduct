


using eProduct.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace eProduct.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region Configuring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(am => new
            {
                am.ProductID,
                am.OrderId
            });

            modelBuilder.Entity<OrderItem>().HasOne(m => m.Product).WithMany(am => am.OrderItems).HasForeignKey(m => m.ProductID);
            modelBuilder.Entity<OrderItem>().HasOne(m => m.Order).WithMany(am => am.OrderItems).HasForeignKey(m => m.OrderId);


            base.OnModelCreating(modelBuilder);
        }

        #region dbsets
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        #endregion

    }

    
}
