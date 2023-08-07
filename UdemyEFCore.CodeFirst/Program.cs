// See https://aka.ms/new-console-template for more information

using AutoMapper.QueryableExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Linq;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;
using UdemyEFCore.CodeFirst.DTOs;
using UdemyEFCore.CodeFirst.Mappers;

Initializer.Build();

var connection = new SqlConnection(Initializer.Configuration.GetConnectionString("SqlCon"));

IDbContextTransaction transaction = null;

var _context = new AppDbContext(connection); // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    // Transaction | Multiple DbContext Instance
    transaction = _context.Database.BeginTransaction();
    var category = new Category() { Name = "Kılıflar" };
    _context.Categories.Add(category);

    _context.SaveChanges();

    Product product = new()
    {
        Name = "Kılıf 4",
        Price = 150,
        Stock = 200,
        Barcode = 12123,
        DiscountPrice = 200,
        CategoryId = category.Id
    };
    _context.Products.Add(product);
    _context.SaveChanges();


    #region Data Insert
    //var category = new Category() { Name = "Kitaplar" };
    //category.Products.Add(new() { Name = "Kitap 1", Price = 150, Stock = 200, Barcode = 12123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 200 } });
    //category.Products.Add(new() { Name = "Kitap 2", Price = 300, Stock = 200, Barcode = 1256, ProductFeature = new ProductFeature() { Color = "Blue", Height = 260, Width = 100 } });
    //category.Products.Add(new() { Name = "Kitap 3", Price = 2300, Stock = 200, Barcode = 12, ProductFeature = new ProductFeature() { Color = "Brown", Height = 170, Width = 130 } });
    //category.Products.Add(new() { Name = "Kitap 4", Price = 1100, Stock = 200, Barcode = 1223, ProductFeature = new ProductFeature() { Color = "Black", Height = 252, Width = 120 } });
    //_context.Categories.Add(category);
    //_context.SaveChanges();
    #endregion

    // 2. bir context ve transaction daha tanımlıyoruz.
    var dbContext2 = new AppDbContext(connection);

    dbContext2.Database.UseTransaction(transaction.GetDbTransaction());

    var product3 = dbContext2.Products.First();
    product3.Stock = 1000;
    dbContext2.SaveChanges();

    transaction.Commit();
    _context.Dispose();
    dbContext2.Dispose();
    transaction.Dispose();
    Console.WriteLine("");

}
