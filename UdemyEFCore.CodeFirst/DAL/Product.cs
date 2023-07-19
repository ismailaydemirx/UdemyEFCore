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
    public class Product
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] // bu ifadeyi eklersek aşağıdaki Id primary key olur ancak birer birer artma özelliği kaybolur.
        public int Id { get; set; }
        public string Name { get; set; }
        [Precision(9,2)] // aşağıdaki Price da toplamda 18 karakter tutacağım virgülden sonra 2 karakter olabilir örnek: 1234567891111111.11
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }// şu an yaptığımız Set Null örneğinde Category Id'i nullable olacağı için Category'in de nullable olabilmesi adına "?" koyduk. ? koymamızın sebebi .NET 'de nullable özelliğinin Enable olmasından kaynaklı eğer "Disable" olsaydı Category'e "?" eklemeyecektik.
        public ProductFeature ProductFeature { get; set; }
    }
}
