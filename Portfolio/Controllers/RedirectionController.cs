using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class RedirectionController : Controller
    {
        public IActionResult RedirectToRegister(string layout)
        {
            return RedirectToPage("/Account/Register", new { area = "Identity", layout });
        }

        public IActionResult RedirectToLogin(string layout)
        {
            return RedirectToPage("/Account/Login", new { area = "Identity", layout });
        }
    }
}
