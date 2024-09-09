using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IProductTypeService
    {
        public Task <List<ProductType>> GetAllProductTypesByFamilyId(int familyId);
    }
}