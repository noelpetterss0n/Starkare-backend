using Microsoft.EntityFrameworkCore;
using starkare_backend.Models;

namespace starkare_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } // Table for Users

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configurations (Indexes, Relationships, etc.) can go here
        }
    }
}
