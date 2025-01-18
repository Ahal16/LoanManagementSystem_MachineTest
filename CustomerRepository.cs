using LMS_Machinetest6_2.Model;
using Microsoft.EntityFrameworkCore;

namespace LMS_Machinetest6_2.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LoanManagementDbContext _context;

        public CustomerRepository(LoanManagementDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDetail> GetByIdAsync(int id)
        {
            return await _context.CustomerDetails
                .Include(c => c.User)
                .Include(c => c.LoanRequests)
                .FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<CustomerDetail> GetByUserIdAsync(int userId)
        {
            return await _context.CustomerDetails
                .Include(c => c.User)
                .Include(c => c.LoanRequests)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<IEnumerable<CustomerDetail>> GetAllAsync()
        {
            return await _context.CustomerDetails
                .Include(c => c.User)
                .Include(c => c.LoanRequests)
                .ToListAsync();
        }

        public async Task<CustomerDetail> CreateAsync(CustomerDetail customer)
        {
            _context.CustomerDetails.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<CustomerDetail> UpdateAsync(CustomerDetail customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.CustomerDetails.FindAsync(id);
            if (customer == null)
                return false;

            _context.CustomerDetails.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

