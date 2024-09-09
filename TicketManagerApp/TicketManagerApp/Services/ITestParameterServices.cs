using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface ITestParameterServices
    {
        public Task<List<TestParameter>> GetTestParametersByTestId(int testId);
    }
}
