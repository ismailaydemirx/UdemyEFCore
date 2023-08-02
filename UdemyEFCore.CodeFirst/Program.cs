// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

GetProducts(1, 6).ForEach(x =>
{
    Console.WriteLine($"{x.Id} {x.Name} {x.Price}");
});

static List<Product> GetProducts(int page, int pageSize)
{
    using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
    {
        // page =1 pageSize = 3 -- ilk 3 data => skip:0 take:3 ((page-1)*pageSize) => (1-1)*3 -> 0 tane atladım.
        // page =2 pageSize = 3 -- ikinci 3 data => skip:3 take:3 ((page-1)*pageSize) => (2-1)*3 = 3 -> 3 tane atladım
        // page =3 pageSize = 3 -- üçüncü 3 data => skip:6 take:3 ((page-1)*pageSize) => (3-1)*3 = 6 -> 6 tane atladım.
        return _context.Products.Where(x => x.Price > 100).OrderByDescending(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();

        



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
}



