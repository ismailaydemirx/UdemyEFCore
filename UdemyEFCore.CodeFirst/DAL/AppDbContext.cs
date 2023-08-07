using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.CodeFirst.DAL.Models;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        private DbConnection _connection;

        public AppDbContext()
        {
        }

        public AppDbContext(DbConnection connection)
        {
            _connection = connection;
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connection == default(DbConnection))
            {
                Initializer.Build();
                optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
            }
            else
            {
                optionsBuilder.LogTo(Console.WriteLine,
                    Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(_connection);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Fluent API yöntemi ile configuration yapıyoruz.
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
