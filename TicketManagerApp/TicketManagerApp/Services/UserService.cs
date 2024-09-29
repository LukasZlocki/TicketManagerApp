using Microsoft.AspNetCore.Identity;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetUserEmailByUserId(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return "N/a";
            }
            var _userEmail = await _userManager.GetUserNameAsync(user);
            return _userEmail;
        }

        public async Task<List<ApplicationUser>> GetUsersInRoleAsync(string roleName)
        {
            var userRoles = await _userManager.GetUsersInRoleAsync(roleName);
            return userRoles.ToList();
        }
    }
}
