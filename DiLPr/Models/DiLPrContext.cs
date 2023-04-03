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
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserPuppr> Join { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Puppr> Pupprs { get; set; }
    }
}