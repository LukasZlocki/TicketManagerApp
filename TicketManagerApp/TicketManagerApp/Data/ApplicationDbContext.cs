using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<CustomFile> CustomFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring relationshiip between models

            // Configure the relationship between Ticket and TicketTest
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.TicketTests)
                .WithOne(tt => tt.Ticket)
                .HasForeignKey(tt => tt.TicketId)
                .OnDelete(DeleteBehavior.Cascade); // Delete TicketTests when a Ticket is deleted

            // Configure the relationship between Ticket and ReportType
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.ReportType)
                .WithMany()
                .HasForeignKey(t => t.ReportTypeId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent ReportType from being deleted

            // Configure the relationship between Ticket and TicketStatus
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.TicketStatus)
                .WithMany()
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent TicketStatus from being deleted

            // Configure the relationship between Ticket and LabLocation
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.LabLocation)
                .WithMany()
                .HasForeignKey(t => t.LabLocationId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent LabLocation from being deleted

            // Configure the relationship between Ticket and Department
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.RequestorDepartment)
                .WithMany()
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent Department from being deleted


            // Configure the relationship between TicketTest and TicketTestParameter
            modelBuilder.Entity<TicketTest>()
                .HasMany(tt => tt.TicketTestParameters)
                .WithOne()
                .HasForeignKey(ttp => ttp.TicketTestId)
                .OnDelete(DeleteBehavior.Cascade); // This will delete TicketTestParameters when a TicketTest is deleted

            // Configure the relationship between TicketTest and Test
            modelBuilder.Entity<TicketTest>()
                .HasOne(tt => tt.Test)
                .WithMany()
                .HasForeignKey(tt => tt.TestId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent Test from being deleted

            // Configure the relationship between TicketTestParameter and TestParameter
            modelBuilder.Entity<TicketTestParameter>()
                .HasOne(ttp => ttp.TestParameter)
                .WithMany()
                .HasForeignKey(ttp => ttp.TestParameterId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent TestParameter from being deleted

        }

    }
}
