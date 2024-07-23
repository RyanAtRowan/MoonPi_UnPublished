using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mono.TextTemplating;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Pages.RedBook
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Scroll> Scrolls { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Top10();
        }

        public void Top10()
        {
            Scrolls = _db.Scrolls.OrderByDescending(u => u.Price).Take(10).ToList();
        }

    }
}
