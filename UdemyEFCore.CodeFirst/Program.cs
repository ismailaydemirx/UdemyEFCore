// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using System.Linq;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{

    // RIGHT JOIN -- Right join'i left join kullanarak gerçekleştiriyoruz. Tabloların yerini değiştirince aynı şeye denk geliyor.
    var rightJoinResult = await (from pf in _context.ProductFeature
                                 join p in _context.Products on pf.Id equals p.Id into plist
                                 from p in plist.DefaultIfEmpty()
                                 select new
                                 {
                                     ProductName = p.Name,
                                     ProductPrice = (decimal?)p.Price,
                                     ProductColor = pf.Color,
                                     ProductWidth = pf.Width,
                                 }).ToListAsync();



    Console.WriteLine("");


    // LEFT JOIN 
    var leftJoinResult = await (from p in _context.Products
                                join pf in _context.ProductFeature on p.Id equals pf.Id into pflist
                                from pf in pflist.DefaultIfEmpty()
                                select new
                                {
                                    ProductName = p.Name,
                                    ProductColor = pf.Color,
                                    ProductWidth = (int?)pf.Width == null ? 5 : pf.Width,
                                }).ToListAsync();

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

