
using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _db;

        public DepartmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns list of departments object which are located in factory by factory primary key.
        /// </summary>
        /// <param name="factoryLocationId"></param>
        /// <returns>List of Department</returns>
        public async Task<List<Department>> GetAllDepartmentsByFactoryLocationId(int factoryLocationId)
        {
            var departments = await _db.Departments
                .Where(id => id.FactoryLocationId == factoryLocationId)
                    .ToListAsync();
            return departments;
        }
    }
}