using LMS_Machinetest6_2.Model;
using LMS_Machinetest6_2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LMS_Machinetest6_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanOfficersController : ControllerBase
    {
        private readonly ILoanRequestRepository _loanRequestRepository;
        private readonly IBackgroundVerificationRepository _bgVerificationRepository;
        private readonly ILoanVerificationRepository _loanVerificationRepository;
        private readonly ILoanOfficerRepository _loanOfficerRepository;

        public LoanOfficersController(
            ILoanRequestRepository loanRequestRepository,
            IBackgroundVerificationRepository bgVerificationRepository,
            ILoanVerificationRepository loanVerificationRepository,
            ILoanOfficerRepository loanOfficerRepository)
        {
            _loanRequestRepository = loanRequestRepository;
            _bgVerificationRepository = bgVerificationRepository;
            _loanVerificationRepository = loanVerificationRepository;
            _loanOfficerRepository = loanOfficerRepository;
        }

        private async Task<int> GetCurrentOfficerId()
        {
            // Get the user ID from the claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                throw new UnauthorizedAccessException("User ID not found in claims");
            }

            // Get the officer details using the user ID
            var officer = await _loanOfficerRepository.GetByUserIdAsync(userId);
            if (officer == null)
            {
                throw new UnauthorizedAccessException("Loan officer not found");
            }

            return officer.OfficerId;
        }

        [HttpGet("assigned-requests")]
        public async Task<ActionResult<IEnumerable<LoanRequest>>> GetAssignedRequests()
        {
            var officerId = GetCurrentOfficerId(); 
            var requests = await _loanRequestRepository.GetByOfficerIdAsync(OfficerId);
            return Ok(requests);
        }

        [HttpPut("background-verification/{id}")]
        public async Task<IActionResult> UpdateBackgroundVerification(int id, BackgroundVerification verification)
        {
            if (id != verification.VerificationId) return BadRequest();
            await _bgVerificationRepository.UpdateAsync(verification);
            return NoContent();
        }

        [HttpPut("loan-verification/{id}")]
        public async Task<IActionResult> UpdateLoanVerification(int id, LoanVerification verification)
        {
            if (id != verification.LoanVerificationId) return BadRequest();
            await _loanVerificationRepository.UpdateAsync(verification);
            return NoContent();
        }
    }
}