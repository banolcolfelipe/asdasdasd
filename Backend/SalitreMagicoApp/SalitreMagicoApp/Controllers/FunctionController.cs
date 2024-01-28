using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        private readonly FunctionRepository _functionRepository;

        public FunctionController(FunctionRepository functionRepository)
        {
            this._functionRepository = functionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(await _functionRepository.GetAllFunctions());
        }

        [HttpGet("{IdFunctions}")]

        public async Task<IActionResult> GetDetailsFunction(int IdFunctions)
        {
            return Ok(await _functionRepository.GetDetailsFunction(IdFunctions));
        }

        [HttpPost]

        public async Task<IActionResult> CreateFunction([FromBody] Functions functions)
        {
            if (functions == null)
                return BadRequest();
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _functionRepository.InsertFunction(functions);
            return Created("created", created);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateFunction([FromBody] Functions functions)
        {
            if (functions == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _functionRepository.UpdateFunction(functions);
            return NoContent();
        }
    }
}
