// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using System.Linq;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    // JOIN YAPISINI KULLANALIM. LINQ şeklinde ilerleyelim.

    // 2'li Join
    //var result = _context.Categories.Join(_context.Products, x => x.Id, y => y.CategoryId, (c, p) => p).ToList();

    // 2. YOL 2'Lİ JOIN SQL Cümleciği Gibi Yazabiliriz.

    //var result2 = (from c in _context.Categories
    //               join p in _context.Products on c.Id equals p.CategoryId
    //               select new
    //               {
    //                   CategoryName = c.Name,
    //                   ProductName = p.Name,
    //                   ProductPrice = p.Price,
    //               }).ToList();


    // 3'lü Join
    var result = _context.Categories
        .Join(_context.Products, x => x.Id, y => y.CategoryId, (category, product) => new { category, product })
        .Join(_context.ProductFeature, x => x.product.Id, y => y.Id, (category, productFeature) => new
        {
            CategoryName = category.category.Name,
            ProductName = category.product.Name,
            ProductFeatureColor = productFeature.Color,
        }).ToList();


    // 2. YOL 3'LÜ JOIN SQL Cümleciği Gibi Yazabiliriz.

    var result2 = (from category in _context.Categories
                   join product in _context.Products on category.Id equals product.CategoryId
                   join productFeature in _context.ProductFeature on product.Id equals productFeature.Id
                   select new { category, product, productFeature }).ToList();




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

