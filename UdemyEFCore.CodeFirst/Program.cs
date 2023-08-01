// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{

    var id = 5;
    decimal price = 100;

    // raw sql
    var products = await _context.Products.FromSqlRaw("SELECT * FROM Products").ToListAsync();

    // parametre
    var product = await _context.Products.FromSqlRaw("SELECT * FROM Products where id={0}",id).FirstAsync();

    // parametre
    var product2 = await _context.Products.FromSqlRaw("SELECT * FROM Products where price>{0}",price).ToListAsync();


    // başka yol ($) işareti koyduk sql sorgusunun başına bu sayede {} arasında değişkeni direkt belirtebiliyoruz.
    var products3 = await _context.Products.FromSqlInterpolated($"SELECT * FROM Products where price>{price}").ToListAsync();

    Console.WriteLine("");

   

    //var category = new Category() { Name = "Kalemler" };
    //category.Products.Add(new() { Name = "kalem 1", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "kalem 2", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "kalem 3", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "kalem 4", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //_context.Categories.Add(category);
    //_context.SaveChanges();

    Console.WriteLine("Done!");



    //_context.Products.Add(new() { Name = "Kalem1", Price=100,DiscountPrice=120, Barcode=123,Stock=1,Url="200"});
    //_context.SaveChanges();

}

