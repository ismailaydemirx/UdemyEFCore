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

        public DbSet<Students> Students { get; set; }
        public DbSet<Teacher> Teacher{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            Initializer.Build(); // alt kısımdaki connection string'i okuyabilmesi için Build metodumuzu burada çağırıyoruz. (initialize ediyoruz yani nesne örneğini oluşturuyoruz.)
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Fluent API yöntemi ile configuration yapıyoruz.
        {
            // her zaman has ile başlanır.

            // One-to-Many
            // modelBuilder.Entity<Category>().HasMany(x=>x.Products).WithOne(x=>x.Category).HasForeignKey(x=>x.Category_Id);

            // One-to-One
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);

            modelBuilder.Entity<Students>()
                .HasMany(x => x.Teachers)
                .WithMany(x => x.Students)
                .UsingEntity<Dictionary<string, object>>(
                "StudentTeacherManyToMany",
                x => x.HasOne<Teacher>().WithMany().HasForeignKey("Teacher_Id").HasConstraintName("FK__TeacherId"),
                x=>x.HasOne<Students>().WithMany().HasForeignKey("Student_Id").HasConstraintName("FK__StudentId")
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
