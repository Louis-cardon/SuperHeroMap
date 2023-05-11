namespace SuperHeroMapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentResourcesController : ControllerBase
    {
        private readonly IIncidentResourceService _incidentResourceService;

        public IncidentResourcesController(IIncidentResourceService incidentResourceService)
        {
            _incidentResourceService = incidentResourceService;
        }

        // GET: api/IncidentResources
        [HttpGet]
        public async Task<IActionResult> GetIncidentResources()
        {
            try
            {
                var result = await _incidentResourceService.GetIncidentResources();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/IncidentResources/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncidentResource(int id)
        {
            try
            {
                var incidentResource = await _incidentResourceService.GetIncidentResource(id);

                if (incidentResource == null)
                {
                    return NotFound();
                }

                return Ok(incidentResource);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/IncidentResources
        [HttpPost]
        public async Task<IActionResult> PostIncidentResource(IncidentResource incidentResource)
        {
            try
            {
                await _incidentResourceService.AddIncidentResource(incidentResource);
                return CreatedAtAction("GetIncidentResource", new { id = incidentResource.Id }, incidentResource);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/IncidentResources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentResource(int id, IncidentResource incidentResource)
        {
            if (id != incidentResource.Id)
            {
                return BadRequest();
            }

            try
            {
                await _incidentResourceService.UpdateIncidentResource(incidentResource);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/IncidentResources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidentResource(int id)
        {
            try
            {
                var incidentResource = await _incidentResourceService.GetIncidentResource(id);
                if (incidentResource == null)
                {
                    return NotFound();
                }

                await _incidentResourceService.DeleteIncidentResource(incidentResource);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
