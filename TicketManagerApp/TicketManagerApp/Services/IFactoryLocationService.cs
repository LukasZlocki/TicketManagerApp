using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IFactoryLocationService
    {
        public Task <List<FactoryLocation>> GetAllFactoryLocations();
    }
}