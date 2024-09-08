using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Sockets;
using TicketManager.Models.Models;

namespace TicketManagerApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<FactoryLocation> FactoryLocations { get; set; }
        public DbSet<LabLocation> LabLocations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDisplacement> ProductDisplacements { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductFamily> ProductFamilies { get; set; }
        public DbSet<ReportStructure> ReportStructures { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<TicketTest> TicketTests { get; set; }
        public DbSet<TestParameter> TestParameters { get; set; }
        public DbSet<TicketTestParameter> TicketTestParameters { get; set; }
    }
}
