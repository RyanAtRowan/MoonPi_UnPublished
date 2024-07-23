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

        public ResultsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Scroll> SearchResults { get; set; }

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

            return Page();
        }
    }
}
