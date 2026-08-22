using Microsoft.EntityFrameworkCore;
using DataLayer.Models;

namespace DataLayer
{
    public class DartsDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<YearlyStatistic> YearlyStatistics { get; set; }
        
        private readonly string dbPath = "Darts.db";
        
        public DartsDbContext() { }
        public DartsDbContext(DbContextOptions<DartsDbContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasIndex(p => p.PlayerName)
                .IsUnique();
        }
    }
}