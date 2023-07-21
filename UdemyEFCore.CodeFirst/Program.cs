// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst;
using UdemyEFCore.CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext()) // using kullanmamızın sebebi işlemimiz bittiği zaman bu new'leme yaptığımız işlem memory'den dispose olsun yani silinsi ki boş yer kaplamasın.
{
    var managers = _context.Managers.ToList();
    var employees = _context.Employees.ToList();

    var persons = _context.Persons.ToList();

    persons.ForEach(person =>
    {
        switch (person)
        {
            case Manager managers:
                Console.WriteLine($"manager entity : {managers.Grade}");
                break;


            case Employee employees:
                Console.WriteLine($"employee entity: {employees.Salary}");
                break;

            default: break;
        }
    });
    //_context.Persons.Add(new Manager() { FirstName = "ismail", LastName = "Aydemir", Age = 23, Grade = 1 });
    //_context.Persons.Add(new Employee() { FirstName = "ersin", LastName = "Aydemir", Age = 23, Salary=1000 });

    _context.SaveChanges();
    Console.WriteLine("Done!");
}
