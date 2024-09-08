using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManager.Models.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(50)]
        public string? DepartmentDescription { get; set; }

        public int FactoryLocationId { get; set; }
        [ForeignKey("FactoryLocationId")]
        public FactoryLocation? Factorylocation { get; set; }
    }
}