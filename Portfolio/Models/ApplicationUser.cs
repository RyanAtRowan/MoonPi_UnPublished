using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name {  get; set; }
    }
}
