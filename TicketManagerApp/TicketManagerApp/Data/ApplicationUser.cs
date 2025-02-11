using Microsoft.AspNetCore.Identity;

namespace TicketManagerApp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int DepartmentId { get; set; }
        public int FactoryLocationId { get; set; }
    }
}

