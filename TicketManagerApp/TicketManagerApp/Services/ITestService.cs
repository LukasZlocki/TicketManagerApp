using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface ITestService
    {
        public Task<List<Test>> GetTestsByLabLocation(int labLocationId);
        public Task<List<Test>> GetTestsByProductTypeFamily(int productFamilyId);
        public Task<List<Test>> GetTestsByProductFamilyIdAndLabLocationId(int productFamilyId, int LabLocationId);
    }
}