using Data.Models;
using Data.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Data
{
    public class MaintenanceContext : DbContext
    {
        public MaintenanceContext(DbContextOptions<MaintenanceContext> options)
            :base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");

            #region Seeders
            UserSeeder.Seed(modelBuilder);
            #endregion

        }
    }
}
