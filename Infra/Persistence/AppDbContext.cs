using Microsoft.EntityFrameworkCore;
using BookHub.API.Entities;

namespace BookHub.API.Infra.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=BookHub;Username=postgres;Password=123");

    }
}