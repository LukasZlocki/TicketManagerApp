using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IProductDisplacementService
    {
        public Task <List<ProductDisplacement>> GetProductDisplacementsByProductTypeId(int productTypeId);
    }
}