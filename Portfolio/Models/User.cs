using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public ICollection<Favorite> Favorites { get; set; }
    }
}
