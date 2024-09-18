using Microsoft.AspNetCore.Identity;

namespace TicketManagerApp.Services
{
    public class UserService
    {
        private UserManager<IdentityUser> _userManagerService;

        public UserService(UserManager<IdentityUser> UserManagerService)
        {
            _userManagerService = UserManagerService;
        }
    }
}
