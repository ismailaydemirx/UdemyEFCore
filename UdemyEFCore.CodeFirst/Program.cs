// See https://aka.ms/new-console-template for more information

using AutoMapper.QueryableExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;
using UdemyEFCore.CodeFirst.DTOs;
using UdemyEFCore.CodeFirst.Mappers;

Initializer.Build();


using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    // Transaction | Transaction
    // 1 DEN FAZLA SAVECHANGES KULLANIRSAK HEMEN AKLIMIZA TRANSACTION YAPISI GELECEK!
    // Eğer ki bir loglama işlemi yapmayacaksak hiç try-catch bloguna almamıza gerek yok.
    // Try-Catch blogu açtığımızda RollBack ifadesini açık açık yazmalıyız.
    using (var transaction = _context.Database.BeginTransaction())
    {
        var category = new Category() { Name = "Kılıflar" };
        _context.Categories.Add(category);

        _context.SaveChanges();

        Product product = new()
        {
            Name = "Kılıf 1",
            Price = 150,
            Stock = 200,
            Barcode = 12123,
            DiscountPrice = 200,
            CategoryId = category.Id
        };

        _context.Products.Add(product);
        _context.SaveChanges();

        transaction.Commit();
        transaction.Rollback();
    }









    Console.WriteLine("");


    #region Data Insert
    //var category = new Category() { Name = "Kitaplar" };
    //category.Products.Add(new() { Name = "Kitap 1", Price = 150, Stock = 200, Barcode = 12123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 200 } });
    //category.Products.Add(new() { Name = "Kitap 2", Price = 300, Stock = 200, Barcode = 1256, ProductFeature = new ProductFeature() { Color = "Blue", Height = 260, Width = 100 } });
    //category.Products.Add(new() { Name = "Kitap 3", Price = 2300, Stock = 200, Barcode = 12, ProductFeature = new ProductFeature() { Color = "Brown", Height = 170, Width = 130 } });
    //category.Products.Add(new() { Name = "Kitap 4", Price = 1100, Stock = 200, Barcode = 1223, ProductFeature = new ProductFeature() { Color = "Black", Height = 252, Width = 120 } });
    //_context.Categories.Add(category);
    //_context.SaveChanges();
    #endregion


}


