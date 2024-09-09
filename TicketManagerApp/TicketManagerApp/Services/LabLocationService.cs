using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;
using TicketManagerApp.Services;

namespace TicketManagerApp.Services
{
    public class LabLocationService : ILabLocationService
    {
        private readonly ApplicationDbContext _db;

        public LabLocationService(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns all lab locations
        /// </summary>
        /// <returns>list of LabLocation objects</returns>
        public async Task<List<LabLocation>> GetAllLabLocations()
        {
            var labLocations = await _db.LabLocations.ToListAsync();
            return labLocations;
        }
    }
}