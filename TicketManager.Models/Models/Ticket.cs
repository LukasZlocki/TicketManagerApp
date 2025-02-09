using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [StringLength(100)]
        public string IdentificationCode { get; set; }
        public string? RequestorEmail { get; set; }
        public DateTime ImplementedAt { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public string? ResponsibleEmail { get; set; }

        public List<TicketTest>? TicketTests { get; set; }

        public int ReportTypeId { get; set; }
        [ForeignKey("ReportTypeId")]
        public ReportType? ReportType { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? RequestorDepartment { get; set; }

        public int LabLocationId { get; set; }
        [ForeignKey("LabLocationId")]
        public LabLocation? LabLocation { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public TicketStatus? TicketStatus { get; set; }

        public int? CustomFileId { get; set; } // Nullable field
        public CustomFile CustomFile { get; set; }

        // Constructor
        public Ticket()
        {
            //ReportType = new();
            //RequestorDepartment = new();
            //LabLocation = new();
            //Product = new();
            //TicketStatus = new();
        }

    }
}