using Microsoft.EntityFrameworkCore;
using RentTrack.Api.Data.Configurations;
using RentTrack.Api.Models;

namespace RentTrack.Api.Data
{
    public class RentTrackDbContext : DbContext
    {
        public RentTrackDbContext(DbContextOptions<RentTrackDbContext> options) : base(options)
        {
            
        }

        public DbSet<Property> Properties => Set<Property>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
        }
    }
}
