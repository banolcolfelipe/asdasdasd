using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _employeeRepository.GetAllEmployees());
        }

        [HttpGet("{int idEmployee}")]

        public async Task<IActionResult> GetDetailsEmployee(int idEmployee)
        {
            return Ok(await _employeeRepository.GetDetailsEmployee(idEmployee));
        }

        [HttpPost]

        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _employeeRepository.InsertEmployee(employee);
            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _employeeRepository.UpdateEmployee(employee);
            return NoContent();

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteEmployee (int idEmployee)
        {
            await _employeeRepository.DeleteEmployee(new Employee { IdEmployee = idEmployee });
            return NoContent();
        }

    }    
}
