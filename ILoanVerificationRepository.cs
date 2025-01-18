using LMS_Machinetest6_2.Model;

namespace LMS_Machinetest6_2.Repository
{
    public interface ILoanVerificationRepository
    {
        public Task<LoanVerification> GetByIdAsync(int id);
        public Task<IEnumerable<LoanVerification>> GetAllAsync();
        public Task<IEnumerable<LoanVerification>> GetByOfficerIdAsync(int officerId);
        public Task<IEnumerable<LoanVerification>> GetByLoanRequestIdAsync(int loanRequestId);
        public Task<LoanVerification> CreateAsync(LoanVerification verification);
        public Task<LoanVerification> UpdateAsync(LoanVerification verification);
        public Task<bool> DeleteAsync(int id);
    }
}
