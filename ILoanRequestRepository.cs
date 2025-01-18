using LMS_Machinetest6_2.Model;

namespace LMS_Machinetest6_2.Repository
{
    public interface ILoanRequestRepository
    {
        public Task<LoanRequest> GetByIdAsync(int id);
        public Task<IEnumerable<LoanRequest>> GetAllAsync();
        public Task<IEnumerable<LoanRequest>> GetByCustomerIdAsync(int customerId);
        public Task<IEnumerable<LoanRequest>> GetByOfficerIdAsync(int officerId);
        public Task<LoanRequest> CreateAsync(LoanRequest loanRequest);
        public Task<LoanRequest> UpdateAsync(LoanRequest loanRequest);
        public Task<bool> DeleteAsync(int id);
    }
}
