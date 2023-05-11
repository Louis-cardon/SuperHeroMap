namespace SuperHeroMapApi.Services
{
    public interface ISuperHeroIncidentResourceService
    {
        Task<IEnumerable<SuperHeroIncidentResource>> GetSuperHeroIncidentResources();
        Task<SuperHeroIncidentResource> GetSuperHeroIncidentResource(int id);
        Task AddSuperHeroIncidentResource(SuperHeroIncidentResource superHeroIncidentResource);
        Task UpdateSuperHeroIncidentResource(SuperHeroIncidentResource superHeroIncidentResource);
        Task DeleteSuperHeroIncidentResource(SuperHeroIncidentResource superHeroIncidentResource);
    }

    public class SuperHeroIncidentResourceService : ISuperHeroIncidentResourceService
    {
        private readonly SuperHeroMapContext _context;

        public SuperHeroIncidentResourceService(SuperHeroMapContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SuperHeroIncidentResource>> GetSuperHeroIncidentResources()
        {
            return await _context.SuperHeroIncidentResources.ToListAsync();
        }

        public async Task<SuperHeroIncidentResource> GetSuperHeroIncidentResource(int id)
        {
            return await _context.SuperHeroIncidentResources.FindAsync(id);
        }

        public async Task AddSuperHeroIncidentResource(SuperHeroIncidentResource superHeroIncidentResource)
        {
            _context.SuperHeroIncidentResources.Add(superHeroIncidentResource);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSuperHeroIncidentResource(SuperHeroIncidentResource superHeroIncidentResource)
        {
            _context.Entry(superHeroIncidentResource).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSuperHeroIncidentResource(SuperHeroIncidentResource superHeroIncidentResource)
        {
            _context.SuperHeroIncidentResources.Remove(superHeroIncidentResource);
            await _context.SaveChangesAsync();
        }
    }
}
