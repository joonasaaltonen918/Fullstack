using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventPlan1.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Host> Host { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<HostEvent> HostEvent { get; set; }
        
    }
}
