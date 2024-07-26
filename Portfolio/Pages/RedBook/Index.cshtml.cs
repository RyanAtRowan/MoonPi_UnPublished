using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Pages.RedBook
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public List<Scroll> Scrolls { get; set; }
        public HashSet<int> FavoriteIds { get; set; }


        public IndexModel(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            FavoriteIds = new HashSet<int>();
            Scrolls = new List<Scroll>();
        }



        public async Task OnGetAsync()
        {
            Top10();

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
        }

        public void Top10()
        {
            Scrolls = _db.Scrolls.OrderByDescending(u => u.Price).Take(10).ToList();
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
