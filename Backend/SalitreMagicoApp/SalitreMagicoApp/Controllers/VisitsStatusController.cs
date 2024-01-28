using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsStatusController : ControllerBase
    {
        private readonly VisitStatusRepository _visitStatusRepository;

        public VisitsStatusController(VisitStatusRepository visitStatusRepository)
        {
            _visitStatusRepository = visitStatusRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVisitsStatus()
        {
            return Ok(await _visitStatusRepository.GetAllVisitsStatus());
        }

        [HttpPost]

        public async Task<IActionResult> CreateVisitStatus([FromBody] VisitsStatus visitsStatus)
        {
            if (visitsStatus == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _visitStatusRepository.InsertStatusVisit(visitsStatus);
            return Created("created", created);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateVisitStatus([FromBody] VisitsStatus visitsStatus)
        {
            if (visitsStatus == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _visitStatusRepository.UpdateStatusVisit(visitsStatus);
            return NoContent();

        }

    }
}
