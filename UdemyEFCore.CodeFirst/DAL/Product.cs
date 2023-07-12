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
    [Table("ProductTb", Schema ="products")]
    public class Product
    {
        //nullable açık ise nullable:false
        [Required] 
        public int Product_Id { get; set; }

        //[StringLength(100,MinimumLength =20)]
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; } // bunu sonradan eklediğim için bunun için bir migration yapmalıyım.
        public DateTime? CreatedDate { get; set; }
    }
}
