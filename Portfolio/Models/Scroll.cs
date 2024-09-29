using CsvHelper.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    /// <summary>
    /// Represents a scroll item in the Red Book system.
    /// Contains information about the scroll's name, slot, stat, success rate, and price.
    /// </summary>
    public class Scroll
    {
        /// <summary>
        /// Unique identifier for the scroll.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the scroll.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The equipment slot that the scroll is applicable to (e.g., weapon, armor).
        /// </summary>
        [Required]
        public string Slot { get; set; }

        /// <summary>
        /// The stat that the scroll affects (e.g., strength, dexterity).
        /// </summary>
        [Required]
        public string Stat { get; set; }

        /// <summary>
        /// Success rate of the scroll (percentage).
        /// </summary>
        [Required]
        public int Success { get; set; }

        /// <summary>
        /// The price of the scroll in the in-game currency.
        /// This value is restricted to a maximum of 2 billion.
        /// </summary>
        [Range(0, 2000000000)]
        public int Price { get; set; }
    }

    /// <summary>
    /// Maps the Scroll class properties to CSV column names using CsvHelper.
    /// </summary>
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
