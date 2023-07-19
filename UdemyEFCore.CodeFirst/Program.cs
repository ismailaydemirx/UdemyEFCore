// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    //var category = new Category()
    //{
    //    Name = "Kalemler",
    //};

    //category.Products.Add(new()
    //{
    //    Name = "Kalem1",
    //    Barcode = 123,
    //    Price = 122,
    //    Stock = 100,
    //    ProductFeature = new() { Color = "Red", Width = 10, Height = 20 }
    //});
    //category.Products.Add(new()
    //{
    //    Name = "Kalem2",
    //    Barcode = 123,
    //    Price = 200,
    //    Stock = 100,
    //    ProductFeature = new() { Color = "Blue", Width = 20, Height = 30 }
    //});

    //await _context.AddAsync(category);
    //await _context.SaveChanges();

    // Kategoriyi çekerken aynı anda kategoriye bağlı product'ları almak için bu kodu kullanıyoruz.
    // Birden fazla theninclude kullanılabilir.
    var categoryWithProducts = _context.Categories
        .Include(x => x.Products)
        .ThenInclude(x => x.ProductFeature)
        .ToList().First();


    categoryWithProducts.Products.ForEach(product =>
    {
        Console.WriteLine($"{categoryWithProducts.Name} {product.Name} {product.ProductFeature.Color}");
    });

    var productFeature = _context.ProductFeature.Include(x=>x.Product).ThenInclude(x=>x.Category).First();


    Console.WriteLine("Done!");
}
