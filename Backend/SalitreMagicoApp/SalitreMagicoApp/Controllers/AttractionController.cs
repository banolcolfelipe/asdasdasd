using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        private readonly AttractionRepository _attractionRepository;

        public AttractionController(AttractionRepository attractionRepository)
        {
            _attractionRepository = attractionRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAttractions()
        {
            return Ok(await _attractionRepository.GetAllAttractions());
        }

        [HttpPost]

        public async Task<IActionResult> CreateAttraction([FromBody] Attractions attraction)
        {
            if (attraction == null)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _attractionRepository.InsertAttraction(attraction);
            return Created("created", created);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAttraction([FromBody] Attractions attraction)
        {
            if (attraction == null)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _attractionRepository.UpdateAttractions(attraction);
            return NoContent();
        }

    }
}
