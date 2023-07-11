﻿// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    var product = await _context.Products.FirstAsync(x => x.Id == 3);
    product.Name = "ismail";
    Console.WriteLine(_context.Entry(product).State);
    //products.ForEach(p =>
    //{

    //    var state = _context.Entry(p).State;
    //    Console.WriteLine($"{p.Id} : {p.Name} - {p.Price} - {p.Stock} state: {state}");
    //});


    //Console.WriteLine($"Context Id? {_context.ContextId}");

    // _context.SaveChanges();
    //_context.Update(new Product() { Id=5,Name="Defter",Price=150,Stock=100,Barcode=425});
    //_context.Entry(product).State = EntityState.Deleted; üstteki ile aynı.

    //await _context.SaveChangesAsync();
    // Console.WriteLine("save change state: " + _context.Entry(product).State);

    //_context.Entry(product).State = EntityState.Added;

    //await _context.AddAsync(newProduct);


    //var products = await _context.Products.AsNoTracking().ToListAsync();//git veritabanıyla haberleş demek - ToListAsync asenkron olduğundan başına 'await' keyword'ü ekledik.


}
