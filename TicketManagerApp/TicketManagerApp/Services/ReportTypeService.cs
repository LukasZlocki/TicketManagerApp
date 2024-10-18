using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{
    public class ReportTypeService : IReportTypeService
    {
        private readonly ApplicationDbContext _db;

        public ReportTypeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ReportType>> GetAllReportTypes()
        {
            var reportTypes = await _db.ReportTypes.ToListAsync();
            return reportTypes;
        }
    }
}
