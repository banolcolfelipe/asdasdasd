using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsserController : ControllerBase
    {
        private readonly UsserRepository _usserRepository;

        public UsserController(UsserRepository usserRepository)
        {
            _usserRepository = usserRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllUssers()
        {
            return Ok(await _usserRepository.GetAllUssers());
        }

        [HttpGet("{idUsser}")]
        public async Task<IActionResult> GetUsserDetails(int idUsser)
        {
            return Ok(await _usserRepository.GetUsserDetails(idUsser));
        }

        [HttpPost]

        public async Task<IActionResult> CreateUsser([FromBody] Usser usser)
        {
            if (usser == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _usserRepository.InsertUsser(usser);
            return Created("creted" , created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsser([FromBody] Usser usser)
        {
            if (usser == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _usserRepository.UpdateUsser(usser);
            return NoContent();
        }
    }
}
