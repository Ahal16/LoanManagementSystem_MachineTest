using LMS_Machinetest6_2.Model;
using Microsoft.EntityFrameworkCore;

namespace LMS_Machinetest6_2.Repository
{
    public class LoanRequestRepository
    {
        private readonly LoanManagementDbContext _context;

        public LoanRequestRepository(LoanManagementDbContext context)
        {
            _context = context;
        }

        public async Task<LoanRequest> GetByIdAsync(int id)
        {
            return await _context.LoanRequests
                .Include(lr => lr.Customer)
                .Include(lr => lr.LoanType)
                .FirstOrDefaultAsync(lr => lr.LoanRequestId == id);
        }

        public async Task<IEnumerable<LoanRequest>> GetAllAsync()
        {
            return await _context.LoanRequests
                .Include(lr => lr.Customer)
                .Include(lr => lr.LoanType)
                .ToListAsync();
        }

        public async Task<IEnumerable<LoanRequest>> GetByCustomerIdAsync(int customerId)
        {
            return await _context.LoanRequests
                .Include(lr => lr.Customer)
                .Include(lr => lr.LoanType)
                .Where(lr => lr.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<LoanRequest>> GetByOfficerIdAsync(int officerId)
        {
            return await _context.LoanRequests
                .Include(lr => lr.Customer)
                .Include(lr => lr.LoanType)
                .Where(lr => lr.BackgroundVerifications.Any(bv => bv.OfficerId == officerId) ||
                            lr.LoanVerifications.Any(lv => lv.OfficerId == officerId))
                .ToListAsync();
        }

        public async Task<LoanRequest> CreateAsync(LoanRequest loanRequest)
        {
            _context.LoanRequests.Add(loanRequest);
            await _context.SaveChangesAsync();
            return loanRequest;
        }

        public async Task<LoanRequest> UpdateAsync(LoanRequest loanRequest)
        {
            _context.Entry(loanRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return loanRequest;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var loanRequest = await _context.LoanRequests.FindAsync(id);
            if (loanRequest == null)
                return false;

            _context.LoanRequests.Remove(loanRequest);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}