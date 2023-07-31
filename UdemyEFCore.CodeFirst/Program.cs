// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{

    // Full outer join için önce left
    var left = await (from p in _context.Products
                              join pf in _context.ProductFeature on p.Id equals pf.Id into pfList
                              from pf in pfList.DefaultIfEmpty()select new
                              {
                                  Id = p.Id,
                                  Name = p.Name,
                                  Color = pf.Color,
                                  Width = (int?)pf.Width,
                              }).ToListAsync();

    //  sonra right join yapabiliriz.
    var right = await (from pf in _context.ProductFeature
                                     join p in _context.Products on pf.Id equals p.Id into pList
                                     from p in pList.DefaultIfEmpty()
                                     select new
                                     {
                                         Id = p.Id,
                                         Name = p.Name,
                                         Color = pf.Color,
                                         Width = (int?)pf.Width,
                                     }).ToListAsync();

    var FullOuterJoin = left.Union(right); // Union metodu sayesinde 2 listeyi birleştirebiliyoruz.

    FullOuterJoin.ToList().ForEach(x=>
    {
        Console.WriteLine(x.Name);
    });

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

