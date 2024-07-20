using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            Scrolls = _db.Scrolls.OrderByDescending(s => s.Price).Take(10).ToList();
        }
    }
}
