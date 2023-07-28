using Microsoft.EntityFrameworkCore;
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
    [Index(nameof(Name),nameof(Url))]
    [Index(nameof(Url))]
    [Index(nameof(Name))] // aşağıda tanımladığımız Name property'ine göre index oluşturuyoruz.
    public class Product
    {

        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        [Precision(9, 2)] // aşağıdaki Price da toplamda 18 karakter tutacağım virgülden sonra 2 karakter olabilir örnek: 1234567891111111.11
        public decimal Price { get; set; }
        [Precision(9, 2)]
        public decimal DiscountPrice { get; set; }
        public int Stock { get; set; }

        public int Barcode { get; set; }

    }
}
