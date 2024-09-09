using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IProductFamilyService
    {
        public Task <List<ProductFamily>> GetAllProductFamilies();
    }
}