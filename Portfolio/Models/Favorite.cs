using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Favorite
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }

        [Required]
        public int ScrollId { get; set; }
        [Required]
        public Scroll Scroll { get; set; }
    }
}
