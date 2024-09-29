using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{
    public interface IUserService
    {
        public Task<List<ApplicationUser>> GetUsersInRoleAsync(string roleName);
        public Task<string> GetUserEmailByUserId(Guid userId);
    }
}
