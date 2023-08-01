﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<ProductEssnetial> ProductEssential { get; set; }
        public DbSet<ProductWithFeature> ProductWithFeature { get; set; }

        //public DbSet<Person> People { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build(); // alt kısımdaki connection string'i okuyabilmesi için Build metodumuzu burada çağırıyoruz. (initialize ediyoruz yani nesne örneğini oluşturuyoruz.)
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Fluent API yöntemi ile configuration yapıyoruz.
        {
            modelBuilder.Entity<ProductEssnetial>().Ignore(x=>x.Price); // 
            //Custom Sorgularda Her Zaman HasNoKey() metodunu kullanın.
            modelBuilder.Entity<ProductEssnetial>().HasNoKey();

            modelBuilder.Entity<ProductWithFeature>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
