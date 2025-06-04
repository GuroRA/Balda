using Microsoft.EntityFrameworkCore;

namespace Balda
{
    /// <summary>
    /// Контекст баззы данных
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Привязка модели игрока к базе данных
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }
        /// <summary>
        /// Привязка модели игры к базе данных
        /// </summary>
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersbd;Username=postgres;Password=gevgehev");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Users);
        }
    }
}
