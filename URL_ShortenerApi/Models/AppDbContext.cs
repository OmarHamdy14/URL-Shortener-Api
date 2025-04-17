using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace URL_ShortenerApi.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions op) : base(op)
        {

        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    }
}
