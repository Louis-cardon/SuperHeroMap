using Microsoft.EntityFrameworkCore;

namespace SuperHeroMapApi.Data
{
    public class SuperHeroMapContext : DbContext
    {

        public SuperHeroMapContext(DbContextOptions<SuperHeroMapContext> options) : base(options)
        {
        }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentResource> IncidentResources { get; set; }
        public DbSet<SuperHero> SuperHeros { get; set; }
        public DbSet<SuperHeroIncident> SuperHeroIncidents { get; set; }
        public DbSet<SuperHeroIncidentResource> SuperHeroIncidentResources { get; set; }

    }
}
