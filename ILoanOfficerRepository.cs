using LMS_Machinetest6_2.Model;

namespace LMS_Machinetest6_2.Repository
{
    public interface ILoanOfficerRepository
    {
        public Task<LoanOfficerDetail> GetByIdAsync(int id);
        public Task<LoanOfficerDetail> GetByUserIdAsync(int userId);
        public Task<IEnumerable<LoanOfficerDetail>> GetAllAsync();
        public Task<LoanOfficerDetail> CreateAsync(LoanOfficerDetail officer);
        public Task<LoanOfficerDetail> UpdateAsync(LoanOfficerDetail officer);
        public Task<bool> DeleteAsync(int id);
    }
}
