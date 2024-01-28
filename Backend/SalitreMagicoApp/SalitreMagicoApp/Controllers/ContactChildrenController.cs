using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactChildrenController : ControllerBase
    {
        private readonly ContactChildrenRepository _contactChildrenRepository;

        public ContactChildrenController(ContactChildrenRepository contactChildrenRepository)
        {
            _contactChildrenRepository = contactChildrenRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllContacts()
        {
            return Ok(await _contactChildrenRepository.GetAllContacts());
        }

        [HttpGet("{ContactId}")]

        public async Task<IActionResult> GetDetailsContact(int ContactId)
        {
            return Ok(await _contactChildrenRepository.GetDetailsContact(ContactId));
        }

        [HttpPost]

        public async Task<IActionResult> CreateContact([FromBody] ContactChildren contactChildren)
        {
            if (contactChildren == null)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _contactChildrenRepository.InsertContact(contactChildren);
            return Created("created", created);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateClient([FromBody] ContactChildren contactChildren)
        {
            if (contactChildren == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contactChildrenRepository.UpdateContact(contactChildren);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            await _contactChildrenRepository.DeleteContact(new ContactChildren { ContactId = contactId });
            return NoContent();
        }
    }
}
