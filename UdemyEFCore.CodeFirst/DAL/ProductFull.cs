using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    [Keyless]
    public class ProductFull
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
    }
}
