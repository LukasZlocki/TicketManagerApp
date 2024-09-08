using TicketManager.Models.Models;

namespace TicketManagerApp.Services.Ticket_Services
{
    public interface ITicketService
    {
        public Task<List<Ticket>> GetAllTickets();
    }
}
