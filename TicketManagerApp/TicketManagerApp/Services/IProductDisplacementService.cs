using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IProductDisplacementService
    {
        public Task <List<ProductDisplacement>> GetProductDisplacementsByProductFamilyId(int productFamilyId);
    }
}