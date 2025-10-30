using Codex.Models;
using Microsoft.EntityFrameworkCore;

namespace Codex.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TypeUser> TypeUser { get; set; }
        public DbSet<Computers> Computers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
