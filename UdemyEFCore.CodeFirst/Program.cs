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
    using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.Snapshot))
    {
        // Isolation Levels | Snapshot

        var products = context.Products.AsNoTracking().ToList();

        // business code

        var product2 = context.Products.ToList();


        transaction.Commit();

    }
}
