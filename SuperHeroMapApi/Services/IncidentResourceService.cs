namespace SuperHeroMapApi.Services
{
    public interface IIncidentResourceService
    {
        Task<IEnumerable<IncidentResource>> GetIncidentResources();
        Task<IncidentResource> GetIncidentResource(int id);
        Task AddIncidentResource(IncidentResource incidentResource);
        Task UpdateIncidentResource(IncidentResource incidentResource);
        Task DeleteIncidentResource(IncidentResource incidentResource);
    }

    public class IncidentResourceService : IIncidentResourceService
    {
        private readonly SuperHeroMapContext _context;

        public IncidentResourceService(SuperHeroMapContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IncidentResource>> GetIncidentResources()
        {
            return await _context.IncidentResources.ToListAsync();
        }

        public async Task<IncidentResource> GetIncidentResource(int id)
        {
            return await _context.IncidentResources.FindAsync(id);
        }

        public async Task AddIncidentResource(IncidentResource incidentResource)
        {
            _context.IncidentResources.Add(incidentResource);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIncidentResource(IncidentResource incidentResource)
        {
            _context.Entry(incidentResource).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIncidentResource(IncidentResource incidentResource)
        {
            _context.IncidentResources.Remove(incidentResource);
            await _context.SaveChangesAsync();
        }
    }

}