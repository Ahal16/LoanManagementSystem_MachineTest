using LoanManagementSystemNew.Model;

namespace LoanManagementSystemNew.Repository
{
 public class LoanRepository : ILoanRepository
    {
        private readonly LoanManagementSystemContext _context;

        public LoanRepository(LoanManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            return await _context.Loans.Include(l => l.Customer).Include(l => l.AssignedOfficer).ToListAsync();
        }

        public async Task<Loan> GetLoanByIdAsync(int id)
        {
            return await _context.Loans.Include(l => l.Customer).Include(l => l.AssignedOfficer).FirstOrDefaultAsync(l => l.LoanId == id);
        }

        public async Task UpdateLoanVerificationAsync(int loanId, Loan loan)
        {
            var existingLoan = await _context.Loans.FindAsync(loanId);
            if (existingLoan != null)
            {
                existingLoan.Status = loan.Status;
                existingLoan.VerificationNotes = loan.VerificationNotes;
                await _context.SaveChangesAsync();
            }
        }
    }
  
}
