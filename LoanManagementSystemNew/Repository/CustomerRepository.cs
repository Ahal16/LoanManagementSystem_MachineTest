using LoanManagementSystemNew.Model;

namespace LoanManagementSystemNew.Repository
{
 
public class CustomerRepository : ICustomerRepository
    {
        private readonly LoanManagementSystemContext _context;

        public CustomerRepository(LoanManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetAllLoansByCustomerAsync(int customerId)
        {
            return await _context.Loans.Where(l => l.CustomerId == customerId).ToListAsync();
        }

        public async Task AddLoanRequestAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
        }

        public async Task AddFeedbackAsync(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Help>> GetHelpQueriesAsync()
        {
            return await _context.Helps.ToListAsync();
        }
    }
  
}
