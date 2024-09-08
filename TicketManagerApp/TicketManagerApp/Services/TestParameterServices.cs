using Microsoft.EntityFrameworkCore;
using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services.TestParameter_Services
{
    public class TestParameterServices : ITestParameterServices
    {
        private readonly ApplicationDbContext _db;

        public TestParameterServices(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns list of test parameters by test id foreign key
        /// </summary>
        /// <param name="testId"></param>
        /// <returns>List of TestParameters objects</returns>
        public async Task<List<TestParameter>> GetTestParametersByTestId(int testId)
        {
            var testParameters = await _db.TestParameters.Where(id => id.TestId == testId).ToListAsync();
            return testParameters;
        }
    }
}
