using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DiLPr.Models
{
    public class DiLPrContext : IdentityDbContext<AppUser>
    {
        public DiLPrContext(DbContextOptions<DiLPrContext> options)
            : base(options)
        {
        }
        public DbSet<DiLPr.Models.AppUser> AppUsers { get; set; }
    }
}