using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services.ProductFamily_Services
{
    public class ProductFamilyService : IProductFamilyService
    {
        private readonly ApplicationDbContext _db;

        public ProductFamilyService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ProductFamily>> GetAllProductFamilies()
        {
            var productFamilies = await _db.ProductFamilies.ToListAsync();
            return productFamilies;
        }
    }
}