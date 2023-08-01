using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL.Models
{
    public class ProductEssnetial
    {
        public string Name { get; set; }
        
        public decimal Price { get; set; }
    }
}
