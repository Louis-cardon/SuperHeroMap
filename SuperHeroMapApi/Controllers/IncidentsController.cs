namespace SuperHeroMapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        // GET: api/Incidents
        [HttpGet]
        public async Task<IActionResult> GetIncidents()
        {
            try
            {
                var result = await _incidentService.GetIncidents();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Incidents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncident(int id)
        {
            try
            {
                var incident = await _incidentService.GetIncident(id);

                if (incident == null)
                {
                    return NotFound();
                }

                return Ok(incident);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Incidents
        [HttpPost]
        public async Task<IActionResult> PostIncident(Incident incident)
        {
            try
            {
                await _incidentService.AddIncident(incident);
                return CreatedAtAction("GetIncident", new { id = incident.Id }, incident);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Incidents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(int id, Incident incident)
        {
            if (id != incident.Id)
            {
                return BadRequest();
            }

            try
            {
                await _incidentService.UpdateIncident(incident);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Incidents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(int id)
        {
            try
            {
                var incident = await _incidentService.GetIncident(id);
                if (incident == null)
                {
                    return NotFound();
                }

                await _incidentService.DeleteIncident(incident);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
