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
            var service = await _db.Tests
                .Where(id => id.LabLocationId == labLocationId)
                    .ToListAsync();
            return service;
        }
    }
}