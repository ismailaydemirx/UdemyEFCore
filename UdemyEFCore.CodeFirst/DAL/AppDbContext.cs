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
        //Şimdi BasePerson class'ımızı DbSet olarak ekliyoruz ve bu durumda, bir tablo oluşacak ve ona bağlı olan hiyerarşilerin datalarını tutacak.
        public DbSet<BasePerson> Persons { get; set; }
        // BasePerson sınıfımızı DBSet olarak eklemedik, sadece onu inherit alan classları DBSet olarak ekledik.
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<ProductFeature> ProductFeature { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Log türleri 6 tane
            // Trace
            // Debug
            // Information
            // Warning
            // Error
            // Critical
            Initializer.Build(); // alt kısımdaki connection string'i okuyabilmesi için Build metodumuzu burada çağırıyoruz. (initialize ediyoruz yani nesne örneğini oluşturuyoruz.)
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Fluent API yöntemi ile configuration yapıyoruz.
        {
            // her zaman has ile başlanır

            base.OnModelCreating(modelBuilder);
        }
    }
}
