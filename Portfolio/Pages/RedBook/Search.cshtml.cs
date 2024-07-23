using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Pages.RedBook
{
    public class SearchModel : PageModel
    {

        public IActionResult OnPost()
        {
            // Retrieve form inputs
            var item = Request.Form["item"];
            var stat = Request.Form["stat"];
            string success = Request.Form["rate"].ToString();


            // Redirect to results page
            return RedirectToPage("Results", new { item, stat, success});
        }

    }
}
