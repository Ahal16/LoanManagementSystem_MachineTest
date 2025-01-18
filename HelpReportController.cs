using LMS_Machinetest6_2.Model;
using LMS_Machinetest6_2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LMS_Machinetest6_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpReportController : ControllerBase
    {
        private readonly IHelpReportRepository _helpReportRepository;

        public HelpReportController(IHelpReportRepository helpReportRepository)
        {
            _helpReportRepository = helpReportRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HelpReport>>> GetAll()
        {
            var reports = await _helpReportRepository.GetAllAsync();
            return Ok(reports);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HelpReport>> GetById(int id)
        {
            var report = await _helpReportRepository.GetByIdAsync(id);
            if (report == null) return NotFound();
            return Ok(report);
        }

        [HttpPost]
        public async Task<ActionResult<HelpReport>> Create(HelpReport report)
        {
            await _helpReportRepository.CreateAsync(report);
            return CreatedAtAction(nameof(GetById), new { id = report.ReportId }, report);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, HelpReport report)
        {
            if (id != report.ReportId) return BadRequest();
            await _helpReportRepository.UpdateAsync(report);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _helpReportRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

