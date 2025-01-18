using LMS_Machinetest6_2.Model;

namespace LMS_Machinetest6_2.Repository
{
    public interface IUserRepository
    {
        public Task<User> GetByIdAsync(int id);
        public Task<User> GetByUsernameAsync(string username);
        public Task<IEnumerable<User>> GetAllAsync();
        public Task<User> CreateAsync(User user);
        public Task<User> UpdateAsync(User user);
        public Task<bool> DeleteAsync(int id);
    }
}