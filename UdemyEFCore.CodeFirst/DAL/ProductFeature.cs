using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Height { get; set; }
        public string Color { get; set; }
        public int ProductRefId { get; set; } // EF Core ProductId'yi burada ForeignKey olarak algılayacak. Bu durumda ProductFeature sınıfı CHILD olurken, Product sınıfı da PARENT oluyor.
        [ForeignKey("ProductRefId")]
        public Product Product { get; set; }
    }
}
