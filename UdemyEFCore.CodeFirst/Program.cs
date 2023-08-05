// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();


using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    // Porjections | Anonymous Types - 1
    // İsimsiz bir tipe yansıtmak için kullanacağımız ilk method Select methodu.

    var products = await _context.Products.Include(x => x.Category).Include(x => x.ProductFeature).Select(x => new
    {
        CategoryName = x.Category.Name,
        ProductName = x.Name,
        ProductPrice = x.Price,
        Width = (int?)x.ProductFeature.Width,
    }).Where(x => x.Width > 10 && x.ProductName.StartsWith("k")).ToListAsync();

    // Burada ThenInclude dediğimizde x nesnesi ondan önceki include ettiğimiz nesneyi temsil ediyor yani burada ThenInclude içerisinde bulunan 'x' Product nesnesini temsil ediyor.
    var categories = _context.Categories.Include(x => x.Products).ThenInclude(x => x.ProductFeature).Select(x => new
    {
        CategoryName = x.Name,
        Products = String.Join(",", x.Products.Select(z => z.Name)),
        TotalPrice = x.Products.Sum(x => x.Price)

    }).Where(y => y.TotalPrice > 100).OrderByDescending(x => x.TotalPrice).ToList();


    Console.WriteLine("");



    #region Data Insert
    //var category = new Category() { Name = "Kitaplar" };
    //category.Products.Add(new() { Name = "Kitap 1", Price = 150, Stock = 200, Barcode = 12123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 200 } });
    //category.Products.Add(new() { Name = "Kitap 2", Price = 300, Stock = 200, Barcode = 1256, ProductFeature = new ProductFeature() { Color = "Blue", Height = 260, Width = 100 } });
    //category.Products.Add(new() { Name = "Kitap 3", Price = 2300, Stock = 200, Barcode = 12, ProductFeature = new ProductFeature() { Color = "Brown", Height = 170, Width = 130 } });
    //category.Products.Add(new() { Name = "Kitap 4", Price = 1100, Stock = 200, Barcode = 1223, ProductFeature = new ProductFeature() { Color = "Black", Height = 252, Width = 120 } });
    //_context.Categories.Add(category);
    //_context.SaveChanges();
    #endregion


}


