using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<ProductFeature> ProductFeature { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build(); // alt kısımdaki connection string'i okuyabilmesi için Build metodumuzu burada çağırıyoruz. (initialize ediyoruz yani nesne örneğini oluşturuyoruz.)
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Fluent API yöntemi ile configuration yapıyoruz.
        {
            //modelBuilder.Entity<Product>().HasIndex(x => x.Name);

            //_context.Products.Where(x => x.Name == "kalem").Select(x => new { name = x.Name, Price = x.Price, Stock = x.Stock, Barcode = x.Barcode });
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IncludeProperties(x => new { x.Price, x.Stock, x.Barcode });

            //modelBuilder.Entity<Product>().HasIndex(x => new { x.Name, x.Url });

            modelBuilder.Entity<Product>().HasCheckConstraint("PriceDiscountCheck", "[Price]>[DiscountPrice]");

            base.OnModelCreating(modelBuilder);
        }
    }
}
