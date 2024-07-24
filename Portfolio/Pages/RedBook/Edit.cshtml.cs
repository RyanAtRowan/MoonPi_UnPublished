using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Pages.RedBook
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Scroll Scroll { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
            // Check id has value
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Save scroll using id
            Scroll = _db.Scrolls.Find(id);

            // Verify that the passed id is a valid scroll
            if (Scroll == null)
            {
                return NotFound();
            }

            // redirect to edit page passing scroll object
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Scroll scrollFromDb = _db.Scrolls.Find(Scroll.Id);
                if (scrollFromDb == null)
                {
                    return NotFound(); 
                }

                scrollFromDb.Price = Scroll.Price;
                _db.SaveChanges();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
