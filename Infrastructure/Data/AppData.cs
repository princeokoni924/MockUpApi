using Core.Models;
using Infrastructure.ServiceRegistration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{

    public class AppData(DbContextOptions _dbOption) : DbContext(_dbOption)
    {
        public DbSet<ObjectModel> Objects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Config).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
