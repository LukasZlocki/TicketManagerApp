using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{
    public class ProductDisplacementService : IProductDisplacementService
    {
        private readonly ApplicationDbContext _db;

        public ProductDisplacementService(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns all displacements related to product family by product family primary key 
        /// </summary>
        /// <param name="productTypeId"></param>
        /// <returns>List of OriductDisplacement objects</returns>
        public async Task<List<ProductDisplacement>> GetProductDisplacementsByProductTypeId(int productTypeId)
        {
            try
            {
                var displacements = await _db.ProductDisplacements
                    .Where(pr => pr.ProductTypeId == productTypeId)
                    .ToListAsync();
                return displacements;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Return an empty list
                return new List<ProductDisplacement>();
            }
        }
    }
}