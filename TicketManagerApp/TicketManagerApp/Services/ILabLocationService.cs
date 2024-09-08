using TicketManager.Models.Models;

namespace TicketManagerApp.Services.LabLocationServices
{
    public interface ILabLocationService
    {
        public Task<List<LabLocation>> GetAllLabLocations();
    }
}