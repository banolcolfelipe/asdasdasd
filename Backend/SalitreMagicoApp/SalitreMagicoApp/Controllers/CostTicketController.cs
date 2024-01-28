using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostTicketController : ControllerBase
    {
        private readonly CostoTicketRepository _costoTicketRepository;

        public CostTicketController(CostoTicketRepository costoTicketRepository)
        {
            _costoTicketRepository = costoTicketRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllCostTicket()
        {
            return Ok(await _costoTicketRepository.GetAllCostsTicket());
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCostTicket([FromBody] CostTicket costTicket)
        {
            if (costTicket == null)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _costoTicketRepository.UpdateCostTicket(costTicket);
            return NoContent();

        }


    }
}
