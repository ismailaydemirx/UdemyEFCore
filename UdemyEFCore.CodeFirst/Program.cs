// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();


using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{

    var product = _context.Products.First(x=>x.Id==2);
    product.Name = "Defter 22";
    _context.Update(product); // AppDbContext.cs dosyası içinde NoTracking'i global olarak tanımladık o yüzden üst kısımda product.Name'e değer verirken 'Update' fonksiyonunu çağırmalıyız ki veriyi güncelleyebilsin.
    _context.SaveChanges();

    
    Console.WriteLine("");



    #region Data Insert
    //var category = new Category() { Name = "Defterler" };
    //category.Products.Add(new() { Name = "Defter 1", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "Defter 2", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "Defter 3", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "Defter 4", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //_context.Categories.Add(category);
    //_context.SaveChanges();
    #endregion


}


