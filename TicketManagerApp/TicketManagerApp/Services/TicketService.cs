using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<TicketService> _logger;

        public TicketService(ApplicationDbContext db, ILogger<TicketService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            try
            {
                _db.Tickets.Add(ticket);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Ticket creted successfuly with ID: {TickedId}", ticket.TicketId);
                return ticket;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, "An error occurred while creating the ticket.");
                throw;
            }
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            var tickets = await _db.Tickets.ToListAsync();
            return tickets;
        }

    }
}
