using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneBook_ASP.NETMVC.Models
{
    //DropCreateDatabaseAlways<PhoneBookDbContext>
    public class PhoneBookDbInitializer : CreateDatabaseIfNotExists<PhoneBookDbContext>
    {
        protected override void Seed(PhoneBookDbContext context)
        {
            Person p1 = new Person { FirstName = "Petr", LastName = "Petrov" };
            Person p2 = new Person { FirstName = "Ivan", LastName = "Ivanov" };

            List<Phone> numbers = new List<Phone>(){
                new Phone { Number = "+380991234567", Person = p1 },
                new Phone { Number = "+380661234567", Person = p1 },
                new Phone { Number = "+380331234567", Person = p2 }
            };

            context.Persons.Add(p1);
            context.Persons.Add(p2);
            numbers.ForEach(num => context.Phones.Add(num));

            base.Seed(context);
        }
    }
}