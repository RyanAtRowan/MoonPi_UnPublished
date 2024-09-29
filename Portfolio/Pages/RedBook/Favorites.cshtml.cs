using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Pages.RedBook
{
    /// <summary>
    /// The PageModel for the RedBook Favorites page, responsible for managing and displaying a user's favorite scrolls.
    /// </summary>
    public class FavoritesModel : PageModel
    {
        private readonly ApplicationDbContext _db; // Database context to interact with the scrolls and favorites data
        private readonly UserManager<IdentityUser> _userManager; // Manages user-related tasks such as retrieving the current user

        /// <summary>
        /// A list of scrolls that are marked as the user's favorites.
        /// </summary>
        public List<Scroll> Scrolls { get; set; }

        /// <summary>
        /// A set of scroll IDs that the current user has marked as favorites.
        /// </summary>
        public HashSet<int> FavoriteIds { get; set; }

        /// <summary>
        /// Initializes the FavoritesModel with the database context and user manager.
        /// </summary>
        /// <param name="db">The ApplicationDbContext instance.</param>
        /// <param name="userManager">The UserManager instance for managing user data.</param>
        public FavoritesModel(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            FavoriteIds = new HashSet<int>(); // Initialize the set of favorite scroll IDs
            Scrolls = new List<Scroll>(); // Initialize the list of favorite scrolls
        }

        /// <summary>
        /// Handles the GET request for the page, retrieves the user's favorite scrolls, and populates the Scrolls list.
        /// </summary>
        public async Task OnGetAsync()
        {
            // Retrieve the current logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                // Retrieve the IDs of the scrolls the user has marked as favorites
                FavoriteIds = new HashSet<int>(
                    await _db.Favorites
                        .Where(f => f.UserId == user.Id)
                        .Select(f => f.ScrollId)
                        .ToListAsync()
                );

                // Retrieve the favorite scrolls and populate the Scrolls list
                Favs();
            }
        }

        /// <summary>
        /// Populates the Scrolls list with the user's favorite scrolls.
        /// </summary>
        public void Favs()
        {
            // Query the database for scrolls whose IDs match the user's favorites
            Scrolls = _db.Scrolls
                        .Where(s => FavoriteIds.Contains(s.Id))
                        .ToList();
        }

        /// <summary>
        /// Handles the POST request to add or remove a scroll from the user's favorites.
        /// </summary>
        /// <param name="scrollId">The ID of the scroll to be added or removed from the favorites list.</param>
        /// <returns>A JSON result indicating whether the favorite was successfully toggled.</returns>
        public async Task<IActionResult> OnPost(int scrollId)
        {
            // Retrieve the current logged-in user
            var user = await _userManager.GetUserAsync(User);

            // If the user is not logged in, return Unauthorized
            if (user == null) return Unauthorized();

            // Check if the scroll is already in the user's favorites
            var favorite = await _db.Favorites
                .FirstOrDefaultAsync(f => f.UserId == user.Id && f.ScrollId == scrollId);

            // If the scroll is not a favorite, add it to the user's favorites
            if (favorite == null)
            {
                _db.Favorites.Add(new Favorite
                {
                    UserId = user.Id,
                    ScrollId = scrollId
                });
            }
            // If the scroll is already a favorite, remove it from the user's favorites
            else
            {
                _db.Favorites.Remove(favorite);
            }

            // Save changes to the database
            await _db.SaveChangesAsync();

            // Return a JSON result indicating success
            return new JsonResult(new { success = true });
        }


    }
}
