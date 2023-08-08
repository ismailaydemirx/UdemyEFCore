using Microsoft.EntityFrameworkCore;

namespace Concurrency.Web.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API tanımladığımız yer: (Best Practice olan her zaman Fluent API kullanmaktır.)
            modelBuilder.Entity<Product>().Property(x => x.RowVersion).IsRowVersion();
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 2); // decimal alanlarında virgülden sonra kaç hane olacağını belirtmemiz gerekiyor. Yoksa hata verir.




            base.OnModelCreating(modelBuilder);
        }
    }
}
