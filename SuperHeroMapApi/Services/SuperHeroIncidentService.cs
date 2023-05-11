namespace SuperHeroMapApi.Services
{
    public interface ISuperHeroIncidentService
    {
        Task<IEnumerable<SuperHeroIncident>> GetSuperHeroIncidents();
        Task<SuperHeroIncident> GetSuperHeroIncident(int id);
        Task AddSuperHeroIncident(SuperHeroIncident superHeroIncident);
        Task UpdateSuperHeroIncident(SuperHeroIncident superHeroIncident);
        Task DeleteSuperHeroIncident(SuperHeroIncident superHeroIncident);
    }

    public class SuperHeroIncidentService : ISuperHeroIncidentService
    {
        private readonly SuperHeroMapContext _context;

        public SuperHeroIncidentService(SuperHeroMapContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SuperHeroIncident>> GetSuperHeroIncidents()
        {
            return await _context.SuperHeroIncidents.ToListAsync();
        }

        public async Task<SuperHeroIncident> GetSuperHeroIncident(int id)
        {
            return await _context.SuperHeroIncidents.FindAsync(id);
        }

        public async Task AddSuperHeroIncident(SuperHeroIncident superHeroIncident)
        {
            _context.SuperHeroIncidents.Add(superHeroIncident);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSuperHeroIncident(SuperHeroIncident superHeroIncident)
        {
            _context.Entry(superHeroIncident).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSuperHeroIncident(SuperHeroIncident superHeroIncident)
        {
            _context.SuperHeroIncidents.Remove(superHeroIncident);
            await _context.SaveChangesAsync();
        }
    }

}
