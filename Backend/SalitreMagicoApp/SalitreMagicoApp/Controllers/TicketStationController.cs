using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketStationController : ControllerBase
    {
        private readonly TicketStationRepository _ticketStationRepository;

        public TicketStationController(TicketStationRepository ticketStationRepository)
        {
            _ticketStationRepository = ticketStationRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllStations()
        {
            return Ok(await _ticketStationRepository.GetAllStations());
        }
        [HttpPut]

        public async Task<IActionResult> UpdateStation([FromBody] TicketStation ticketStation)
        {
            if (ticketStation == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ticketStationRepository.UpdateStation(ticketStation);
            return NoContent();


        }
    }
}
