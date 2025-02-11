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

        public async Task<string> GetReportTypeById(int id)
        {
            var reportType = await _db.ReportTypes.SingleOrDefaultAsync(i => i.ReportTypeId == id);
            return reportType.ReportShortType;
        }

        public async Task<List<ReportType>> GetReportTypesByProdcutFamilyId(int id)
        {
            var reportTypes = await _db.ReportTypes
                .Where(i => i.ProductFamilyId == id)
                .ToListAsync();
            return reportTypes;
        }

        public async Task<int> GetReportTypeIdByReportTypeShortDescription(string reportTypeShortDescription)
        {
            var reportType = await _db.ReportTypes.SingleOrDefaultAsync(i => i.ReportShortType == reportTypeShortDescription);
            return reportType.ReportTypeId;
        }


    }
}
