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
        //Person sınıfımız owned type olduğu için onu tanımlamadık.
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //public DbSet<Product> Products { get; set; }
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
            modelBuilder.Entity<Manager>().OwnsOne(x => x.Person, p =>
            {
                p.Property(x => x.FirstName).HasColumnName("FirstName");
                p.Property(x => x.LastName).HasColumnName("LastName");
                p.Property(x => x.Age).HasColumnName("Age");
            }); // entity ile owned type arasındaki ilişkiler 1-1 bir ilişkidir.
            modelBuilder.Entity<Employee>().OwnsOne(x => x.Person, p =>
            {
                p.Property(x => x.FirstName).HasColumnName("FirstName");
                p.Property(x => x.LastName).HasColumnName("LastName");
                p.Property(x => x.Age).HasColumnName("Age");
            }); // entity ile owned type arasındaki ilişkiler 1-1 bir ilişkidir.
            base.OnModelCreating(modelBuilder);
        }
    }
}
