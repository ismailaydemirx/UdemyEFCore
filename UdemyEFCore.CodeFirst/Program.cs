// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    _context.Products.Where(x => x.Name == "kalem").Select(x => new { name = x.Name, Price = x.Price, Stock = x.Stock, Barcode = x.Barcode });

    Console.WriteLine("Done!");
}
