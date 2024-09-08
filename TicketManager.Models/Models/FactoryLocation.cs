using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class FactoryLocation
    {
        [Key]
        public int FactoryLocationId { get; set; }
        [StringLength(15)]
        public string? Country { get; set; }
        [StringLength(3)]
        public string? Factory { get; set; }
    }
}