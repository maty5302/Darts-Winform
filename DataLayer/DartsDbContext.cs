using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;

namespace DataLayer
{
    public class DartsDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<YearlyStatistic> YearlyStatistics { get; set; }
        
        private readonly string dbPath;

        public DartsDbContext() 
        { 
            dbPath = GetDatabasePath();
        }

        public DartsDbContext(DbContextOptions<DartsDbContext> options) : base(options) 
        { 
            dbPath = GetDatabasePath();
        }

        private string GetDatabasePath()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            
            var appFolder = Path.Combine(path, "DartsCounter");
            
            Directory.CreateDirectory(appFolder);
            return Path.Combine(appFolder, "Darts.db");
        }

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