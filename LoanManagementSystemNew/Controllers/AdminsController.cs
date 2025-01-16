using LoanManagementSystemNew.Model;
using LoanManagementSystemNew.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystemNew.Controllers
{
    
     [Route("api/[controller]")]
     [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminsController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _adminRepository.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("customers/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _adminRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("customers/{id}/approve")]
        public async Task<IActionResult> ApproveCustomer(int id)
        {
            await _adminRepository.ApproveOrRejectCustomerAsync(id, "Approved");
            return NoContent();
        }

        [HttpPost("customers/{id}/reject")]
        public async Task<IActionResult> RejectCustomer(int id)
        {
            await _adminRepository.ApproveOrRejectCustomerAsync(id, "Rejected");
            return NoContent();
        }

        [HttpGet("loan-officers")]
        public async Task<IActionResult> GetAllLoanOfficers()
        {
            var officers = await _adminRepository.GetAllLoanOfficersAsync();
            return Ok(officers);
        }

        [HttpPost("loan-officers/{id}/approve")]
        public async Task<IActionResult> ApproveLoanOfficer(int id)
        {
            await _adminRepository.ApproveOrRejectLoanOfficerAsync(id, "Approved");
            return NoContent();
        }

        [HttpPost("loan-officers/{id}/reject")]
        public async Task<IActionResult> RejectLoanOfficer(int id)
        {
            await _adminRepository.ApproveOrRejectLoanOfficerAsync(id, "Rejected");
            return NoContent();
        }

        [HttpPost("loans/{loanId}/assign-officer/{officerId}")]
        public async Task<IActionResult> AssignLoanOfficerForVerification(int loanId, int officerId)
        {
            await _adminRepository.AssignLoanOfficerToVerificationAsync(loanId, officerId);
            return NoContent();
        }

        [HttpGet("loans")]
        public async Task<IActionResult> GetAllLoans()
        {
            var loans = await _adminRepository.GetAllLoansAsync();
            return Ok(loans);
        }

        [HttpGet("background-verifications")]
        public async Task<IActionResult> GetAllBackgroundVerifications()
        {
            var verifications = await _adminRepository.GetAllBackgroundVerificationsAsync();
            return Ok(verifications);
        }

        [HttpPut("background-verifications/{id}")]
        public async Task<IActionResult> UpdateBackgroundVerification(int id, [FromBody] BackgroundVerification verification)
        {
            await _adminRepository.UpdateBackgroundVerificationAsync(id, verification);
            return NoContent();
        }

        [HttpDelete("background-verifications/{id}")]
        public async Task<IActionResult> DeleteBackgroundVerification(int id)
        {
            await _adminRepository.DeleteBackgroundVerificationAsync(id);
            return NoContent();
        }

        [HttpGet("help")]
        public async Task<IActionResult> GetHelpQueries()
        {
            var helpQueries = await _adminRepository.GetHelpQueriesAsync();
            return Ok(helpQueries);
        }

        [HttpPost("feedback")]
        public async Task<IActionResult> AddFeedback([FromBody] Feedback feedback)
        {
            await _adminRepository.AddFeedbackAsync(feedback);
            return CreatedAtAction(nameof(AddFeedback), new { id = feedback.FeedbackId }, feedback);
        }
    }
}
