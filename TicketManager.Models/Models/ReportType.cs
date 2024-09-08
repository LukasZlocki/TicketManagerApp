using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class ReportType
    {
        [Key]
        public int ReportTypeId { get; set; }
        [StringLength(3)]
        public string? ReportShortType { get; set; }
        [StringLength(30)]
        public string? ReportDescription { get; set; }
    }
}