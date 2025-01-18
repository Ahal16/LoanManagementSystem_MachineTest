using LMS_Machinetest6_2.Model;
using Microsoft.EntityFrameworkCore;

namespace LMS_Machinetest6_2.Repository
{
    public class BackgroundVerificationRepository : IBackgroundVerificationRepository
    {
        private readonly LoanManagementDbContext _context;

        public BackgroundVerificationRepository(LoanManagementDbContext context)
        {
            _context = context;
        }

        public async Task<BackgroundVerification> GetByIdAsync(int id)
        {
            return await _context.BackgroundVerifications
                .Include(bv => bv.LoanRequest)
                .Include(bv => bv.Officer)
                .FirstOrDefaultAsync(bv => bv.VerificationId == id);
        }

        public async Task<IEnumerable<BackgroundVerification>> GetAllAsync()
        {
            return await _context.BackgroundVerifications
                .Include(bv => bv.LoanRequest)
                .Include(bv => bv.Officer)
                .ToListAsync();
        }

        public async Task<IEnumerable<BackgroundVerification>> GetByOfficerIdAsync(int officerId)
        {
            return await _context.BackgroundVerifications
                .Include(bv => bv.LoanRequest)
                .Include(bv => bv.Officer)
                .Where(bv => bv.OfficerId == officerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<BackgroundVerification>> GetByLoanRequestIdAsync(int loanRequestId)
        {
            return await _context.BackgroundVerifications
                .Include(bv => bv.LoanRequest)
                .Include(bv => bv.Officer)
                .Where(bv => bv.LoanRequestId == loanRequestId)
                .ToListAsync();
        }

        public async Task<BackgroundVerification> CreateAsync(BackgroundVerification verification)
        {
            verification.CreatedAt = DateTime.UtcNow;
            verification.UpdatedAt = DateTime.UtcNow;
            _context.BackgroundVerifications.Add(verification);
            await _context.SaveChangesAsync();
            return verification;
        }

        public async Task<BackgroundVerification> UpdateAsync(BackgroundVerification verification)
        {
            verification.UpdatedAt = DateTime.UtcNow;
            _context.Entry(verification).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return verification;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var verification = await _context.BackgroundVerifications.FindAsync(id);
            if (verification == null)
                return false;

            _context.BackgroundVerifications.Remove(verification);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
