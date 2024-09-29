using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Pages.RedBook
{
    /// <summary>
    /// PageModel for displaying search results and managing favorite scrolls in the RedBook application.
    /// </summary>
    public class ResultsModel : PageModel
    {
        private readonly ApplicationDbContext _db; // Database context for interacting with the database
        private readonly UserManager<IdentityUser> _userManager; // UserManager for handling user-related tasks

        /// <summary>
        /// List of all scrolls retrieved from the search query.
        /// </summary>
        public List<Scroll> Scrolls { get; set; }

        /// <summary>
        /// Set of favorite scroll IDs for the current user.
        /// </summary>
        public HashSet<int> FavoriteIds { get; set; }

        /// <summary>
        /// List of search results based on the filters applied by the user.
        /// </summary>
        public List<Scroll>? SearchResults { get; set; }

        /// <summary>
        /// Initializes the ResultsModel with the database context and user manager.
        /// </summary>
        /// <param name="db">The ApplicationDbContext instance.</param>
        /// <param name="userManager">The UserManager instance for managing user data.</param>
        public ResultsModel(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            FavoriteIds = new HashSet<int>(); // Initialize the set for storing favorite IDs
            Scrolls = new List<Scroll>(); // Initialize the list of scrolls
        }


        /// <summary>
        /// Handles the GET request to search for scrolls based on item, stat, and success rate.
        /// </summary>
        /// <param name="item">The item slot (e.g., 'Bow', 'Helmet').</param>
        /// <param name="stat">The stat type (e.g., 'STR', 'DEX').</param>
        /// <param name="success">The success rate of the scroll (e.g., '30', '100').</param>
        /// <returns>Returns the page with the search results.</returns>
        public async Task<IActionResult> OnGetAsync(string item, string stat, string success)
        {
            // Convert the success string to an integer, or set to null if empty
            int? successInt = string.IsNullOrEmpty(success) ? (int?)null : int.Parse(success);

            // Start building the query by retrieving all scrolls
            var query = _db.Scrolls.AsQueryable();

            // Filter by item slot if provided
            if (!string.IsNullOrEmpty(item))
            {
                query = query.Where(u => u.Slot == item);
            }

            // Filter by stat if provided
            if (!string.IsNullOrEmpty(stat))
            {
                query = query.Where(u => u.Stat == stat);
            }

            // Filter by success rate if provided
            if (successInt.HasValue)
            {
                query = query.Where(u => u.Success == successInt);
            }

            // Execute the query and order the results by success rate in descending order
            SearchResults = await query.OrderByDescending(u => u.Success).ToListAsync();

            // Retrieve the current logged-in user
            var user = await _userManager.GetUserAsync(User);

            // If the user is logged in, retrieve their favorite scrolls
            if (user != null)
            {
                FavoriteIds = new HashSet<int>(
                    await _db.Favorites
                        .Where(f => f.UserId == user.Id)
                        .Select(f => f.ScrollId)
                        .ToListAsync()
                );
            }
            // Return the page with the results
            return Page();
        }

        /// <summary>
        /// Handles the POST request to add or remove a scroll from the user's favorites.
        /// </summary>
        /// <param name="scrollId">The ID of the scroll to be toggled as a favorite.</param>
        /// <returns>Returns a JSON result indicating success.</returns>
        public async Task<IActionResult> OnPost(int scrollId)
        {
            // Retrieve the current logged-in user
            var user = await _userManager.GetUserAsync(User);

            // If the user is not logged in, return an Unauthorized result
            if (user == null) return Unauthorized();

            // Check if the scroll is already in the user's favorites
            var favorite = await _db.Favorites
                .FirstOrDefaultAsync(f => f.UserId == user.Id && f.ScrollId == scrollId);

            // If the scroll is not in the favorites, add it
            if (favorite == null)
            {
                _db.Favorites.Add(new Favorite
                {
                    UserId = user.Id,
                    ScrollId = scrollId
                });
            }
            // If the scroll is already in the favorites, remove it
            else
            {
                _db.Favorites.Remove(favorite);
            }

            // Save the changes to the database
            await _db.SaveChangesAsync();

            // Return a JSON result indicating success
            return new JsonResult(new { success = true });
        }


    }
}
