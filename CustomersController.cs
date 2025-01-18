using LMS_Machinetest6_2.Model;
using LMS_Machinetest6_2.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS_Machinetest6_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILoanRequestRepository _loanRequestRepository;
        private readonly IFeedbackRepository _feedbackRepository;

        public CustomersController(
            ICustomerRepository customerRepository,
            ILoanRequestRepository loanRequestRepository,
            IFeedbackRepository feedbackRepository)
        {
            _customerRepository = customerRepository;
            _loanRequestRepository = loanRequestRepository;
            _feedbackRepository = feedbackRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetail>> GetById(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<CustomerDetail>> GetByUserId(int userId)
        {
            var customer = await _customerRepository.GetByUserIdAsync(userId);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpGet("{customerId}/loan-requests")]
        public async Task<ActionResult<IEnumerable<LoanRequest>>> GetLoanRequests(int customerId)
        {
            var loanRequests = await _loanRequestRepository.GetByCustomerIdAsync(customerId);
            return Ok(loanRequests);
        }

        [HttpPost("{customerId}/feedback")]
        public async Task<ActionResult<CustomerFeedback>> AddFeedback(int customerId, CustomerFeedback feedback)
        {
            feedback.CustomerId = customerId;
            var result = await _feedbackRepository.CreateAsync(feedback);
            return CreatedAtAction(nameof(GetById), new { id = customerId }, result);
        }
    }
}