using LMS_Machinetest6_2.Model;

namespace LMS_Machinetest6_2.Repository
{
    public interface IHelpReportRepository
    {
        public Task<HelpReport> GetByIdAsync(int id);
        public Task<IEnumerable<HelpReport>> GetAllAsync();
        public Task<HelpReport> CreateAsync(HelpReport report);
        public Task<HelpReport> UpdateAsync(HelpReport report);
        public Task<bool> DeleteAsync(int id);
    }
}
