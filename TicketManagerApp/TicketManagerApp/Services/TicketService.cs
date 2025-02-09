using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<TicketService> _logger;
        private readonly ITicketStatusService _statusService;
        private readonly IServerDriveService _serverDriveService;

        public TicketService(ApplicationDbContext db, ILogger<TicketService> logger, ITicketStatusService statusService, IServerDriveService serverDriveService)
        {
            _db = db;
            _logger = logger;
            _statusService = statusService;
            _serverDriveService = serverDriveService;
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
                TicketTests = ticket.TicketTests,
                CustomFile = ticket.CustomFile
            };

            try
            {
                _db.Tickets.Add(_ticket);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Ticket creted successfuly with ID: {TickedId}", _ticket.TicketId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the ticket.");
                throw;
            }
            return ticket;
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

        public async Task<bool> StartThisTicket(int ticketId)
        {
            try
            {
                Ticket ticket = await GetTicketDetails(ticketId);

                // Change status to in progress
                await UpdateTicketStatus(ticketId, "In Progress");

                // Add new ticket Code number base on last report code number
                string newTicketCodeNumber = GenerateNewTicketCodeNumber(ticket.ReportType.ReportShortType);

                if (newTicketCodeNumber != null)
                {
                    await UpdateIdentificationCodeNumber(ticketId, newTicketCodeNumber);
                    await _serverDriveService.CreateReportTypeFolderStructure(newTicketCodeNumber);

                    return true;
                }
                else
                {
                    _logger.LogInformation("Failed to generate a new ticket code number.");

                    return false;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while starting the ticket with ID {ticketId}.");
                return false;
            }
        }

        /// <summary>
        /// Updates ticket identification code
        /// </summary>
        /// <param name="ticketId">Ticket primary key</param>
        /// <param name="identificationCodeNumber">Identyfication ticket report code number</param>
        /// <returns>Bolean if operation success or not</returns>
        public async Task<bool> UpdateIdentificationCodeNumber(int ticketId, string identificationCodeNumber)
        {
            try
            {
                var ticket = await _db.Tickets.FindAsync(ticketId);
                if (ticket == null)
                {
                    return false;
                }

                ticket.IdentificationCode = identificationCodeNumber;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the identification code for ticket ID {ticketId}.");
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns></returns>
        private string GenerateNewTicketCodeNumber(string reportType)
        {
            // Get and store last ticket code number
            string lastTicketCodeNumber = _serverDriveService.GetLastTicketNumber(reportType);

            // Get next ticket code number
            // code number in format ex MERXXXXX where MER - report type , XXXXX - id number
            string newTicketCodeNumber = GenerateNextTicketCodeNumber(lastTicketCodeNumber);

            return newTicketCodeNumber;
        }

        /// <summary>
        /// Generate next ticket code number base on last ticket code number
        /// </summary>
        /// <param name="lastTicketCodeNumber"></param>
        /// <returns>Returns string with next ticket code number/returns>
        /// <exception cref="ArgumentException"></exception>
        private string GenerateNextTicketCodeNumber(string lastTicketCodeNumber)
        {
            // Extract the prefix and numeric part of the code
            Match match = Regex.Match(lastTicketCodeNumber, @"([A-Z]+)(\d+)");
            if (!match.Success)
            {
                throw new ArgumentException("Invalid ticket code format");
            }

            string prefix = match.Groups[1].Value;
            string numericPart = match.Groups[2].Value;

            // Convert the numeric part to an integer and increment it
            int newNumber = int.Parse(numericPart) + 1;

            // Format the new number with leading zeros to match the original length
            string newNumericPart = newNumber.ToString("D" + numericPart.Length);

            // Combine the prefix with the new numeric part
            string newTicketCodeNumber = prefix + newNumericPart;
            return newTicketCodeNumber;
        }

    }
}
