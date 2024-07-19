using Microsoft.AspNetCore.Components.Routing;

namespace Portfolio.Models
{
    public class Favorite
    {
        public int userId { get; set; }
        public User user { get; set; }

        public int scrollId { get; set; }
        public Scroll scroll { get; set; }
    }
}
