using Microsoft.EntityFrameworkCore;

namespace Organizer.Infrastructure
{
    public class OrganizerDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public OrganizerDbContext(DbContextOptions<OrganizerDbContext> options) : base(options)
        {
            
        }
    }
}
