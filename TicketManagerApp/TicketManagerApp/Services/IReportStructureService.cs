using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IReportStructureService
    {
        public Task<List<string>> GetReportFoldersStructureByReportTypeId(int reportTypeId);
    }
}
