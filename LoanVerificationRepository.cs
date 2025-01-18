using LMS_Machinetest6_2.Model;
using Microsoft.EntityFrameworkCore;

namespace LMS_Machinetest6_2.Repository
{
    public class LoanVerificationRepository : ILoanVerificationRepository
    {
        private readonly LoanManagementDbContext _context;
        public LoanVerificationRepository(LoanManagementDbContext context)
        {
            _context = context;
        }

        public async Task<LoanVerification> GetByIdAsync(int id)
        {
            return await _context.LoanVerifications
                .Include(lv => lv.LoanRequest)
                .Include(lv => lv.Officer)
                .FirstOrDefaultAsync(lv => lv.LoanVerificationId == id);
        }

        public async Task<IEnumerable<LoanVerification>> GetAllAsync()
        {
            return await _context.LoanVerifications
                .Include(lv => lv.LoanRequest)
                .Include(lv => lv.Officer)
                .ToListAsync();
        }

        public async Task<IEnumerable<LoanVerification>> GetByOfficerIdAsync(int officerId)
        {
            return await _context.LoanVerifications
                .Include(lv => lv.LoanRequest)
                .Include(lv => lv.Officer)
                .Where(lv => lv.OfficerId == officerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<LoanVerification>> GetByLoanRequestIdAsync(int loanRequestId)
        {
            return await _context.LoanVerifications
                .Include(lv => lv.LoanRequest)
                .Include(lv => lv.Officer)
                .Where(lv => lv.LoanRequestId == loanRequestId)
                .ToListAsync();
        }

        public async Task<LoanVerification> CreateAsync(LoanVerification verification)
        {
            verification.CreatedAt = DateTime.UtcNow;
            verification.UpdatedAt = DateTime.UtcNow;
            _context.LoanVerifications.Add(verification);
            await _context.SaveChangesAsync();
            return verification;
        }

        public async Task<LoanVerification> UpdateAsync(LoanVerification verification)
        {
            verification.UpdatedAt = DateTime.UtcNow;
            _context.Entry(verification).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return verification;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var verification = await _context.LoanVerifications.FindAsync(id);
            if (verification == null)
                return false;

            _context.LoanVerifications.Remove(verification);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

