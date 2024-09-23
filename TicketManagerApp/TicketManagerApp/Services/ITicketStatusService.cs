using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface ITicketStatusService
    {
        public Task<List<TicketStatus>> GetAllTicketStatuses();
    }
}
