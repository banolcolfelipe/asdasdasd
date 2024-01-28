using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketRepository _ticketRepository;

        public TicketController(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            return Ok(await _ticketRepository.GetAllTickets());
        }

        [HttpPut]

        public async Task<IActionResult> UpdateTicket(Ticket ticket)
        {
            if (ticket == null)
                return BadRequest();
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ticketRepository.UpdateTicket(ticket);
            return NoContent();
        }
    }
}
