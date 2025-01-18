using LMS_Machinetest6_2.Model;
using Microsoft.EntityFrameworkCore;

namespace LMS_Machinetest6_2.Repository
{
    public class LoanOfficerRepository
    {
        private readonly LoanManagementDbContext _context;

        public LoanOfficerRepository(LoanManagementDbContext context)
        {
            _context = context;
        }
        public async Task<LoanOfficerDetail> GetByIdAsync(int id)
        {
            return await _context.LoanOfficerDetails
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.OfficerId == id);
        }

        public async Task<LoanOfficerDetail> GetByUserIdAsync(int userId)
        {
            return await _context.LoanOfficerDetails
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.UserId == userId);
        }

        public async Task<IEnumerable<LoanOfficerDetail>> GetAllAsync()
        {
            return await _context.LoanOfficerDetails
                .Include(o => o.User)
                .ToListAsync();
        }

        public async Task<LoanOfficerDetail> CreateAsync(LoanOfficerDetail officer)
        {
            _context.LoanOfficerDetails.Add(officer);
            await _context.SaveChangesAsync();
            return officer;
        }

        public async Task<LoanOfficerDetail> UpdateAsync(LoanOfficerDetail officer)
        {
            _context.Entry(officer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return officer;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var officer = await _context.LoanOfficerDetails.FindAsync(id);
            if (officer == null)
                return false;

            _context.LoanOfficerDetails.Remove(officer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}