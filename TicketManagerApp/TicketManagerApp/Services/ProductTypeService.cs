using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;
using TicketManagerApp.Services;

namespace TicketManagerApp.Services
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
            try
            {
                var productTypes = await _db.ProductTypes
                    .Where(id => id.ProductFamilyId == familyId)
                    .ToListAsync();
                return productTypes;
            }
            catch (Exception ex)
            {
                // Log the exception (you can replace this with your logging mechanism)
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Return an empty list
                return new List<ProductType>();
            }
        }
    }
}