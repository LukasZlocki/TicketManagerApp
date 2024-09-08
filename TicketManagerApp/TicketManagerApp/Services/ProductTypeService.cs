using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;
using TicketManagerApp.Services.ProductTypeServices;

namespace TicketManagerApp.Services.ProductType_Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly ApplicationDbContext _db;

        public ProductTypeService(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns product types by product family primary key
        /// </summary>
        /// <param name="familyId"></param>
        /// <returns>List of ProductType objects</returns>
        public async Task<List<ProductType>> GetAllProductTypesByFamilyId(int familyId)
        {
            var productTypes = await _db.ProductTypes
                .Where(id => id.ProductFamilyId == familyId)
                    .ToListAsync();
            return productTypes;
        }
    }
}