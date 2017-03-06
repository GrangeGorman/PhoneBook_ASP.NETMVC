using System.Data.Entity;

namespace PhoneBook_ASP.NETMVC.Models
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext() : base("name=PhoneBook_Connection") { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}