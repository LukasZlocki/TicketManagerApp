using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{
    public class ProductService : IProductService
    {

        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns Product object by product primary key
        /// </summary>
        /// <param name="productId">Product primary key</param>
        /// <returns>Prodcut object</returns>
        public Task<Product> GetProductById(int productId)
        {
            try
            {
                var product = _db.Products
                    .FirstOrDefault(p => p.ProductId == productId);

                if (product != null)
                {
                    return Task.FromResult(product);
                }
                else
                {
                    return Task.FromResult<Product>(null); // or handle not found case as needed
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return Task.FromException<Product>(ex);
            }
        }

        /// <summary>
        /// Retrive Prodcut primary key base on prodcut family, product type and displacement primary key
        /// </summary>
        /// <param name="productFamilyId">ProductFamily primary key</param>
        /// <param name="productTypeId">ProductType primary key</param>
        /// <param name="displacmentId">Displacement primary key</param>
        /// <returns>Product primary key</returns>
        public Task<int> GetProductId(int productFamilyId, int productTypeId, int displacmentId)
        {
            try
            {
                var product = _db.Products
                    .Where(p => p.ProductFamilyId == productFamilyId &&
                                p.ProductTypeId == productTypeId &&
                                p.ProductDisplacementId == displacmentId)
                    .FirstOrDefault();

                if (product != null)
                {
                    return Task.FromResult(product.ProductId);
                }
                else
                {
                    return Task.FromResult(-1); // or any other value indicating not found
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return Task.FromException<int>(ex);
            }
        }
    }
}
