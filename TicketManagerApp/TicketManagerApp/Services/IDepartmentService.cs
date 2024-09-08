using TicketManager.Models.Models;

namespace TicketManagerApp.Services.Department_Services
{
    public interface IDepartmentService
    {
        public Task<List<Department>> GetAllDepartmentsByFactoryLocationId(int factoryLocationId);
    }
}