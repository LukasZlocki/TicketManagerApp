using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int ProductFamilyId { get; set; }
        [ForeignKey("ProductFamilyId")]
        ProductFamily ProductFamily { get; set; }
    }
}