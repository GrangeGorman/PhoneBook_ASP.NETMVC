
namespace PhoneBook_ASP.NETMVC.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string Number { get; set; }
        public virtual Person Person { get; set; }
    }
}
