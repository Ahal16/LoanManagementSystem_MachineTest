using LMS_Machinetest6_2.Model;

namespace LMS_Machinetest6_2.Repository
{
    public interface IBackgroundVerificationRepository
    {
        public Task<BackgroundVerification> GetByIdAsync(int id);
        public Task<IEnumerable<BackgroundVerification>> GetAllAsync();
        public Task<IEnumerable<BackgroundVerification>> GetByOfficerIdAsync(int officerId);
        public Task<IEnumerable<BackgroundVerification>> GetByLoanRequestIdAsync(int loanRequestId);
        public Task<BackgroundVerification> CreateAsync(BackgroundVerification verification);
        public Task<BackgroundVerification> UpdateAsync(BackgroundVerification verification);
        public Task<bool> DeleteAsync(int id);
    }
}
