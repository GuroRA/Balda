using Microsoft.EntityFrameworkCore;

namespace Balda
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersbd;Username=postgres;Password=gevgehev");
        }
    }
}
