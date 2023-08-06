// See https://aka.ms/new-console-template for more information

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
    // Porjections | DTO/View Module / AutoMapper-1


    //var productsDto = _context.Products.Select(x => new ProductDto
    //{
    //    Id = x.Id,
    //    Name = x.Name,
    //    Price = x.Price,
    //    DiscountPrice = x.DiscountPrice,
    //    Stock= x.Stock,
    //}).ToList();


    var product = _context.Products.ToList();
    // ObjectMapper sınıfına git, Mapper üzerinden Map'le ProductDto'yu Product'a maple. Liste geleceği için liste olduğunu da belirttik.
    var productDto = ObjectMapper.Mapper.Map<List<ProductDto>>(product);




    Console.WriteLine("");





    // Burada select ve navigation property'ler sayesinde include'lardan kurtulduk ek olarak yeni bir Nesne örneği tanımlayarak (ProductDto) nesnemizin istediğimiz özelliklerini seçtik.

    //var products = await _context.Products.Select(x => new ProductDto
    //{
    //    CategoryName = x.Category.Name,
    //    ProductName = x.Name,
    //    ProductPrice = x.Price,
    //    Width = (int?)x.ProductFeature.Width

    //}).Where(x => x.Width > 10 && x.ProductName.StartsWith("k")).ToListAsync();

    // Burada select ve navigation property'ler sayesinde include'lardan kurtulduk ek olarak yeni bir Nesne örneği tanımlayarak (ProductDto) nesnemizin istediğimiz özelliklerini seçtik.
    //var categories = _context.Categories.Select(x => new ProductDto2
    //{
    //    CategoryName = x.Name,
    //    ProductsName = String.Join(",", x.Products.Select(z => z.Name)),
    //    TotalPrice = x.Products.Sum(x => x.Price),
    //    TotalWidth = (int?)x.Products.Select(x => x.ProductFeature.Width).Sum()

    //}).Where(y => y.TotalPrice > 100).OrderByDescending(x => x.TotalPrice).ToList();






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


