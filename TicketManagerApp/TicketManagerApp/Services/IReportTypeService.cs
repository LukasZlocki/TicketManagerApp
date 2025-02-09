using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IReportTypeService
    {
        public Task<List<ReportType>> GetAllReportTypes();
        public Task<string> GetReportTypeById(int id);
        public Task<int> GetReportTypeIdByReportTypeShortDescription(string reportTypeShortDescription);
        public Task<List<ReportType>> GetReportTypesByProdcutFamilyId(int id);
    }
}
