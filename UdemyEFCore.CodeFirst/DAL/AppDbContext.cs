using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.CodeFirst.DAL.Models;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {

        private readonly int Barcode;

        public AppDbContext(int barcode)
        {
            Barcode = barcode;
        }
        public AppDbContext()
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build(); // alt kısımdaki connection string'i okuyabilmesi için Build metodumuzu burada çağırıyoruz. (initialize ediyoruz yani nesne örneğini oluşturuyoruz.)
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Fluent API yöntemi ile configuration yapıyoruz.
        {
            modelBuilder.Entity<Product>().Property(x => x.IsDeleted).HasDefaultValue(false);

            // burası her bir DbContext'den nesne aldığımızda çalışıyor. Query'de yazdığımız kodlar her türlü çalışıyor.
            if (Barcode != default(int))
            {
                modelBuilder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted && x.Barcode == Barcode);
            }
            else
            {
                modelBuilder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted);
            }


            base.OnModelCreating(modelBuilder);
        }
    }
}
