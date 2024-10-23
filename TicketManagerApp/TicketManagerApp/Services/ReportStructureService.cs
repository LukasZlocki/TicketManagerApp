using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{
    public class ReportStructureService : IReportStructureService
    {
        private readonly ApplicationDbContext _db;

        public ReportStructureService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ReportStructure>> GetReportStructureByReportTypeId(int reportTypeId)
        {
            var ListOfReportsStructures = await _db.ReportStructures
                .Where(id => id.ReportTypeId == reportTypeId)
                .ToListAsync();

            return ListOfReportsStructures;
        }
    }
}
