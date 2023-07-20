// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{

    var category = await _context.Categories.FirstAsync();
    Console.WriteLine("Category çekildi");
    var products = category.Products;

    // (N+1) PROBLEM
    foreach (var item in products) // foreach metodunda lazy loading kullandığımız bir navigation property'e erişirsek her döngü başladığında veritabanına sorgu gönderiyor bu da performansı düşürüyor. O yüzden lazy loading kullandığımızda dikkatli olmamız lazım.
    {
        var productFeature = item.ProductFeature;
    }

    Console.WriteLine("Done!");
}
