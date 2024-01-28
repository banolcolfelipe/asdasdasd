using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusAttractionController : ControllerBase
    {
        private readonly StatusAttractionRepository _statusAttractionRepository;

        public StatusAttractionController(StatusAttractionRepository statusAttractionRepository)
        {
            _statusAttractionRepository = statusAttractionRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllStatus()
        {
            return Ok(await _statusAttractionRepository.GetAllStatusAttractions());
        }

        [HttpPut]

        public async Task<IActionResult> UpdateStatus([FromBody] StatusAttraction statusAttraction)
        {
            if (statusAttraction == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _statusAttractionRepository.UpdateStatusAttraction(statusAttraction);
            return NoContent();
        }
    }
}
