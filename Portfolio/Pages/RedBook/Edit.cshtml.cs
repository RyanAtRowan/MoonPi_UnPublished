using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Pages.RedBook
{
    /// <summary>
    /// The PageModel for editing the price of a scroll in the RedBook application.
    /// </summary>
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db; // Database context for interacting with scroll data

        /// <summary>
        /// Bound property to hold the scroll data being edited.
        /// </summary>
        [BindProperty]
        public Scroll Scroll { get; set; }

        /// <summary>
        /// Property to store the original price of the scroll before editing.
        /// </summary>
        public int OriginalPrice { get; set; }


        /// <summary>
        /// Initializes the EditModel with the application database context.
        /// </summary>
        /// <param name="db">The ApplicationDbContext instance for database access.</param>
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Handles the GET request to load the scroll data for editing.
        /// </summary>
        /// <param name="id">The ID of the scroll to be edited.</param>
        /// <returns>The page result with the scroll data if successful; otherwise, a NotFound result.</returns>
        public IActionResult OnGet(int? id)
        {
            // Check if the scroll ID is valid
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Retrieve the scroll from the database
            Scroll = _db.Scrolls.Find(id);

            // Check if the scroll exists
            if (Scroll == null)
            {
                return NotFound();
            }

            // Store the original price to be displayed on the page
            OriginalPrice = Scroll.Price;

            // Return the page with the scroll data for editing
            return Page();
        }

        /// <summary>
        /// Handles the POST request to update the scroll's price.
        /// </summary>
        /// <returns>Redirects to the index page upon success, or redisplays the page if validation fails.</returns>
        public IActionResult OnPost()
        {
            // Retrieve the scroll from the database
            var scrollFromDb = _db.Scrolls.Find(Scroll.Id);

            // Check if the scroll exists in the database
            if (scrollFromDb == null)
            {
                return NotFound();
            }

            // Store the original price to display it on the page after submission
            OriginalPrice = scrollFromDb.Price; // Preserve the original price

            // Validate the model before saving
            if (ModelState.IsValid)
            {
                // Update the scroll's price
                scrollFromDb.Price = Scroll.Price;
                _db.SaveChanges(); // Save the updated price to the database

                // Display success message and redirect to the index page
                TempData["success"] = "Scroll price has been updated!";
                return RedirectToPage("Index");
            }

            // If validation fails, repopulate the scroll data from the database
            Scroll.Name = scrollFromDb.Name;
            Scroll.Slot = scrollFromDb.Slot;
            Scroll.Stat = scrollFromDb.Stat;
            Scroll.Success = scrollFromDb.Success;

            // Return the page with validation errors
            return Page();
        }
    }
}
