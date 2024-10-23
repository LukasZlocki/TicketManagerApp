using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IReportStructureService
    {
        public Task<List<ReportStructure>> GetReportStructureByReportTypeId(int reportTypeId);
    }
}
