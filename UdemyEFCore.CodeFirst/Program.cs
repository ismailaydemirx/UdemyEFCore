// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    // aklımızda olsun eğer bir tablomuz varsa ve tablomuzda Id yoksa o tabloda CREATE, UPDATE VE DELETE işlemleri YAPILAMAZ. Sadece Read yapılabilir.
    //_context.Persons.Add(new Person() { FirstName="ismail", LastName="aydemir"});

    var person = _context.Persons.ToList();

    var productFulls = _context.ProductFulls.FromSqlRaw(@"SELECT p.Id,c.Name 'CategoryName',p.Name,p.Price,pf.Color,pf.Height FROM Products p
LEFT JOIN ProductFeature pf on p.Id = pf.Id
LEFT JOIN Categories c on p.Id = c.Id").ToList();


    //var category = new Category() { Name = "Kalemler" };
    //category.Products.Add(new() { Name = "kalem 3", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 100, Width = 200 } });
    //category.Products.Add(new() { Name = "kalem 4", Price = 130, Stock = 100, Barcode = 154, ProductFeature = new ProductFeature() { Color = "Blue", Height = 100, Width = 200 } });

    //_context.Add(category);
    //_context.SaveChanges();
    Console.WriteLine("Done!");
}
