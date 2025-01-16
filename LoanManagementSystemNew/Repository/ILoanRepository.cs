using LoanManagementSystemNew.Model;

namespace LoanManagementSystemNew.Repository
{

        public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllLoansAsync();
        Task<Loan> GetLoanByIdAsync(int id);
        Task UpdateLoanVerificationAsync(int loanId, Loan loan);
    }
}
