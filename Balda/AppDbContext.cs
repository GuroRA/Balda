using Microsoft.EntityFrameworkCore;

namespace Balda
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersbd;Username=postgres;Password=gevgehev");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Game and UserEntity (Players)
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Users);
        }
    }
}
