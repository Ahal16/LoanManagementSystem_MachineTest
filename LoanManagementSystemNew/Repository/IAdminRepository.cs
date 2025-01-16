using LoanManagementSystemNew.Model;

namespace LoanManagementSystemNew.Repository
{
public interface IAdminRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task ApproveOrRejectCustomerAsync(int id, string status);
        Task<IEnumerable<LoanOfficer>> GetAllLoanOfficersAsync();
        Task ApproveOrRejectLoanOfficerAsync(int id, string status);
        Task AssignLoanOfficerToVerificationAsync(int loanId, int officerId);
        Task<IEnumerable<Loan>> GetAllLoansAsync();
        Task<IEnumerable<BackgroundVerification>> GetAllBackgroundVerificationsAsync();
        Task UpdateBackgroundVerificationAsync(int id, BackgroundVerification verification);
        Task DeleteBackgroundVerificationAsync(int id);
        Task<IEnumerable<Help>> GetHelpQueriesAsync();
        Task AddFeedbackAsync(Feedback feedback);
    }
}
