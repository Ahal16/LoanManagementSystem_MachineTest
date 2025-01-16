using LoanManagementSystemNew.Model;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystemNew.Repository
{
    
    public class AdminRepository : IAdminRepository
    {
        private readonly LoanManagementSystemDbContext _context;

        public AdminRepository(LoanManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task ApproveOrRejectCustomerAsync(int id, string status)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                customer.Status = status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<LoanOfficer>> GetAllLoanOfficersAsync()
        {
            return await _context.LoanOfficers.ToListAsync();
        }

        public async Task ApproveOrRejectLoanOfficerAsync(int id, string status)
        {
            var officer = await _context.LoanOfficers.FindAsync(id);
            if (officer != null)
            {
                officer.Status = status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AssignLoanOfficerToVerificationAsync(int loanId, int officerId)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan != null)
            {
                loan.AssignedOfficerId = officerId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            return await _context.Loans.Include(l => l.Customer).Include(l => l.AssignedOfficer).ToListAsync();
        }

        public async Task<IEnumerable<BackgroundVerification>> GetAllBackgroundVerificationsAsync()
        {
            return await _context.BackgroundVerifications.Include(b => b.Loan).Include(b => b.Officer).ToListAsync();
        }

        public async Task UpdateBackgroundVerificationAsync(int id, BackgroundVerification verification)
        {
            var verificationEntity = await _context.BackgroundVerifications.FindAsync(id);
            if (verificationEntity != null)
            {
                verificationEntity.Status = verification.Status;
                verificationEntity.Notes = verification.Notes;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBackgroundVerificationAsync(int id)
        {
            var verification = await _context.BackgroundVerifications.FindAsync(id);
            if (verification != null)
            {
                _context.BackgroundVerifications.Remove(verification);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Help>> GetHelpQueriesAsync()
        {
            return await _context.Helps.ToListAsync();
        }

        public async Task AddFeedbackAsync(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
        }
    }
  
}
