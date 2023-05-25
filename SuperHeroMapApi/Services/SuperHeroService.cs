namespace SuperHeroMapApi.Services
{
    public interface ISuperHeroService
    {
        Task<IEnumerable<SuperHero>> GetSuperHeroes();
        Task<SuperHero> GetSuperHero(int id);
        Task AddSuperHero(SuperHero superHero);
        Task UpdateSuperHero(SuperHero superHero);
        Task DeleteSuperHero(SuperHero superHero);
    }

    public class SuperHeroService : ISuperHeroService
    {
        private readonly SuperHeroMapContext _context;

        public SuperHeroService(SuperHeroMapContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SuperHero>> GetSuperHeroes()
        {
            return await _context.SuperHeroes.Include(f=>f.SuperHeroIncidentResources).ThenInclude(f=>f.IncidentResource).ToListAsync();
        }

        public async Task<SuperHero> GetSuperHero(int id)
        {
            return await _context.SuperHeroes.FindAsync(id);
        }

        public async Task AddSuperHero(SuperHero superHero)
        {
            _context.SuperHeroes.Add(superHero);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSuperHero(SuperHero superHero)
        {
            _context.Entry(superHero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSuperHero(SuperHero superHero)
        {
            _context.SuperHeroes.Remove(superHero);
            await _context.SaveChangesAsync();
        }
    }
}
