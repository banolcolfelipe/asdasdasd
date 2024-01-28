using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalitreMagico.Data.Repositories;
using SalitreMagico.Model;

namespace SalitreMagicoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPositionController : ControllerBase
    {
        private readonly JobPositionRepository _jobPositionRepository;

        public JobPositionController(JobPositionRepository jobPositionRepository)
        {
            _jobPositionRepository = jobPositionRepository;
        }

        [HttpGet]
    
        public async Task<IActionResult> GetAllJobs()
        {
            return Ok(await _jobPositionRepository.GetAllJobs());
        }

        [HttpGet("{IdJob}")]
    
        public async Task<IActionResult> GetJobDeatils(int IdJob)
        {
            return Ok(await _jobPositionRepository.GetDetailsJob(IdJob));
        }

        [HttpPost]

        public async Task<IActionResult> CreateJobs([FromBody] JobPosition jobPosition)
        {
            if (jobPosition == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _jobPositionRepository.InsertJob(jobPosition);
            return Created("created", created);

        }


    }
}
