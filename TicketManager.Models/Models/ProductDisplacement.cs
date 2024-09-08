using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class ProductDisplacement
    {
        [Key]
        public int ProductDisplacementId { get; set; }
        public int Displacement { get; set; }
        public int ProductFamilyId { get; set; }
    }
}