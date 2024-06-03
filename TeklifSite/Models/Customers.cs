using System.ComponentModel.DataAnnotations;

namespace TeklifSite.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        virtual public List<Offers>?Offers { get; set; }
    }
}
