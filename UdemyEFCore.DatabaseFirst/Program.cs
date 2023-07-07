// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.DatabaseFirst.DAL;

DbContextInitializer.Build(); // DbContextInitializer sınıfımızda bulunan Static Build metodumuzu burada çalıştırdık. Nesne örneği üretmeden sınıf üzerinden direkt eriştik. artık daha BestPractice bir yolumuz oldu.

using (var _context = new AppDbContext(DbContextInitializer.OptionsBuilder.Options)) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    var products = await _context.Products.ToListAsync();//git veritabanıyla haberleş demek - ToListAsync asenkron olduğundan başına 'await' keyword'ü ekledik.

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} : {p.Name}");
    });
}
