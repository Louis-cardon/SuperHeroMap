namespace SuperHeroMapApi.Services
{
    public interface IIncidentService
    {
        Task<IEnumerable<Incident>> GetIncidents();
        Task<Incident> GetIncident(int id);
        Task AddIncident(Incident incident);
        Task UpdateIncident(Incident incident);
        Task DeleteIncident(Incident incident);
    }

    public class IncidentService : IIncidentService
    {
        private readonly SuperHeroMapContext _context;

        public IncidentService(SuperHeroMapContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Incident>> GetIncidents()
        {
            return await _context.Incidents.Include(f=>f.IncidentResource).ToListAsync();
        }

        public async Task<Incident> GetIncident(int id)
        {
            return await _context.Incidents.FindAsync(id);
        }

        public async Task AddIncident(Incident incident)
        {
            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIncident(Incident incident)
        {
            _context.Entry(incident).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIncident(Incident incident)
        {
            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();
        }
    }
}
