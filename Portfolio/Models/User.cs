using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    /// <summary>
    /// Represents a user in the Red Book system.
    /// Contains the user's username, password, and their list of favorite scrolls.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The username of the user.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// The password for the user.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// A collection of the user's favorite scrolls.
        /// </summary>
        public ICollection<Favorite> Favorites { get; set; }
    }
}
