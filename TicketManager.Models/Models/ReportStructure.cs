using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class ReportStructure
    {
        [Key]
        public int ReportStructureId { get; set; }
        [StringLength(100)]
        public string? FolderDescription { get; set; }

        public int ReportTypeId { get; set; }
    }
}