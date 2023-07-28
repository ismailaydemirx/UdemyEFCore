// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    _context.Products.Add(new() { Name = "Kalem1", Price=100,DiscountPrice=120, Barcode=123,Stock=1,Url="200"});
    _context.SaveChanges();

    Console.WriteLine("Done!");
}
