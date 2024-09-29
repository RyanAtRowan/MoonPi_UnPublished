using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Portfolio.Controllers
{
    /// <summary>
    /// Controller responsible for handling account-related actions, including a demo login.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;


        /// <summary>
        /// Initializes the AccountController with dependencies.
        /// </summary>
        /// <param name="signInManager">ASP.NET Identity SignInManager for managing user sign-in.</param>
        /// <param name="logger">Logger for logging information or errors.</param>
        public AccountController(SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }


        /// <summary>
        /// Signs in a predefined demo user without requiring account creation.
        /// </summary>
        /// <returns>Redirects to the previous page if login is successful, or to the login page if it fails.</returns>
        public async Task<IActionResult> DemoLogin()
        {

            // Predefined demo user credentials
            var demoEmail = "demo@user.com";
            var demoPassword = "Demo123!";

            // Attempt to sign in the demo user
            var result = await _signInManager.PasswordSignInAsync(demoEmail, demoPassword, isPersistent: false, lockoutOnFailure: false);

            // Handle login result
            if (result.Succeeded)
            {
                _logger.LogInformation("Demo user logged in.");
                // Redirect back to the referring page
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                _logger.LogWarning("Demo login attempt failed.");
                // Redirect to the login page if demo login fails
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
