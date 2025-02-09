using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{
    public class TestService : ITestService
    {
        private readonly ApplicationDbContext _db;

        public TestService(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns all tests related to lab locations by lab loaction primary key
        /// </summary>
        /// <param name="labLocationId"></param>
        /// <returns></returns>
        public async Task<List<Test>> GetTestsByLabLocation(int labLocationId)
        {
            try
            {
                var service = await _db.Tests
                    .Where(id => id.LabLocationId == labLocationId)
                    .ToListAsync();
                return service;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Test>(); 
            }
        }

        /// <summary>
        /// Returns all test by product family primary key
        /// </summary>
        /// <param name="productFamilyId">Product family primary key</param>
        /// <returns>List of Test objects</returns>
        public async Task<List<Test>> GetTestsByProductTypeFamily(int productFamilyId)
        {
            try
            {
                var service = await _db.Tests
                    .Where(id => id.ProductFamilyId == productFamilyId)
                    .ToListAsync();
                return service;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Handle the exception as needed
                return new List<Test>(); 
            }
        }

        /// <summary>
        /// Retrive test dedicated to product family and lab loction
        /// </summary>
        /// <param name="productFamilyId">Foreign key</param>
        /// <param name="labLocationId">Foreign key</param>
        /// <returns>List of Test objects</returns>
        public async Task<List<Test>> GetTestsByProductFamilyIdAndLabLocationId(int productFamilyId, int labLocationId)
        {
            try
            {
                var service = await _db.Tests
                    .Where(id => id.ProductFamilyId == productFamilyId && id.LabLocationId == labLocationId)
                    .ToListAsync();
                return service;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Handle the exception as needed
                return new List<Test>();
            }
        }


    }
}