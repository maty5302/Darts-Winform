using Domain;
using Domain.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace šipky_Forms.Database
{
    public class DbSipky
    {
        public class MyDatabase : DbContext
        {
            public DbSet<UserSettings> UserSettings { get; set; }
            public DbSet<Player> PlayerSettings { get; set; }
            public DbSet<PlayerPanels> PlayerPanels { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                string connectionstring = "Data Source=mydb.db";
                optionsBuilder.UseSqlite(connectionstring);
            }
        }
    }
}
