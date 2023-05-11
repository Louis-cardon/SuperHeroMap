namespace SuperHeroMapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroIncidentResourcesController : ControllerBase
    {
        private readonly ISuperHeroIncidentResourceService _superHeroIncidentResourceService;

        public SuperHeroIncidentResourcesController(ISuperHeroIncidentResourceService superHeroIncidentResourceService)
        {
            _superHeroIncidentResourceService = superHeroIncidentResourceService;
        }

        // GET: api/SuperHeroIncidentResources
        [HttpGet]
        public async Task<IActionResult> GetSuperHeroIncidentResources()
        {
            try
            {
                var result = await _superHeroIncidentResourceService.GetSuperHeroIncidentResources();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/SuperHeroIncidentResources/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSuperHeroIncidentResource(int id)
        {
            try
            {
                var superHeroIncidentResource = await _superHeroIncidentResourceService.GetSuperHeroIncidentResource(id);

                if (superHeroIncidentResource == null)
                {
                    return NotFound();
                }

                return Ok(superHeroIncidentResource);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/SuperHeroIncidentResources
        [HttpPost]
        public async Task<IActionResult> PostSuperHeroIncidentResource(SuperHeroIncidentResource superHeroIncidentResource)
        {
            try
            {
                await _superHeroIncidentResourceService.AddSuperHeroIncidentResource(superHeroIncidentResource);
                return CreatedAtAction("GetSuperHeroIncidentResource", new { id = superHeroIncidentResource.Id }, superHeroIncidentResource);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/SuperHeroIncidentResources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperHeroIncidentResource(int id, SuperHeroIncidentResource superHeroIncidentResource)
        {
            if (id != superHeroIncidentResource.Id)
            {
                return BadRequest();
            }

            try
            {
                await _superHeroIncidentResourceService.UpdateSuperHeroIncidentResource(superHeroIncidentResource);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/SuperHeroIncidentResources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperHeroIncidentResource(int id)
        {
            try
            {
                var superHeroIncidentResource = await _superHeroIncidentResourceService.GetSuperHeroIncidentResource(id);
                if (superHeroIncidentResource == null)
                {
                    return NotFound();
                }

                await _superHeroIncidentResourceService.DeleteSuperHeroIncidentResource(superHeroIncidentResource);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
