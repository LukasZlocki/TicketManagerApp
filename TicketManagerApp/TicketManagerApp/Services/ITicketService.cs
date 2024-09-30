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
        public Task<List<Ticket>> GetAllWaitingTickets();
        public Task<List<Ticket>> GetTicketsByFilterSetup(int pickedLabLocationId, string pickedUserEmail, int pickedTicketStatusId);
        public Task<Ticket> GetTicketDetails(int ticketId);
        public Task<List<Ticket>>GetTicketsByUserGuidId(Guid userId);
        public Task<bool> UpdateTicketData(Ticket updatedTicket);
        public Task UpdateResponsibleUserTicketData(Ticket ticket);
        public Task UpdateTicketStatus(int ticketId, string status);
        public Task UpdateClaimedTicket(Guid specialistId, int ticketId);
        public Task DeleteTicketById(int ticketId);

    }
}
