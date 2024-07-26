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

        // Property to store the original price
        public int OriginalPrice { get; set; }

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

            // Store the original price
            OriginalPrice = Scroll.Price;

            // redirect to edit page passing scroll object
            return Page();
        }

        public IActionResult OnPost()
        {
            var scrollFromDb = _db.Scrolls.Find(Scroll.Id);
            if (scrollFromDb == null)
            {
                return NotFound();
            }

            OriginalPrice = scrollFromDb.Price; // Preserve the original price

            if (ModelState.IsValid)
            {
                scrollFromDb.Price = Scroll.Price;
                _db.SaveChanges();
                TempData["success"] = "Scroll price has been updated!";
                return RedirectToPage("Index");
            }

            // Repopulate Scroll object with existing data if validation fails
            Scroll.Name = scrollFromDb.Name;
            Scroll.Slot = scrollFromDb.Slot;
            Scroll.Stat = scrollFromDb.Stat;
            Scroll.Success = scrollFromDb.Success;

            return Page();
        }
    }
}
