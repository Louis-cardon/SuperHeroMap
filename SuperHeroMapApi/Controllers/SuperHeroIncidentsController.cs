namespace SuperHeroMapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroIncidentsController : ControllerBase
    {
        private readonly ISuperHeroIncidentService _superHeroIncidentService;

        public SuperHeroIncidentsController(ISuperHeroIncidentService superHeroIncidentService)
        {
            _superHeroIncidentService = superHeroIncidentService;
        }

        // GET: api/SuperHeroIncidents
        [HttpGet]
        public async Task<IActionResult> GetSuperHeroIncidents()
        {
            try
            {
                var result = await _superHeroIncidentService.GetSuperHeroIncidents();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/SuperHeroIncidents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSuperHeroIncident(int id)
        {
            try
            {
                var superHeroIncident = await _superHeroIncidentService.GetSuperHeroIncident(id);

                if (superHeroIncident == null)
                {
                    return NotFound();
                }

                return Ok(superHeroIncident);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/SuperHeroIncidents
        [HttpPost]
        public async Task<IActionResult> PostSuperHeroIncident(SuperHeroIncident superHeroIncident)
        {
            try
            {
                await _superHeroIncidentService.AddSuperHeroIncident(superHeroIncident);
                return CreatedAtAction("GetSuperHeroIncident", new { id = superHeroIncident.Id }, superHeroIncident);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/SuperHeroIncidents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperHeroIncident(int id, SuperHeroIncident superHeroIncident)
        {
            if (id != superHeroIncident.Id)
            {
                return BadRequest();
            }

            try
            {
                await _superHeroIncidentService.UpdateSuperHeroIncident(superHeroIncident);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/SuperHeroIncidents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperHeroIncident(int id)
        {
            try
            {
                var superHeroIncident = await _superHeroIncidentService.GetSuperHeroIncident(id);
                if (superHeroIncident == null)
                {
                    return NotFound();
                }

                await _superHeroIncidentService.DeleteSuperHeroIncident(superHeroIncident);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
