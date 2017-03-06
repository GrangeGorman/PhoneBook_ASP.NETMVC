using System.Collections.Generic;

namespace PhoneBook_ASP.NETMVC.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Phone> Phones { get; set; }
    }
}