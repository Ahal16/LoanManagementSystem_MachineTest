using LMS_Machinetest6_2.Model;

namespace LMS_Machinetest6_2.Repository
{
    public interface IFeedbackRepository
    {
        public Task<CustomerFeedback> GetByIdAsync(int id);
        public Task<IEnumerable<CustomerFeedback>> GetAllAsync();
        public Task<IEnumerable<CustomerFeedback>> GetByCustomerIdAsync(int customerId);
        public Task<CustomerFeedback> CreateAsync(CustomerFeedback feedback);
        public Task<CustomerFeedback> UpdateAsync(CustomerFeedback feedback);
        public Task<bool> DeleteAsync(int id);
    }
}
