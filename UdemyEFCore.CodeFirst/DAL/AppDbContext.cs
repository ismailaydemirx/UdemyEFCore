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
        public DbSet<Person> Persons { get; set; }
        //public DbSet<ProductFull> ProductFulls { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build(); // alt kısımdaki connection string'i okuyabilmesi için Build metodumuzu burada çağırıyoruz. (initialize ediyoruz yani nesne örneğini oluşturuyoruz.)
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Fluent API yöntemi ile configuration yapıyoruz.
        {
            // Fluent API tarafında NotMapped kullanmak için "Ignore" methodunu kullanabiliriz.
            modelBuilder.Entity<Product>().Ignore(x => x.Barcode);

            // Fluent API tarafında [Unicode(false)] kullanmak için "Property(x => x.Name).IsUnicode(false)" methodunu kullanabiliriz.
            modelBuilder.Entity<Product>().Property(x => x.Name).IsUnicode(false).HasMaxLength(500); // Nvarchar değil varchar olarak saklıyoruz.

            modelBuilder.Entity<Product>().Property(x => x.Url).HasColumnType("varchar(500)").HasColumnName("ProductUrl"); // Column tipini burada belirleyebiliyoruz.

            base.OnModelCreating(modelBuilder);
        }
    }
}
