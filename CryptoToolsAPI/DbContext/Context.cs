using CryptoToolsAPI.DbContext.Settings;
using CryptoToolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CryptoToolsAPI.DbContext
{
    public class Context: Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly DbSettings _settings;

        public Context(IOptions<DbSettings> settings) 
        { 
            _settings = settings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_settings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasKey(x => new { x.ID });
            modelBuilder.Entity<Users>().Property(u => u.Enabled).HasConversion(v => v ? 1 : 0, v => v == 1);
            modelBuilder.Entity<Log>().HasKey(x => new { x.ID });
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        
    }
}
