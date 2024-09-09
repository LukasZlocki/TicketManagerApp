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
            // step1: create ticket - get ticket id
            Ticket _ticket = new Ticket
            {
                RequestorEmail = ticket.RequestorEmail,
                ImplementedAt = DateTime.UtcNow,
                StartedAt = ticket.StartedAt,
                FinishedAt = ticket.FinishedAt,
                DepartmentId = ticket.DepartmentId,
                LabLocationId = ticket.LabLocationId,
                ProductId = ticket.ProductId,
                StatusId = 1,
            };

            try
            {
                _db.Tickets.Add(ticket);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Ticket creted successfuly with ID: {TickedId}", _ticket.TicketId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the ticket.");
                throw;
            }

            // ad ticket id to ticket object
            ticket.TicketId = _ticket.TicketId;
            // step2: add Ticket id to TicketTest and its subclasses
            foreach (var ticketTest in ticket.TicketTests)
            {
                ticketTest.TicketId = _ticket.TicketId;
            }

            // step3: save tickettest -get tickettest id
            // save each tickettest to database one by one. retrive tickettest id.
            int _ticketTestCounter = 0;
            foreach (var ticketTest in ticket.TicketTests)
            {
                try
                {
                    _db.TicketTests.Add(ticketTest);
                    await _db.SaveChangesAsync();
                    _logger.LogInformation("Ticket test creted successfuly with ID: {TickedTestId}", ticketTest.TicketTestId);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while creating ticket test.");
                    throw;
                }
                // what to do with ticket test parameters ? are they saved automaticly ?
            }
            return ticket;
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            var tickets = await _db.Tickets.ToListAsync();
            return tickets;
        }

        public async Task<List<Ticket>> GetTicketsByLabLocation(int labLocationId)
        {
            var tickets = await _db.Tickets
                .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.Test)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                .Where(id => id.LabLocationId == labLocationId).ToListAsync();
            return tickets;
        }
    }
}
