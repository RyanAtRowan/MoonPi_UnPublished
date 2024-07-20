using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Scroll
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slot { get; set; }
        [Required]
        public string Stat { get; set; }
        [Required]
        public int Success { get; set; }
        // Make sure this never exceeds 2b
        public int Price { get; set; }

    }
}
