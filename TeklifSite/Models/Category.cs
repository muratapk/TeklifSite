using System.ComponentModel.DataAnnotations;

namespace TeklifSite.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        virtual  public List<Products>? Products { get; set; }   

    }
}
