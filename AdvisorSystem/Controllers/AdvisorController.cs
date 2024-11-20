using Microsoft.AspNetCore.Mvc;
using AdvisorSystem.Models;
using AdvisorSystem.Services;

namespace AdvisorSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorController : ControllerBase
    {
        private readonly IAdvisorService _advisorService;

        public AdvisorController(IAdvisorService advisorService)
        {
            _advisorService = advisorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvisor([FromBody] Advisor advisor)
        {
            if (advisor == null)
                return BadRequest("Advisor cannot be null");

            var createdAdvisor = await _advisorService.CreateAdvisorAsync(advisor);
            return CreatedAtAction(nameof(GetAdvisorById), new { id = createdAdvisor.Id }, createdAdvisor);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdvisorById(int id)
        {
            var advisor = await _advisorService.GetAdvisorByIdAsync(id);
            if (advisor == null)
                return NotFound();

            return Ok(advisor);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdvisors()
        {
            var advisors = await _advisorService.GetAllAdvisorsAsync();
            return Ok(advisors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdvisor([FromBody] Advisor advisor)
        {
            var updatedAdvisor = await _advisorService.UpdateAdvisorAsync(advisor);
            if (updatedAdvisor == null)
                return NotFound();

            return Ok(updatedAdvisor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvisor(int id)
        {
            var success = await _advisorService.DeleteAdvisorAsync(id);
            if (!success)
                return NotFound();

            return NoContent();  // Return 204 No Content if deletion is successful
        }
    }
}
