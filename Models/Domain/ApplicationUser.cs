using Microsoft.AspNetCore.Identity;

namespace EventPlan1.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
