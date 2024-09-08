using TicketManager.Models.Models;

namespace TicketManagerApp.Services.TestParameter_Services
{
    public interface ITestParameterServices
    {
        public Task<List<TestParameter>> GetTestParametersByTestId(int testId);
    }
}
