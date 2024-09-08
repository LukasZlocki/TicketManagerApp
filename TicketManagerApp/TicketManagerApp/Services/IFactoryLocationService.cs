using TicketManager.Models.Models;

namespace TicketManagerApp.Services.FactoryLocation_Services
{
    public interface IFactoryLocationService
    {
        public Task <List<FactoryLocation>> GetAllFactoryLocations();
    }
}