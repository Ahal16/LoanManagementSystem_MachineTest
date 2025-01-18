using LMS_Machinetest6_2.Model;

namespace LMS_Machinetest6_2.Repository
{
    public interface ICustomerRepository
    {
        public Task<CustomerDetail> GetByIdAsync(int id);
        public Task<CustomerDetail> GetByUserIdAsync(int userId);
        public Task<IEnumerable<CustomerDetail>> GetAllAsync();
        public Task<CustomerDetail> CreateAsync(CustomerDetail customer);
        public Task<CustomerDetail> UpdateAsync(CustomerDetail customer);
        public Task<bool> DeleteAsync(int id);
    }
}
