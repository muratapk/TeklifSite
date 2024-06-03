using System.ComponentModel.DataAnnotations;

namespace TeklifSite.Models
{
    public class Offers
    {
        [Key]
        public int OfferId { get; set; }
        public int? CartId { get; set; }
        virtual public Carts? Carts { get; set; }
        public int? ProductId { get; set; }
        virtual public Products? Products { get; set; }  
        public int? CustomerId { get; set; }
        virtual public Customers? Customers { get;set; }        
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
