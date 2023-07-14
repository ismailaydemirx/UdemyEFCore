// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    // Product => Parent
    // ProductFeature => Child

    var category = _context.Categories.First(x => x.Name == "Silgiler");

    var product = new Product { Name = "Silgi10", Price = 200, Stock = 200, Barcode = 123, Category = category, };


    ProductFeature productFeature = new ProductFeature() { Color = "Blue", Width = 200, Height = 100, Product = product };

    _context.ProductFeature.Add(productFeature);
    _context.SaveChanges();
    Console.WriteLine("Saved!");
}

void CRUDSettings()
{
    //product.ForEach(p =>
    //{

    //    var state = _context.Entry(p).State;
    //    Console.WriteLine($"{p.Id} : {p.Name} - {p.Price} - {p.Stock} state: {state}");
    //});


    //Console.WriteLine($"Context Id? {_context.ContextId}");

    //_context.SaveChanges();
    //_context.Update(new Product() { Id = 5, Name = "Defter", Price = 150, Stock = 100, Barcode = 425 });
    //_context.Entry(product).State = EntityState.Deleted; üstteki ile aynı.

    //await _context.SaveChangesAsync();
    //Console.WriteLine("save change state: " + _context.Entry(product).State);

    //_context.Entry(product).State = EntityState.Added;

    //await _context.AddAsync(newProduct);


    //var products = await _context.Products.AsNoTracking().ToListAsync();//git veritabanıyla haberleş demek - ToListAsync asenkron olduğundan başına 'await' keyword'ü ekledik.
}