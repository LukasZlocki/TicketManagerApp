using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        [StringLength(10)]
        public string? ProductTypeDesc { get; set; }
        public int ProductFamilyId { get; set; }

    }
}