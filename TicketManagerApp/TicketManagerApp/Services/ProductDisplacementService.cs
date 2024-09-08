using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services.ProductDisplacement_Services
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
        /// <param name="productFamilyId"></param>
        /// <returns>List of OriductDisplacement objects</returns>
        public async Task<List<ProductDisplacement>> GetProductDisplacementsByProductFamilyId(int productFamilyId)
        {
            var displacements = await _db.ProductDisplacements
                .Where(pr => pr.ProductFamilyId == productFamilyId)
                    .ToListAsync();
            return displacements;
        }
    }
}