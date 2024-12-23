﻿using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<TicketService> _logger;
        private readonly ITicketStatusService _statusService;

        public TicketService(ApplicationDbContext db, ILogger<TicketService> logger, ITicketStatusService statusService)
        {
            _db = db;
            _logger = logger;
            _statusService = statusService;
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {

            // step1: create ticket - get ticket id
            Ticket _ticket = new Ticket
            {
                IdentificationCode = "N/A",
                RequestorEmail = ticket.RequestorEmail,
                ImplementedAt = DateTime.UtcNow,
                StartedAt = ticket.StartedAt,
                FinishedAt = ticket.FinishedAt,
                ResponsibleEmail = "N/A",
                ReportTypeId = ticket.ReportTypeId,
                DepartmentId = ticket.DepartmentId,
                LabLocationId = ticket.LabLocationId,
                ProductId = ticket.ProductId,
                StatusId = 1,
                TicketTests = ticket.TicketTests
            };

            try
            {
                _db.Tickets.Add(_ticket);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Ticket creted successfuly with ID: {TickedId}", _ticket.TicketId);
                // generate new ticket code number and update ticket in db
                bool isTicketUpdated = await UpdateTicketCodeNumber(_ticket.TicketId);
                if (isTicketUpdated == true)
                {
                    _logger.LogInformation("Ticket updated with new ticket code number. Ticket ID: {TickedId}", _ticket.TicketId);
                }
                else
                {
                    _logger.LogInformation("Ticket NOT updated with new ticket code number. Ticket ID: {TickedId}", _ticket.TicketId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the ticket.");
                throw;
            }
            return ticket;
        }

        private async Task<bool> UpdateTicketCodeNumber(int ticketId)
        {
            try
            {
                var ticketToUpdate = await _db.Tickets.FirstOrDefaultAsync(id => id.TicketId == ticketId);
                var reportType = await _db.ReportTypes.FirstOrDefaultAsync(id => id.ReportTypeId == ticketToUpdate.ReportTypeId);
                // Generate ticket code number
                string ticketCodeNumber = GenerateTicketCodeNumber(ticketId, reportType.ReportShortType);
                // Add ticket code number to ticket
                ticketToUpdate.IdentificationCode = ticketCodeNumber;
                await UpdateTicketData(ticketToUpdate);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Code ticket number to format MERXXXXX, where MER - report type , XXXXX - primary key number
        /// </summary>
        /// <param name="ticketId"></param>
        /// <param name="reportType"></param>
        /// <returns>ticket code number as string</returns>
        private string GenerateTicketCodeNumber(int ticketId, string reportType)
        {
            string ticketCodeNumber = "";
            // code number in format ex MERXXXXX where MER - report type , XXXXX - id number
            if (ticketId <= 9)
            {
                return reportType + "0000" + ticketId.ToString();
            }
            if (ticketId <= 99)
            {
                return reportType + "000" + ticketId.ToString();
            }
            if (ticketId <= 999)
            {
                return reportType + "00" + ticketId.ToString();
            }
            if (ticketId <= 9999)
            {
                return reportType + "0" + ticketId.ToString();
            }
            else
            {
                return reportType + ticketId.ToString();
            }
        }

        public async Task DeleteTicketById(int ticketId)
        {
            try
            {
                // Find ticket by id
                var ticket = await _db.Tickets.FindAsync(ticketId);
                if (ticket == null)
                {
                    _logger.LogWarning("Ticket with ID {TicketId} not found", ticketId);
                    return;
                }

                // Remove the ticket from the database
                _db.Tickets.Remove(ticket);

                // Save changes to the database
                await _db.SaveChangesAsync();

                _logger.LogInformation("Ticket with ID {TicketId} deleted successfully", ticketId);

            }
            catch (Exception ex)
            {
                _logger.LogInformation("Ticket with ID {TicketId} NOT deleted successfully", ticketId);
            }
        }

        public async Task<List<Ticket>> GetActiveTicketsByLabLocation(int labLocationId)
        {
            var activeTickets = await _db.Tickets
                .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.Test)
                .Include(r => r.ReportType)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                    .Where(s => s.TicketStatus.StatusDescription == "In Progress" ||
                    s.TicketStatus.StatusDescription == "Waiting")
                .Where(id => id.LabLocationId == labLocationId).ToListAsync();
            return activeTickets;
        }

        public async Task<List<Ticket>> GetActiveTicketsByUserEmail(string userEmail)
        {
            var activeTickets = await _db.Tickets
                .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.Test)
                .Include(r => r.ReportType)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                    .Where(s => s.TicketStatus.StatusDescription == "In Progress" ||
                    s.TicketStatus.StatusDescription == "Waiting")
                .Where(e => e.RequestorEmail == userEmail)
                .ToListAsync();
            return activeTickets;
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            var tickets = await _db.Tickets.ToListAsync();
            return tickets;
        }

        public async Task<List<Ticket>> GetAllWaitingTickets()
        {
            var activeTickets = await _db.Tickets
                .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.Test)
                .Include(r => r.ReportType)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                    .Where(s => s.TicketStatus.StatusDescription == "Waiting")
                .ToListAsync();
            return activeTickets;
        }

        public async Task<Ticket> GetTicketBasicData(int ticketId)
        {
            var basicTicket = await _db.Tickets.FindAsync(ticketId);
            return basicTicket ?? new Ticket();
        }

        public async Task<Ticket> GetTicketDetails(int ticketId)
        {
            var ticket = await _db.Tickets
            .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.Test)
                .Include(r => r.ReportType)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                .FirstOrDefaultAsync(id => id.TicketId == ticketId);
            return ticket ?? new Ticket();
        }

        public async Task<List<Ticket>> GetTicketsByFilterSetup(int pickedLabLocationId, string pickedUserEmail, int pickedTicketStatusId)
        {
            if (pickedUserEmail != null && pickedUserEmail != "")
            {
                var filteredtickets = await _db.Tickets
                .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.Test)
                .Include(r => r.ReportType)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                    .Where(s => s.TicketStatus.TicketStatusId == pickedTicketStatusId)
                .Where(i => i.LabLocationId == pickedLabLocationId && i.RequestorEmail == pickedUserEmail)
                .ToListAsync();
                return filteredtickets;
            }
            else
            {
                var filteredtickets = await _db.Tickets
                .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.Test)
                .Include(r => r.ReportType)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                    .Where(s => s.TicketStatus.TicketStatusId == pickedTicketStatusId)
                .Where(id => id.LabLocationId == pickedLabLocationId)
                .ToListAsync();
                return filteredtickets;
            }
        }

        public async Task<List<Ticket>> GetTicketsByLabLocation(int labLocationId)
        {
            var tickets = await _db.Tickets
                .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.Test)
                .Include(r => r.ReportType)
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

        public async Task<List<Ticket>> GetTicketsByResponsiblePersonEmail(string responsibleEmail)
        {
            var reponsiblePersonTickets = await _db.Tickets
                .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.Test)
                .Include(r => r.ReportType)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                    .Where(s => s.TicketStatus.StatusDescription == "In Progress" ||
                    s.TicketStatus.StatusDescription == "Waiting")
                .Where(e => e.ResponsibleEmail == responsibleEmail)
                .ToListAsync();
            return reponsiblePersonTickets;
        }

        public async Task<List<Ticket>> GetTicketsByUserEmail(string userEmail)
        {
            var tickets = await _db.Tickets
                .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.Test)
                .Include(r => r.ReportType)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                .Where(e => e.RequestorEmail == userEmail)
                .ToListAsync();
            return tickets;
        }

        public async Task<List<Ticket>> GetTicketsByUserGuidId(string responsibleEmail)
        {
            var tickets = await _db.Tickets
                .Include(t => t.TicketTests)
                    .ThenInclude(t => t.TicketTestParameters)
                        .ThenInclude(t => t.TestParameter)
                    .Include(t => t.TicketTests)
                    .ThenInclude(t => t.Test)
                .Include(r => r.ReportType)
                .Include(t => t.RequestorDepartment)
                    .ThenInclude(t => t.Factorylocation)
                .Include(t => t.LabLocation)
                .Include(t => t.Product)
                    .Include(t => t.Product.ProductFamily)
                    .Include(t => t.Product.ProductDisplacement)
                    .Include(t => t.Product.ProductType)
                .Include(t => t.TicketStatus)
                .Where(u => u.ResponsibleEmail == responsibleEmail)
                .ToListAsync();
            return tickets;
        }

        public async Task UpdateClaimedTicket(string responsibleEmail, int ticketId)
        {
            var ticketStatuses = await _db.TicketStatuses.ToListAsync();
            var updateTicket = await _db.Tickets.FindAsync(ticketId);

            if (updateTicket != null)
            {
                updateTicket.ResponsibleEmail = responsibleEmail;
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Ticket not found");
            }
        }

        public async Task UpdateResponsibleUserTicketData(Ticket ticket)
        {
            var updateTicket = await _db.Tickets.FindAsync(ticket.TicketId);
            if (updateTicket != null)
            {
                updateTicket.ResponsibleEmail = ticket.ResponsibleEmail;
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Ticket not found");
            }
        }

        public async Task<bool> UpdateTicketData(Ticket updatedTicket)
        {
            _db.Entry(updatedTicket).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
                _logger.LogInformation("Ticket with ID {updatedTicket.TicketId} successfully updated.", updatedTicket.TicketId);
                return true;
            }
            catch
            {
                _logger.LogInformation("Ticket with ID {updatedTicket.TicketId} NOT updated.", updatedTicket.TicketId);
                return false;
            }
        }

        public async Task UpdateTicketStatus(int ticketId, string status)
        {
            // Get status id
            var ticketStatuses = await _statusService.GetAllTicketStatuses();
            var statusId = ticketStatuses
                .Where(s => s.StatusDescription.Equals("In Progress", StringComparison.OrdinalIgnoreCase))
                .Select(s => s.TicketStatusId)
                .FirstOrDefault();

            var updateTicket = await _db.Tickets.FindAsync(ticketId);
            if (updateTicket != null)
            {
                try
                {
                    updateTicket.StatusId = statusId;
                    await _db.SaveChangesAsync();
                    _logger.LogInformation("Ticket status updated");
                }
                catch
                {
                    _logger.LogInformation("Ticket status not updated");
                }
            }
            else
            {
                _logger.LogInformation("No ticket found");
            }
        }
    }
}
