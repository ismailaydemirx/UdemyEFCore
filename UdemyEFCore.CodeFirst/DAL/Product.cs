using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        public int Category_Id { get; set; } // Category şu anda parent olarak farzediyoruz EF Core burada belirttiğimiz CategoryId 'yi foreign key olarak algılıyor. Id yazısının önündeki ek olan Category ekinden bu durumu anlıyor.
        // Navigation Property
        
        public Category Category { get; set; } // Burada Category veritabanında oluşmayacak, bunlar EF Core'da Product'dan Category'e, Category'den Product'a geçmek için kullandığımız navigation property'lerdir.
    }
}
