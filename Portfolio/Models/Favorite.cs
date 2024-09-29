using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    /// <summary>
    /// Represents a user's favorite scroll.
    /// This model stores the user's ID and the ID of the scroll they have marked as a favorite.
    /// </summary>
    public class Favorite
    {
        /// <summary>
        /// Unique identifier for the favorite entry.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ID of the user who marked the scroll as a favorite.
        /// This corresponds to the user's Identity in the application.
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// The ID of the scroll that has been marked as a favorite.
        /// </summary>
        [Required]
        public int ScrollId { get; set; }
    }
}
