using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Pages.RedBook
{
    public class ResultsModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public List<Scroll> Scrolls { get; set; }
        public HashSet<int> FavoriteIds { get; set; }


        public ResultsModel(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            FavoriteIds = new HashSet<int>();
            Scrolls = new List<Scroll>();
        }

        public List<Scroll>? SearchResults { get; set; }

        public async Task<IActionResult> OnGetAsync(string item, string stat, string success)
        {
            // Convert success to int
            int? successInt = string.IsNullOrEmpty(success) ? (int?)null : int.Parse(success);

            var query = _db.Scrolls.AsQueryable();

            if (!string.IsNullOrEmpty(item))
            {
                query = query.Where(u => u.Slot == item);
            }

            if (!string.IsNullOrEmpty(stat))
            {
                query = query.Where(u => u.Stat == stat);
            }

            if (successInt.HasValue)
            {
                query = query.Where(u => u.Success == successInt);
            }

            SearchResults = await query.OrderByDescending(u => u.Success).ToListAsync();



            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                FavoriteIds = new HashSet<int>(
                    await _db.Favorites
                        .Where(f => f.UserId == user.Id)
                        .Select(f => f.ScrollId)
                        .ToListAsync()
                );
            }

            //// If this is an AJAX request, return the SearchResults as JSON for DataTables
            //if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //{
            //    return new JsonResult(new { data = SearchResults });
            //}

            return Page();
        }

        public async Task<IActionResult> OnPost(int scrollId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var favorite = await _db.Favorites
                .FirstOrDefaultAsync(f => f.UserId == user.Id && f.ScrollId == scrollId);

            if (favorite == null)
            {
                _db.Favorites.Add(new Favorite
                {
                    UserId = user.Id,
                    ScrollId = scrollId
                });
            }
            else
            {
                _db.Favorites.Remove(favorite);
            }

            await _db.SaveChangesAsync();
            return new JsonResult(new { success = true });
        }


    }
}
