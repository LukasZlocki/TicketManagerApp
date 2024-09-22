using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{

    public class TicketStatusService : ITicketStatusService
    {
        private readonly ApplicationDbContext _db;

        public TicketStatusService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<TicketStatus>> GetAllTicketStatuses()
        {
            var ticketStatuses = await _db.TicketStatuses.ToListAsync();
            return ticketStatuses;
        }
    }
}
