using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientRepository _clientRespository;

        public ClientController(ClientRepository clientRespository)
        {
            _clientRespository = clientRespository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllclients()
        {
            return Ok(await _clientRespository.GetAllClients());
        }

        [HttpGet("{IdentityNumber}")]

        public async Task<IActionResult> GetDetailsClient(int IdentityNumber)
        {
            return Ok(await _clientRespository.GetDetailsClient(IdentityNumber));
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] Client client)
        {
            if (client == null)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _clientRespository.InsertClient(client);
            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateClient([FromBody] Client client)
        {
            if (client == null)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clientRespository.UpdateClient(client);
            return NoContent();
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteCOSO(int DEPENDE)
        //{
        //    await Repositorio.METODO(new OBJETO { Id = id });
        //    return NoContent;
        //}

    }
}
