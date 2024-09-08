using TicketManager.Models.Models;

namespace TicketManagerApp.Services.Test_Services
{
    public interface ITestService
    {
        public Task<List<Test>> GetTestsByLabLocation(int labLocationId);
    }
}