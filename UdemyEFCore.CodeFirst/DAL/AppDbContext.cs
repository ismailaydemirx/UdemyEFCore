﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

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
