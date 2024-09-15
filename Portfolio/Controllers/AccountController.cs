using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Portfolio.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> DemoLogin()
        {

            // Assuming you have a predefined demo user (e.g., "demo@user.com")
            var demoEmail = "demo@user.com";
            var demoPassword = "Demo123!"; // You can set a default password

            // Sign in the demo user
            var result = await _signInManager.PasswordSignInAsync(demoEmail, demoPassword, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("Demo user logged in.");
                return LocalRedirect("~/RedBook/Index"); // Redirect to your main page or demo area
            }
            else
            {
                _logger.LogWarning("Demo login attempt failed.");
                return RedirectToAction("Login", "Account"); // Redirect to login page if demo login fails
            }
        }
    }
}
