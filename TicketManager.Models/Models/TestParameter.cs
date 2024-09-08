using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class TestParameter
    {
        [Key]
        public int TestParameterId { get; set; }
        public string? ParameterDescription { get; set; }
        public string? ParameterUnit { get; set; }

        public int TestId { get; set; }
    }
}
