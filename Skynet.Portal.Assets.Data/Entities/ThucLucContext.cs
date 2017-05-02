using Microsoft.EntityFrameworkCore;

namespace Skynet.Portal.Assets.Data.Entities
{
    public class ThucLucContext : DbContext
    {
        public ThucLucContext(DbContextOptions<ThucLucContext> options)
           : base(options)
        {
        }

        public DbSet<ThietBi> ThietBis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThietBi>()
                .HasAlternateKey(c => c.MaThietBi);
        }
    }
}
