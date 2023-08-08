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

using (var context = new AppDbContext())
{
    using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
    {
        // Isolation Levels | Serializable

        //var products = context.Products.ToList();

        // Burada ReeatableRead ile en üstteki iki veriyi take ile aldık artık o verileri ne silebiliriz ne de güncelleyebiliriz.

        var product = context.Products.ToList();

        //product.Price = 3000;

        //context.Products.Add(new Product() { Name = "a", Price = 1, Barcode = 2, CategoryId = 1, DiscountPrice = 1 });
        //context.SaveChanges();

        transaction.Commit();

    }
}
