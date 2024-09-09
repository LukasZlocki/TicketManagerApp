using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface ITicketService
    {
        public Task<Ticket> CreateTicket(Ticket ticket);
        public Task<List<Ticket>> GetAllTickets();
    }
}
