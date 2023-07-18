using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class IdentityContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public IdentityContext(DbContextOptions<IdentityContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
    }
}
