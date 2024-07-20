using CsvHelper.Configuration;
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

    public class ScrollMap : ClassMap<Scroll>
    {
        public ScrollMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.Name).Name("Name");
            Map(m => m.Slot).Name("Slot");
            Map(m => m.Stat).Name("Stat");
            Map(m => m.Success).Name("Success");
            Map(m => m.Price).Name("Price");
        }
    }
}
