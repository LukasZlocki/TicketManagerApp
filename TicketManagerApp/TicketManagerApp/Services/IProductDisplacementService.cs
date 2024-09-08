using TicketManager.Models.Models;

namespace TicketManagerApp.Services.ProductDisplacement_Services
{
    public interface IProductDisplacementService
    {
        public Task <List<ProductDisplacement>> GetProductDisplacementsByProductFamilyId(int productFamilyId);
    }
}