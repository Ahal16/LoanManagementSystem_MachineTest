using LMS_Machinetest6_2.Model;
using LMS_Machinetest6_2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace LMS_Machinetest6_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILoanOfficerRepository _officerRepository;
        private readonly ILoanRequestRepository _loanRequestRepository;
        private readonly IBackgroundVerificationRepository _bgVerificationRepository;
        private readonly ILoanVerificationRepository _loanVerificationRepository;

        public AdminsController(
            ICustomerRepository customerRepository,
            ILoanOfficerRepository officerRepository,
            ILoanRequestRepository loanRequestRepository,
            IBackgroundVerificationRepository bgVerificationRepository,
            ILoanVerificationRepository loanVerificationRepository)
        {
            _customerRepository = customerRepository;
            _officerRepository = officerRepository;
            _loanRequestRepository = loanRequestRepository;
            _bgVerificationRepository = bgVerificationRepository;
            _loanVerificationRepository = loanVerificationRepository;
        }

        [HttpPut("customers/{id}/approve")]
        public async Task<IActionResult> ApproveCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) return NotFound();

            await _customerRepository.UpdateAsync(customer);
            return NoContent();
        }

        [HttpPut("customers/{id}/reject")]
        public async Task<IActionResult> RejectCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) return NotFound();

            await _customerRepository.UpdateAsync(customer);
            return NoContent();
        }

        [HttpPost("background-verification/assign")]
        public async Task<IActionResult> AssignBackgroundVerification(int loanRequestId, int officerId)
        {
            var verification = new BackgroundVerification
            {
                LoanRequestId = loanRequestId,
                OfficerId = officerId,
                CreatedAt = DateTime.UtcNow
            };

            await _bgVerificationRepository.CreateAsync(verification);
            return Ok(verification);
        }

        [HttpPost("loan-verification/assign")]
        public async Task<IActionResult> AssignLoanVerification(int loanRequestId, int officerId)
        {
            var verification = new LoanVerification
            {
                LoanRequestId = loanRequestId,
                OfficerId = officerId,
                CreatedAt = DateTime.UtcNow
            };

            await _loanVerificationRepository.CreateAsync(verification);
            return Ok(verification);
        }
    }
}