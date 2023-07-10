using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.DatabaseFirst.DAL
{
    public class Product // product entity'im veritabanında Product adında tabloya karşılık geliyor.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; } // int? buradaki soru işareti product tablosunda Stock sütununun NULLABLE yani boş değeri olabilir anlamına geliyor.
    }
}
