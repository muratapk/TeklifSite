using System.ComponentModel.DataAnnotations;

namespace TeklifSite.Models
{
    public class Carts
    {
        [Key]
        public int CardId { get; set; }
        public long ProducutId { get; set; }
        virtual public Products Products { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int? Quantity { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        virtual public List<Offers>?Offers { get; set; }  
    }
}
