using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsserAttractionController : ControllerBase
    {
        private readonly UsserAttractionRepository _usserAttractionRepository;

        public UsserAttractionController(UsserAttractionRepository usserAttractionRepository)
        {
            _usserAttractionRepository = usserAttractionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsserAttractions()
        {
            return Ok(await _usserAttractionRepository.GetAllUsserAttraction());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsserAttraction([FromBody] UsserAttraction usserAttraction)
        {
            if (usserAttraction == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _usserAttractionRepository.InsertUsserAttraction(usserAttraction);
            return Created("created", created);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateUsserAttraction([FromBody] UsserAttraction usserAttraction)
        {
            if (usserAttraction == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _usserAttractionRepository.UpdateUsserAttraction(usserAttraction);
            return NoContent();
        }

    }
}
