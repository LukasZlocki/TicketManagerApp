using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [StringLength(50)]
        public string? DepartmentDescription { get; set; }

        public int FactoryLocationId { get; set; }
        [ForeignKey("FactoryLocationId")]
        public FactoryLocation? Factorylocation { get; set; }
    }
}