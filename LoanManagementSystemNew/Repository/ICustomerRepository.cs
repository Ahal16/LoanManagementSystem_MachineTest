using LoanManagementSystemNew.Model;

namespace LoanManagementSystemNew.Repository
{
  public interface ICustomerRepository
    {
        Task<IEnumerable<Loan>> GetAllLoansByCustomerAsync(int customerId);
        Task AddLoanRequestAsync(Loan loan);
        Task AddFeedbackAsync(Feedback feedback);
        Task<IEnumerable<Help>> GetHelpQueriesAsync();
    }
}
