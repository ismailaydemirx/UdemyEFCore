// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    var category = _context.Categories.First();
    _context.Categories.Remove(category);

    //var category = new Category()
    //{
    //    Name = "Kalemler",
    //    Products = new List<Product>()
    //    {
    //        new() {Name="Kalem1",Price=100,Stock=200,Barcode=123,},
    //        new() {Name="Kalem2",Price=100,Stock=200,Barcode=123,},
    //        new() {Name="Kalem3",Price=100,Stock=200,Barcode=123,}
    //    }
    //};

    //_context.Add(category);
    _context.SaveChanges();
    
    Console.WriteLine("Done!");
}
