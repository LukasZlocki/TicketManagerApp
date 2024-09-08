using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class TicketStatus
    {
        [Key]
        public int TicketStatusId { get; set; }
        [StringLength(15)]
        public string? StatusDescription { get; set; }
    }
}