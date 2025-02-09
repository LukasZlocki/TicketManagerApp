using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IProductService
    {
        public Task<int> GetProductId(int productFamilyId, int productTypeId, int displacmentId);
        public Task<Product> GetProductById(int productId);
    }
}
