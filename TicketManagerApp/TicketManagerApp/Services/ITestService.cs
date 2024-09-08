using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface ITestService
    {
        public Task<List<Test>> GetTestsByLabLocation(int labLocationId);
    }
}