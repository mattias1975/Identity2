using Microsoft.AspNetCore.Identity;
using Identity.Models;
namespace Identity.Models
{
    public class AppUser : IdentityUser
    {
        public int UserNumber { get; set; }
        public bool Admin { get; set; }
    }
}
