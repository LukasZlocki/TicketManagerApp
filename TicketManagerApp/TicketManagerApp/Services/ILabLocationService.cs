using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface ILabLocationService
    {
        public Task<List<LabLocation>> GetAllLabLocations();
    }
}