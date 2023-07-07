using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.DatabaseFirst.DAL
{
    // bu bizim yüklediğimiz paketin içinde bulunan bir interface. Veritabanı Yoluna erişmek için bunu kullanacağız.
    public class DbContextInitializer // veritabanıyla alakalı kodları burada kullanacağım.
    {

        public static IConfigurationRoot Configuration;
        public static DbContextOptionsBuilder<AppDbContext> OptionsBuilder;

        public static void Build()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
            OptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            OptionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlCon"));
        }

    }
}
