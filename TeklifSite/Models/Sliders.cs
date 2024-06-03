using System.ComponentModel.DataAnnotations;

namespace TeklifSite.Models
{
    public class Sliders
    {
        [Key]
        public int SliderId { get; set; }
        public string SliderName { get; set; } = string.Empty;
        public string Header1 { get; set; } = string.Empty;
        public string Heeader2 { get; set; } = string.Empty;
        public string Context { get; set; } = string.Empty;
        public string SliderImage { get; set; } = string.Empty;
    }
}
