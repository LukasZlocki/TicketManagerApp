using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public int ProductFamilyId { get; set; }
        [ForeignKey("ProductFamilyId")]
        public ProductFamily? ProductFamily { get; set; }

        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductType? ProductType { get; set; }

        public int ProductDisplacementId { get; set; }
        [ForeignKey("ProductDisplacementId")]
        public ProductDisplacement? ProductDisplacement { get; set; }
    }
}