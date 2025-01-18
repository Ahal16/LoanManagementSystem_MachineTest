using LMS_Machinetest6_2.Model;
using LMS_Machinetest6_2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS_Machinetest6_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanRequestsController : ControllerBase
    {
        private readonly ILoanRequestRepository _lrRepository;

        public LoanRequestsController(ILoanRequestRepository lrRepository)
        {
            _lrRepository = lrRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanRequest>>> GetAll()
        {
            var loanRequests = await _lrRepository.GetAllAsync();
            return Ok(loanRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanRequest>> GetById(int id)
        {
            var loanRequest = await _lrRepository.GetByIdAsync(id);
            if (loanRequest == null)
                return NotFound();

            return Ok(loanRequest);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<LoanRequest>>> GetByCustomerId(int customerId)
        {
            var loanRequests = await _lrRepository.GetByCustomerIdAsync(customerId);
            return Ok(loanRequests);
        }

        [HttpGet("officer/{officerId}")]
        public async Task<ActionResult<IEnumerable<LoanRequest>>> GetByOfficerId(int officerId)
        {
            var loanRequests = await _lrRepository.GetByOfficerIdAsync(officerId);
            return Ok(loanRequests);
        }

        [HttpPost]
        public async Task<ActionResult<LoanRequest>> Create(LoanRequest loanRequest)
        {
            var result = await _lrRepository.CreateAsync(loanRequest);
            return CreatedAtAction(nameof(GetById), new { id = result.LoanRequestId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LoanRequest loanRequest)
        {
            if (id != loanRequest.LoanRequestId)
                return BadRequest();

            await _lrRepository.UpdateAsync(loanRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _lrRepository.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
