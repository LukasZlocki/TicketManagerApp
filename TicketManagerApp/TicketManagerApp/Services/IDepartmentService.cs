using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IDepartmentService
    {
        public Task<List<Department>> GetAllDepartmentsByFactoryLocationId(int factoryLocationId);
    }
}