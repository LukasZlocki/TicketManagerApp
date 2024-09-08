using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services.FactoryLocation_Services
{
    public class FactoryLocationService : IFactoryLocationService
    {
        private readonly ApplicationDbContext _db;

        public FactoryLocationService(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns all factory locations
        /// </summary>
        /// <returns>List of FactoryLocation objects</returns>
        public async Task<List<FactoryLocation>> GetAllFactoryLocations()
        {
            var factoryLocations = await _db.FactoryLocations.ToListAsync();
            return factoryLocations;
        }
    }
}