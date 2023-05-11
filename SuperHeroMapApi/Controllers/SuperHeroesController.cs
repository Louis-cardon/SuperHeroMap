using Microsoft.AspNetCore.Mvc;

namespace SuperHeroMapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroesController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroesController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        // GET: api/SuperHeroes
        [HttpGet]
        public async Task<IActionResult> GetSuperHeroes()
        {
            try
            {
                var result = await _superHeroService.GetSuperHeroes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/SuperHeroes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSuperHero(int id)
        {
            try
            {
                var superHero = await _superHeroService.GetSuperHero(id);

                if (superHero == null)
                {
                    return NotFound();
                }

                return Ok(superHero);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/SuperHeroes
        [HttpPost]
        public async Task<IActionResult> PostSuperHero(SuperHero superHero)
        {
            try
            {
                await _superHeroService.AddSuperHero(superHero);
                return CreatedAtAction("GetSuperHero", new { id = superHero.Id }, superHero);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/SuperHeroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperHero(int id, SuperHero superHero)
        {
            if (id != superHero.Id)
            {
                return BadRequest();
            }

            try
            {
                await _superHeroService.UpdateSuperHero(superHero);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/SuperHeroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperHero(int id)
        {
            try
            {
                var superHero = await _superHeroService.GetSuperHero(id);
                if (superHero == null)
                {
                    return NotFound();
                }

                await _superHeroService.DeleteSuperHero(superHero);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
