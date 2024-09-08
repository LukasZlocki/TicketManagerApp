using TicketManager.Models.Models;

namespace TicketManagerApp.Services.ProductFamily_Services
{
    public interface IProductFamilyService
    {
        public Task <List<ProductFamily>> GetAllProductFamilies();
    }
}