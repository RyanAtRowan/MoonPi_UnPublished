using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Pages.RedBook
{
    /// <summary>
    /// PageModel for handling the search functionality in the Red Book.
    /// Retrieves form inputs from the search form and redirects to the results page.
    /// </summary>
    public class SearchModel : PageModel
    {
        /// <summary>
        /// Handles the form submission and redirects to the Results page with the search parameters.
        /// </summary>
        /// <returns>Redirects to the Results page with the selected search parameters.</returns>
        public IActionResult OnPost()
        {
            // Retrieve form inputs
            var item = Request.Form["item"];
            var stat = Request.Form["stat"];
            string success = Request.Form["rate"].ToString();


            // Redirect to the results page, passing the search parameters
            return RedirectToPage("Results", new { item, stat, success});
        }

    }
}
