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
        public DbSet<PupprProfile> Join { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagProfile> TagProfiles { get; set; }
    }
}