using LoanManagementSystemNew.Model;
using LoanManagementSystemNew.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystemNew.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class LoansController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;

        public LoansController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoans()
        {
            var loans = await _loanRepository.GetAllLoansAsync();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanById(int id)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoanVerification(int id, [FromBody] Loan loan)
        {
            await _loanRepository.UpdateLoanVerificationAsync(id, loan);
            return NoContent();
        }
    }
}
