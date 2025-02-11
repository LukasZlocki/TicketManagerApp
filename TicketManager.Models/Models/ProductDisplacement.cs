using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class ProductDisplacement
    {
        [Key]
        public int ProductDisplacementId { get; set; }
        public string? Displacement { get; set; }
        public int ProductTypeId { get; set; }
    }
}