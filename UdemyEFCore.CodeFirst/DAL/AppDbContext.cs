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

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build(); // alt kısımdaki connection string'i okuyabilmesi için Build metodumuzu burada çağırıyoruz. (initialize ediyoruz yani nesne örneğini oluşturuyoruz.)
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Fluent API yöntemi ile configuration yapıyoruz.
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
