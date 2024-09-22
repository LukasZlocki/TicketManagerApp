using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface ITicketService
    {
        public Task<Ticket> CreateTicket(Ticket ticket);
        public Task<List<Ticket>> GetAllTickets();
        public Task<List<Ticket>> GetTicketsByLabLocation(int labLocationId);
        public Task<List<Ticket>> GetActiveTicketsByLabLocation(int labLocationId);
        public Task<List<Ticket>> GetTicketsByUserEmail(string userEmail);
        public Task<List<Ticket>> GetActiveTicketsByUserEmail(string userEmail);
        public Task<List<Ticket>> GetTicketsByFilterSetup(int pickedLabLocationId, string pickedUserEmail, int pickedTicketStatusId);
        public Task<Ticket> GetTicketDetails(int ticketId);
    }
}
