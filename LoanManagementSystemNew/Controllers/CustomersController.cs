using LoanManagementSystemNew.Model;
using LoanManagementSystemNew.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystemNew.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost("loan")]
        public async Task<IActionResult> ApplyForLoan([FromBody] Loan loan)
        {
            await _customerRepository.AddLoanRequestAsync(loan);
            return CreatedAtAction(nameof(ApplyForLoan), new { id = loan.LoanId }, loan);
        }

        [HttpGet("loans/{customerId}")]
        public async Task<IActionResult> GetAllLoansByCustomer(int customerId)
        {
            var loans = await _customerRepository.GetAllLoansByCustomerAsync(customerId);
            return Ok(loans);
        }

        [HttpGet("help")]
        public async Task<IActionResult> GetHelpQueries()
        {
            var helpQueries = await _customerRepository.GetHelpQueriesAsync();
            return Ok(helpQueries);
        }

        [HttpPost("feedback")]
        public async Task<IActionResult> AddFeedback([FromBody] Feedback feedback)
        {
            await _customerRepository.AddFeedbackAsync(feedback);
            return CreatedAtAction(nameof(AddFeedback), new { id = feedback.FeedbackId }, feedback);
        }
    }
}
