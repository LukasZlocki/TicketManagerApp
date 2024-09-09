using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface ITicketService
    {
        public Task<Ticket> CreateTicket(Ticket ticket);
        public Task<List<Ticket>> GetAllTickets();
        public Task<List<Ticket>> GetTicketsByLabLocation(int labLocationId);
        public Task<List<Ticket>> GetTicketsByUserEmail(string userEmail);
        public Task<Ticket> GetTicketDetails(int ticketId);
    }
}
