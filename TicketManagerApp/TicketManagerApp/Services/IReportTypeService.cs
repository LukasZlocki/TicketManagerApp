using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IReportTypeService
    {
        public Task<List<ReportType>> GetAllReportTypes();
        public Task<string> GetReportTypeById(int id);
    }
}
